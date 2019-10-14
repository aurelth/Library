using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using DevExpress.Web.ASPxGridView;

namespace AMBEV.AS.Utils.Tools
{
    public class CustomCsvExporter
    {
        public delegate string BuscaValorHandler(string valor, string campo, int indice);


        private readonly ASPxGridView _grid;
        private readonly bool[] _isInvalidCharInFields;
        private readonly string _nomeArquivoExportar;
        public BuscaValorHandler FuncaoHandler;
        private string[] _columnHeaderNames;

        private short _tipoExportacao = 1;
        private ExcelWriter excelWriter = null;

        public CustomCsvExporter(ASPxGridView grid, string filename)
        {
            DefaultCsvDefinition = new CsvDefinition
            {
                EndOfLine = "\r\n",
                FieldSeparator = CultureInfo.CurrentCulture.TextInfo.ListSeparator[0],
                TextQualifier = '"'
            };

            var invalidCharsInFields = new[]
            {'\r', '\n', DefaultCsvDefinition.TextQualifier, DefaultCsvDefinition.FieldSeparator};
            _isInvalidCharInFields = new bool[256];

            foreach (char c in invalidCharsInFields)
            {
                _isInvalidCharInFields[c] = true;
            }

            _nomeArquivoExportar = filename;
            ColumnHeaderNames = _columnHeaderNames;
            _grid = grid;

            MontaColunas();
        }

        private string[] ColumnHeaderNames
        {
            set { _columnHeaderNames = value; }
        }

        private static CsvDefinition DefaultCsvDefinition { get; set; }

        public void ExportarCvs()
        {
            _tipoExportacao = 1;
            FileHelper.DeleteFile(_nomeArquivoExportar);

            using (var writer = new StreamWriter(_nomeArquivoExportar, false, Encoding.Default))
            {

                WriteToCsv(writer);
            }
        }

        public void ExportarXlsx()
        {
            _tipoExportacao = 2;

            using (var writer = new BinaryWriter(File.Open(_nomeArquivoExportar, FileMode.Create, FileAccess.Write)))
            {
                excelWriter = new ExcelWriter(writer);
                WriteToExcel();
            }

        }

        private void MontaColunas()
        {
            IEnumerable<string> names = from GridViewDataColumn column in _grid.VisibleColumns
                select column.ToString();
            ColumnHeaderNames = names.ToArray();
        }


        private void WriteToExcel()
        {
            excelWriter.BeginWrite();
            WriteHeadersExcel();
            WriteData(null);
            excelWriter.EndWrite();
        }

        private void WriteToCsv(TextWriter stream)
        {
            if (stream != null)
            {
                WriteHeaders(stream);
                WriteData(stream);
            }
            else
            {
                throw new NullReferenceException();
            }
        }

        private void WriteHeadersExcel()
        {
            if (_columnHeaderNames == null || _columnHeaderNames.Length == 0) return;
            for (var col = 0; col < _columnHeaderNames.Length; col++)
            {
                excelWriter.WriteCell(0, col,_columnHeaderNames[col]);
            }
        }

        private void WriteHeaders(TextWriter stream)
        {
            if (_columnHeaderNames == null || _columnHeaderNames.Length == 0) return;
            for (int i = 0; i < _columnHeaderNames.Length; i++)
            {
                stream.Write(_columnHeaderNames[i]);
                if (i < _columnHeaderNames.Length - 1)
                    stream.Write(DefaultCsvDefinition.FieldSeparator);
            }
            stream.Write(Environment.NewLine);
            stream.Flush();
        }

        private bool RequiresQuotes(string valueString)
        {
            int len = valueString.Length;
            for (int i = 0; i < len; i++)
            {
                char c = valueString[i];
                if (c <= 255 && _isInvalidCharInFields[c])
                    return true;
            }
            return false;
        }

        private void WriteRow(TextWriter stream, IList<string> reader)
        {
            try
            {
                for (int i = 0; i < reader.Count; i++)
                {
                    string data = reader[i];
                    if (RequiresQuotes(data))
                    {
                        var csvLine = new StringBuilder();
                        csvLine.Append(DefaultCsvDefinition.TextQualifier);
                        foreach (char c in data)
                        {
                            if (c == DefaultCsvDefinition.TextQualifier)
                                csvLine.Append(c); // double the double quotes
                            csvLine.Append(c);
                        }
                        csvLine.Append(DefaultCsvDefinition.TextQualifier);
                    }

                    if (data != null)
                        stream.Write(data);
                    if (i < reader.Count - 1)
                        stream.Write(DefaultCsvDefinition.FieldSeparator);
                }
                stream.Write(Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void WriteExcel(IList<string> reader, int row)
        {
            try
            {
                for (int col = 0; col < reader.Count; col++)
                {
                    string data = reader[col];
                    if (data != null)
                        excelWriter.WriteCell(row + 1, col,data);
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }

        private void WriteData(TextWriter stream)
        {
            for (int i = 0; i < _grid.VisibleRowCount; i++)
            {
                var colunas = new List<string>();
                for (int y = 0; y < _grid.VisibleColumns.Count; y++)
                {
                    string linha = string.Empty;

                    if (FuncaoHandler != null)
                    {
                        linha = FuncaoHandler(linha, _columnHeaderNames[y], i);
                    }

                    if (string.IsNullOrWhiteSpace(linha))
                    {
                        try
                        {
                            string coluna = ((GridViewDataColumn) (_grid.Columns[y])).FieldName;
                            if (!string.IsNullOrWhiteSpace(coluna))
                            {
                                object valor = (_grid.GetRowValues(i, coluna));
                                linha = valor.ToString();
                            }
                        }
                        catch (Exception)
                        {
                            linha = string.Empty;
                        }
                    }
                    colunas.Add(linha);
                }
                if (_tipoExportacao == 1)
                {
                    WriteRow(stream, colunas);
                }
                else if (_tipoExportacao == 2)
                {
                    WriteExcel(colunas,i);
                }
            }
        }
    }
}