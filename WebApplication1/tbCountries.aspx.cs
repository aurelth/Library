using System;
using BO;
using Entities;
using System.Linq;
using System.Web.UI.WebControls;
using OfficeOpenXml;
using System.IO;
using System.Data;
using OfficeOpenXml.Style;
using System.Drawing;

namespace WebApplication1
{
    public partial class tbCountries : System.Web.UI.Page
    {

        #region MetodosPrivate
        private bool Inserir
        {
            get { return Convert.ToBoolean(Session["Inserir"]); }
            set { Session["Inserir"] = value; }
        }

        private void CarregaRepeatCountry()
        {
            CountryBO dataset = new CountryBO();
            var dados = dataset.ObterCountry();
            rptCountry.DataSource = dados;
            rptCountry.DataBind();
        }

        private void LimparCampos()
        {
            txtCodPais.Text = "";
            txtNomePais.Text = "";
            ddlNomeRegiao.SelectedIndex = 1;
        }

        private void CarregaddlRegiao()
        {
            RegionBO setdados = new RegionBO();
            var dado = setdados.ObterListaRegion();
            ddlNomeRegiao.DataSource = dado;
            ddlNomeRegiao.DataBind();
        }

        #endregion

        #region MetodosProtected

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CarregaRepeatCountry();
        }

        protected void lbtEditar_Command(object sender, CommandEventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            pnlEditInsert.Visible = true;
            CountryBO dataset = new CountryBO();
            CountryBE dados = new CountryBE();

            CarregaddlRegiao();

            dados = dataset.ObterCountry((btn.CommandArgument).ToString()).First();
            txtCodPais.Text = dados.CountryId;
            txtNomePais.Text = dados.CountryName;
            ddlNomeRegiao.SelectedValue = dados.RegionID;
        }

        #region Click

        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            var dataset = new CountryBO();

            if (Inserir)
            {
                dataset.SalvarCountry(txtCodPais.Text.ToUpper(), txtNomePais.Text, Convert.ToInt32(ddlNomeRegiao.SelectedValue));
                btnEditSave.Text = "Salvar";
                Inserir = false;
                txtCodPais.Enabled = false;
            }
            else
            {
                dataset.AlterarCountry(txtCodPais.Text.ToUpper(), txtNomePais.Text, Convert.ToInt16(ddlNomeRegiao.SelectedValue));
            }
            CarregaRepeatCountry();
            LimparCampos();
            pnlEditInsert.Visible = false;
        }

        protected void lbtAdcionar_Click(object sender, EventArgs e)
        {
            CarregaddlRegiao();
            LimparCampos();
            txtCodPais.Enabled = true;
            pnlEditInsert.Visible = true;
            Inserir = true;
            Button btn = (Button)pnlEditInsert.FindControl("btnEditSave");
            btn.Text = "Inserir";
        }

        protected void lbtExportarExcel_Click(object sender, EventArgs e)
        {
            CountryBO dataset = new CountryBO();
            var colecao = dataset.ObterCountry().AsEnumerable();

            MemoryStream stream = new MemoryStream();

            using (ExcelPackage pck = new ExcelPackage())
            {
                int linha = 2;
                int coluna = 1;
                string content = string.Format("A1:C{0}", colecao.Count() + 1);

                ExcelWorksheet workSheet = pck.Workbook.Worksheets.Add("Paises");

                #region Formatador
                workSheet.Cells[content].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                workSheet.Cells[content].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[content].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[content].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[content].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                #endregion

                #region Cabecalho
                workSheet.Cells["A1:C1"].Style.Font.Bold = true;
                workSheet.Cells["A1:C1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["A1:C1"].Style.Fill.BackgroundColor.SetColor(Color.WhiteSmoke);
                workSheet.Cells["A1"].Value = "Código";
                workSheet.Cells["B1"].Value = "Pais";
                workSheet.Cells["C1"].Value = "Região";
                #endregion

                #region Dados

                foreach (var item in colecao)
                {
                    workSheet.Cells[linha, coluna].Value = item.CountryId;
                    workSheet.Cells[linha, coluna + 1].Value = item.CountryName;
                    workSheet.Cells[linha, coluna + 2].Value = item.RegionName;

                    linha++;
                }

                #endregion

                #region Stream
                workSheet.Cells.AutoFitColumns();
                pck.SaveAs(stream);

                Response.Clear();
                Response.ContentType = "application/force-download";
                Response.AddHeader("content-disposition", "attachment; filename=Pais Exportação.xlsx");
                Response.BinaryWrite(stream.ToArray());
                Response.End();
                #endregion
            }
        }

        #endregion
        #endregion
    }
}