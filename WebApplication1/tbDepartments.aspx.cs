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
    public partial class tbDepartment : Page
    {
        #region Metodos Private
        private bool Inserir
        {
            get { return Convert.ToBoolean(Session["Inserir"]); }
            set { Session["Inserir"] = value; }
        }

        private void CarregaRepeatLocation()
        {
            DepartmentBO setadados = new DepartmentBO();
            var dados = setadados.ObterDepart();
            rptDepart.DataSource = dados;
            rptDepart.DataBind();
        }

        private void LimparCampos()
        {
            txtCodDepart.Text = "";
            txtNomeDepart.Text = "";
            ddlCodManag.SelectedIndex = 1;
            ddlLocal.SelectedIndex = 1;

        }

        private void CarregaddlLocation()
        {
            LocationBO setadado = new LocationBO();
            var dado = setadado.ObterLocation();
            ddlLocal.DataSource = dado;
            ddlLocal.DataBind();
        }

        private void CarregaddlManager()
        {
            EmployeeBE employee = new EmployeeBE();
            employee.LastName = "Não possui Manager";
            employee.EmpId = 1;
            DepartmentBO setadados = new DepartmentBO();
            var dado = setadados.ObterEmployee();
            dado.Add(employee);
            ddlCodManag.DataSource = dado;
            ddlCodManag.DataBind();
        }
        #endregion

        #region Metodos Protected

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaRepeatLocation();
                CarregaddlLocation();
                CarregaddlManager();
            }
        }

        protected void lbtEditar_Command(object sender, CommandEventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            pnlEditInsert.Visible = true;
            DepartmentBO dataset = new DepartmentBO();
            DepartmentBE dados = new DepartmentBE();

            LimparCampos();
            CarregaddlLocation();
            CarregaddlManager();

            dados = dataset.ObterDepart(Convert.ToInt16(btn.CommandArgument)).First();
            txtCodDepart.Text = dados.DepId.ToString();
            txtNomeDepart.Text = dados.DepName;
            if (dados.ManagID != 0)
            {
                ddlCodManag.SelectedValue = dados.ManagID.ToString();
            }
            else
            {
                ddlCodManag.SelectedValue = "1";
            }
            ddlLocal.SelectedValue = dados.LocatId.ToString();
        }

        #region Click

        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            var dataset = new DepartmentBO();

            if (Inserir)
            {
                if (ddlCodManag.SelectedValue != "1")
                {
                    dataset.SalvarDepart(txtNomeDepart.Text, Convert.ToInt16(ddlLocal.SelectedValue), Convert.ToInt16(ddlCodManag.SelectedValue));
                }
                else
                {
                   dataset.SalvarDepart(txtNomeDepart.Text, Convert.ToInt16(ddlLocal.SelectedValue));
                }
                btnEditSave.Text = "Salvar";
                Inserir = false;
                txtCodDepart.Enabled = false;
            }
            else
            {
                if (ddlCodManag.SelectedValue != "1")
                {
                    dataset.AlterarDepart(Convert.ToInt16(txtCodDepart.Text), txtNomeDepart.Text, Convert.ToInt16(ddlLocal.SelectedValue), Convert.ToInt16(ddlCodManag.SelectedValue));
                }
                else
                {     
                   dataset.AlterarDepart(Convert.ToInt16(txtCodDepart.Text), txtNomeDepart.Text, Convert.ToInt16(ddlLocal.SelectedValue));
                }
            }
            CarregaRepeatLocation();
            LimparCampos();
            pnlEditInsert.Visible = false;
        }

        protected void lbtAdcionar_Click(object sender, EventArgs e)
        {
            CarregaddlLocation();
            CarregaddlManager();
            lbCodDepart.Visible = false;
            txtCodDepart.Enabled = false;
            txtCodDepart.Text = "ID definido automaticamente pelo sistema";
            pnlEditInsert.Visible = true;
            Inserir = true;
            Button btn = btnEditSave;
            btn.Text = "Inserir";
        }

        protected void lbtExportarExcel_Click(object sender, EventArgs e)
        {
            DepartmentBO dataset = new DepartmentBO();
            var colecao = dataset.ObterDepart().AsEnumerable();

            MemoryStream stream = new MemoryStream();

            using (ExcelPackage pck = new ExcelPackage())
            {
                int linha = 2;
                int coluna = 1;
                string content = string.Format("A1:D{0}", colecao.Count() + 1);

                ExcelWorksheet workSheet = pck.Workbook.Worksheets.Add("Departamentos");

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
                workSheet.Cells["B1"].Value = "Departamento";
                workSheet.Cells["C1"].Value = "Manager";
                workSheet.Cells["D1"].Value = "Localidade";
                #endregion

                #region Dados

                foreach (var item in colecao)
                {
                    workSheet.Cells[linha, coluna].Value = item.DepId;
                    workSheet.Cells[linha, coluna + 1].Value = item.DepName;
                    workSheet.Cells[linha, coluna + 2].Value = item.ManagName;
                    workSheet.Cells[linha, coluna + 3].Value = item.LocatName;

                    linha++;
                }

                #endregion

                #region Stream
                workSheet.Cells.AutoFitColumns();
                pck.SaveAs(stream);

                Response.Clear();
                Response.ContentType = "application/force-download";
                Response.AddHeader("content-disposition", "attachment; filename=Departamentos.xlsx");
                Response.BinaryWrite(stream.ToArray());
                Response.End();
                #endregion
            }
        }

        #endregion

        #endregion
    }
}