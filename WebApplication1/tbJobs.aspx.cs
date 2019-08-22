using System;
using Entities;
using BO;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;

namespace WebApplication1
{
    public partial class tbJob : Page
    {
        #region Metodos Private
        private bool Inserir
        {
            get { return Convert.ToBoolean(Session["Inserir"]); }
            set { Session["Inserir"] = value; }
        }

        private void CarregaRepeatJob()
        {
            JobBO setadados = new JobBO();
            var dados = setadados.ObterJob();
            rptJob.DataSource = dados;
            rptJob.DataBind();
        }

        private void LimparCampos()
        {
            txtCodJob.Text = "";
            txtNomeJob.Text = "";
            txtMinSal.Text = "";
            txtMaxSal.Text = "";

        }

        #endregion

        #region Metodos Protected

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CarregaRepeatJob();
        }

        protected void lbtEditar_Command(object sender, CommandEventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            pnlEditInsert.Visible = true;
            JobBO dataset = new JobBO();
            JobBE dados = new JobBE();

            LimparCampos();

            dados = dataset.ObterJob(btn.CommandArgument).First();
            txtCodJob.Text = dados.JobId;
            txtNomeJob.Text = dados.JobName ;
            txtMinSal.Text = dados.SalaryMin.ToString();
            txtMaxSal.Text = dados.SalaryMax.ToString();
        }

        #region Click

        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            JobBO dataset = new JobBO();

            if (Inserir)
            {
                dataset.SalvarJob(txtCodJob.Text, txtNomeJob.Text, Convert.ToInt32(txtMinSal.Text), Convert.ToInt32(txtMaxSal.Text));
                btnEditSave.Text = "Salvar";
                Inserir = false;
                txtCodJob.Enabled = false;
            }
            else
            {
                dataset.AlterarJob(txtCodJob.Text, txtNomeJob.Text, Convert.ToInt16(txtMinSal.Text), Convert.ToInt16(txtMaxSal.Text));
            }
            CarregaRepeatJob();
            LimparCampos();
            pnlEditInsert.Visible = false;
        }

        protected void lbtAdcionar_Click(object sender, EventArgs e)
        {
            txtCodJob.Enabled = true;
            pnlEditInsert.Visible = true;
            Inserir = true;
            btnEditSave.Text = "Inserir";
        }

        protected void lbtExportarExcel_Click(object sender, EventArgs e)
        {
            JobBO dataset = new JobBO();
            var colecao = dataset.ObterJob().AsEnumerable();

            MemoryStream stream = new MemoryStream();

            using (ExcelPackage pck = new ExcelPackage())
            {
                int linha = 2;
                int coluna = 1;
                string content = string.Format("A1:D{0}", colecao.Count() + 1);

                ExcelWorksheet workSheet = pck.Workbook.Worksheets.Add("Jobs");

                #region Formatador
                workSheet.Cells[content].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                workSheet.Cells[content].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[content].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[content].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[content].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                #endregion

                #region Cabecalho
                workSheet.Cells["A1:D1"].Style.Font.Bold = true;
                workSheet.Cells["A1:D1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["A1:D1"].Style.Fill.BackgroundColor.SetColor(Color.WhiteSmoke);
                workSheet.Cells["A1"].Value = "Código";
                workSheet.Cells["B1"].Value = "Job";
                workSheet.Cells["C1"].Value = "Salário Máximo";
                workSheet.Cells["D1"].Value = "Salário Mínimo";
                #endregion

                #region Dados

                foreach (var item in colecao)
                {
                    workSheet.Cells[linha, coluna].Value = item.JobId;
                    workSheet.Cells[linha, coluna + 1].Value = item.JobName;
                    workSheet.Cells[linha, coluna + 2].Value = item.SalaryMin;
                    workSheet.Cells[linha, coluna + 3].Value = item.SalaryMax;

                    linha++;
                }

                #endregion

                #region Stream
                workSheet.Cells.AutoFitColumns();
                pck.SaveAs(stream);

                Response.Clear();
                Response.ContentType = "application/force-download";
                Response.AddHeader("content-disposition", "attachment; filename=Jobs.xlsx");
                Response.BinaryWrite(stream.ToArray());
                Response.End();
                #endregion
            }
        }

        #endregion

        #endregion
    }
}