using System;
using BO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System.Globalization;
using System.Threading;

namespace WebApplication1
{
    public partial class tbJobHist : Page
    {
        #region Metodos Private

        private void CarregaRepeatJH()
        {
            JobHistBO setadados = new JobHistBO();
            var dados = setadados.ObterJobsHist();
            rptJobHist.DataSource = dados;
            rptJobHist.DataBind();
        }

        private void LimparCampos()
        {
            ddlColaborador.SelectedIndex = 1;
            ddlDpt.SelectedIndex = 1;
            ddlFunção.SelectedIndex = 1;
            cldDataFinal.SelectedDate = DateTime.Now;
            cldDataFinal.VisibleDate = DateTime.Now;
            cldDataInicial.SelectedDate = DateTime.Now;
            cldDataInicial.VisibleDate = DateTime.Now;
        }

        private void CarregaddlDepartament()
        {
            DepartmentBO setadado = new DepartmentBO();
            var dado = setadado.ObterDepart();
            ddlDpt.DataSource = dado;
            ddlDpt.DataBind();
        }

        private void CarregaddlColaborador()
        {
            EmployeeBO setadados = new EmployeeBO();
            var dado = setadados.ObterEmployee();
            ddlColaborador.DataSource = dado;
            ddlColaborador.DataBind();
        }

        private void CarregaddlJobs()
        {
            JobBO seta = new JobBO();
            var dado = seta.ObterJob();
            ddlFunção.DataSource = dado;
            ddlFunção.DataBind();

        }

        #endregion

        #region Metodos Protected

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaRepeatJH();
                CarregaddlColaborador();
                CarregaddlDepartament();
                CarregaddlJobs();
            }
        }

        #region Click

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var dataset = new JobHistBO();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");

            dataset.SalvarJobHist(Convert.ToInt32(ddlColaborador.SelectedValue), cldDataInicial.SelectedDate, cldDataFinal.SelectedDate, ddlFunção.SelectedValue, Convert.ToInt32(ddlDpt.SelectedValue));
            
            CarregaRepeatJH();
            LimparCampos();
            pnlInsert.Visible = false;
        }

        protected void lbtAdcionar_Click(object sender, EventArgs e)
        {
            CarregaddlDepartament();
            CarregaddlColaborador();
            CarregaddlJobs();
            LimparCampos();
            pnlInsert.Visible = true;
            Button btn = btnSave;
            btn.Text = "Inserir";
        }

        protected void lbtExportarExcel_Click(object sender, EventArgs e)
        {
            JobHistBO dataset = new JobHistBO();
            var colecao = dataset.ObterJobsHist().AsEnumerable();

            MemoryStream stream = new MemoryStream();

            using (ExcelPackage pck = new ExcelPackage())
            {
                int linha = 2;
                int coluna = 1;
                string content = string.Format("A1:E{0}", colecao.Count() + 1);

                ExcelWorksheet workSheet = pck.Workbook.Worksheets.Add("Histórico de Funções");

                #region Formatador
                workSheet.Cells[content].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                workSheet.Cells[content].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[content].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[content].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[content].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                #endregion

                #region Cabecalho
                workSheet.Cells["A1:E1"].Style.Font.Bold = true;
                workSheet.Cells["A1:E1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["A1:E1"].Style.Fill.BackgroundColor.SetColor(Color.WhiteSmoke);
                workSheet.Cells["A1"].Value = "Colaborador";
                workSheet.Cells["B1"].Value = "Data inical";
                workSheet.Cells["C1"].Value = "Data final";
                workSheet.Cells["D1"].Value = "Função Excercida";
                workSheet.Cells["E1"].Value = "Departamento";

                #endregion

                #region Dados

                foreach (var item in colecao)
                {
                    workSheet.Cells[linha, coluna].Value = item.EmpName;
                    workSheet.Cells[linha, coluna + 1].Value = item.StartDate;
                    workSheet.Cells[linha, coluna + 2].Value = item.EndDate;
                    workSheet.Cells[linha, coluna + 3].Value = item.JobName;
                    workSheet.Cells[linha, coluna + 4].Value = item.DeptName;

                    linha++;
                }

                #endregion

                #region Stream
                workSheet.Cells.AutoFitColumns();
                pck.SaveAs(stream);

                Response.Clear();
                Response.ContentType = "application/force-download";
                Response.AddHeader("content-disposition", "attachment; filename=HistFunc.xlsx");
                Response.BinaryWrite(stream.ToArray());
                Response.End();
                #endregion
            }
        }

        #endregion

        #endregion
    }
}