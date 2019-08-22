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
    public partial class tbLocations : System.Web.UI.Page
    {
        #region Metodos Private
        private bool Inserir
        {
            get { return Convert.ToBoolean(Session["Inserir"]); }
            set { Session["Inserir"] = value; }
        }

        private void CarregaRepeatLocation()
        {
            LocationBO setadados = new LocationBO();
            var dados = setadados.ObterLocation();
            rptLocation.DataSource = dados;
            rptLocation.DataBind();
        }

        private void LimparCampos()
        {
            txtCodLoc.Text = "";
            txtEndereco.Text = "";
            txtCodPost.Text = "";
            txtCity.Text = "";
            txtState.Text = "";
            ddlCountry.SelectedIndex = 1;
        }

        private void CarregaddlPais()
        {
            CountryBO setadado = new CountryBO();
            var dado = setadado.ObterCountry();
            ddlCountry.DataSource = dado;
            ddlCountry.DataBind();
        }
        #endregion

        #region Metodos Protected

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CarregaRepeatLocation();

        }

        protected void lbtEditar_Command(object sender, CommandEventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            pnlEditInsert.Visible = true;
            LocationBO dataset = new LocationBO();
            LocationBE dados = new LocationBE();

            CarregaddlPais();

            dados = dataset.ObterLocation(Convert.ToInt16(btn.CommandArgument)).First();
            txtCodLoc.Text = dados.LocationId.ToString();
            txtEndereco.Text = dados.StreetAddress;
            txtCodPost.Text = dados.PostalCod;
            txtCity.Text = dados.City;
            txtState.Text = dados.State;
            ddlCountry.SelectedValue = dados.CountryId;
        }
        
        #region Click

        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            var dataset = new LocationBO();

            if (Inserir)
            {
                dataset.SalvarLocation(txtEndereco.Text, txtCodPost.Text, txtCity.Text, txtState.Text, ddlCountry.SelectedValue);
                btnEditSave.Text = "Salvar";
                Inserir = false;
                txtCodLoc.Enabled = false;
            }
            else
            {
                dataset.AlterarLocation(Convert.ToInt16(txtCodLoc.Text), txtEndereco.Text, txtCodPost.Text, txtCity.Text, txtState.Text, ddlCountry.SelectedValue);
            }
            CarregaRepeatLocation();
            LimparCampos();
            pnlEditInsert.Visible = false;
        }

        protected void lbtAdcionar_Click(object sender, EventArgs e)
        {
            CarregaddlPais();
            lbCodloc.Visible = false;
            txtCodLoc.Visible = false;
            pnlEditInsert.Visible = true;
            Inserir = true;
            Button btn = btnEditSave;
            btn.Text = "Inserir";
        }

        protected void lbtExportarExcel_Click(object sender, EventArgs e)
        {
            LocationBO dataset = new LocationBO();
            var colecao = dataset.ObterLocation().AsEnumerable();

            MemoryStream stream = new MemoryStream();

            using (ExcelPackage pck = new ExcelPackage())
            {
                int linha = 2;
                int coluna = 1;
                string content = string.Format("A1:F{0}", colecao.Count() + 1);

                ExcelWorksheet workSheet = pck.Workbook.Worksheets.Add("Localidades");

                #region Formatador
                workSheet.Cells[content].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                workSheet.Cells[content].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[content].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[content].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[content].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                #endregion

                #region Cabecalho
                workSheet.Cells["A1:F1"].Style.Font.Bold = true;
                workSheet.Cells["A1:F1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["A1:F1"].Style.Fill.BackgroundColor.SetColor(Color.WhiteSmoke);
                workSheet.Cells["A1"].Value = "Código";
                workSheet.Cells["B1"].Value = "Endereço";
                workSheet.Cells["C1"].Value = "Cód. Postal";
                workSheet.Cells["D1"].Value = "Cidade";
                workSheet.Cells["E1"].Value = "Estado/Província";
                workSheet.Cells["F1"].Value = "País ";
                #endregion

                #region Dados

                foreach (var item in colecao)
                {
                    workSheet.Cells[linha, coluna].Value = item.LocationId;
                    workSheet.Cells[linha, coluna + 1].Value = item.StreetAddress;
                    workSheet.Cells[linha, coluna + 2].Value = item.PostalCod;
                    workSheet.Cells[linha, coluna + 3].Value = item.City;
                    workSheet.Cells[linha, coluna + 4].Value = item.State;
                    workSheet.Cells[linha, coluna + 5].Value = item.CountryName;

                    linha++;
                }

                #endregion

                #region Stream
                workSheet.Cells.AutoFitColumns();
                pck.SaveAs(stream);

                Response.Clear();
                Response.ContentType = "application/force-download";
                Response.AddHeader("content-disposition", "attachment; filename=Localidade.xlsx");
                Response.BinaryWrite(stream.ToArray());
                Response.End();
                #endregion
            }
        }

        #endregion

        #endregion
    }
}