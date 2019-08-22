using BO;
using Entities;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Regions : System.Web.UI.Page
    {
        private bool Inserir
        {
            get { return Convert.ToBoolean(Session["Inserir"]); }
            set { Session["Inserir"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            CarregaRepeaterRegion();
        }

        protected void CarregaRepeaterRegion()
        {
            var dataset = new RegionBO();
            var dados = dataset.ObterListaRegion();
            rptRegion.DataSource = dados;
            rptRegion.DataBind();
        }

        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            var dataset = new RegionBO();
            if (Inserir)
            {
                dataset.SalvarRegion(txtNomeRegião.Text);
                Button btn = (Button)pnlEditInsert.FindControl("btnEditSave");
                btn.Text = "Salvar";
                Inserir = false;
            }
            else
            {
                dataset.SalvarAlteracoesRegion(Convert.ToInt64(txtCodigo.Value), txtNomeRegião.Text);
            }
            CarregaRepeaterRegion();
            pnlEditInsert.Visible = false;
        }

        protected void lbtAdcionar_Click(object sender, EventArgs e)
        {
            pnlEditInsert.Visible = true;
            Inserir = true;
            Button btn = (Button)pnlEditInsert.FindControl("btnEditSave");
            btn.Text = "Inserir";
        }

        protected void lbtEditar_Command(object sender, CommandEventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            pnlEditInsert.Visible = true;
            var dataset = new RegionBO();
            RegionBE dados =  new RegionBE();
            dados = dataset.ObterListaRegion(Convert.ToInt32(btn.CommandArgument)).First();
            txtCodigo.Value = dados.RegionID.ToString();
            txtNomeRegião.Text = dados.RegionName.ToString();
        }

        protected void lbtExportarExcel_Click(object sender, EventArgs e)
        {
            var dataset = new RegionBO();
            DataTable dados = new DataTable();
            var colecao = dataset.ObterListaRegion().AsEnumerable();

            dados = DataTableConversor.ToDataTable<RegionBE>(colecao);

            MemoryStream stream = new MemoryStream();

            using (ExcelPackage pck = new ExcelPackage())
            {
                int linha = 2;
                int coluna = 1;
                string content = string.Format("A1:B{0}", colecao.Count()+1);

                ExcelWorksheet workSheet = pck.Workbook.Worksheets.Add("Regiões");

                #region Formatador
                workSheet.Cells[content].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                workSheet.Cells[content].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[content].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[content].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[content].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                #endregion

                #region Cabecalho
                workSheet.Cells["A1:B1"].Style.Font.Bold = true;
                workSheet.Cells["A1:B1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["A1:B1"].Style.Fill.BackgroundColor.SetColor(Color.WhiteSmoke);
                workSheet.Cells["A1"].Value = "Código da Região";
                workSheet.Cells["B1"].Value = "Região";
                #endregion

                #region Dados

                foreach (var item in colecao)
                {
                    workSheet.Cells[linha, coluna].Value = item.RegionID;
                    workSheet.Cells[linha, coluna + 1].Value = item.RegionName;
                    linha++;
                }

                #endregion

                #region Stream
                workSheet.Cells.AutoFitColumns();
                pck.SaveAs(stream);

                Response.Clear();
                Response.ContentType = "application/force-download";
                Response.AddHeader("content-disposition", "attachment; filename=Regiões Exportação.xlsx");
                Response.BinaryWrite(stream.ToArray());
                Response.End();
                #endregion
            }

           
        }
    }
}