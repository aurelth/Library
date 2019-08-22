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
using System.Globalization;
using System.Threading;

namespace WebApplication1
{
    public partial class tbEmployees : Page
    {
        #region Metodos Private
        private bool Inserir
        {
            get { return Convert.ToBoolean(Session["Inserir"]); }
            set { Session["Inserir"] = value; }
        }

        private void CarregaRepeatEmployee()
        {
            EmployeeBO setadados = new EmployeeBO();
            var dados = setadados.ObterEmployee();
            rptEmployees.DataSource = dados;
            rptEmployees.DataBind();
        }

        private void LimparCampos()
        {
            txtPrimNome.Text = "";
            txtSegNome.Text = "";
            txtEmail.Text = "";
            txtFone.Text = "";
            txtComissao.Text = "";
            txtSal.Text = "";
            ddlJobs.SelectedIndex = 1;
            ddlMng.SelectedIndex = 1;
            ddlDpt.SelectedIndex = 1;
            cldDiaCont.SelectedDate = DateTime.Now;
            cldDiaCont.VisibleDate = DateTime.Now;
        }

        private void CarregaddlDepartament()
        {
            DepartmentBO setadado = new DepartmentBO();
            var dado = setadado.ObterDepart();
            ddlDpt.DataSource = dado;
            ddlDpt.DataBind();
        }

        private void CarregaddlManager()
        {
            EmployeeBE employee = new EmployeeBE();
            employee.LastName = "Não possui Manager";
            employee.EmpId = 1;

            EmployeeBO setadados = new EmployeeBO();
            var dado = setadados.ObterEmployee();
            dado.Add(employee);
            ddlMng.DataSource = dado;
            ddlMng.DataBind();
        }

        private void CarregaddlJobs()
        {
            JobBO seta = new JobBO();
            var dado = seta.ObterJob();
            ddlJobs.DataSource = dado;
            ddlJobs.DataBind();

        }

        private bool VerifSalario()
        {
            int valorSal = Convert.ToInt32(txtSal.Text);
            int maxSal = Convert.ToInt32(lbMaxSal.Text);
            int minSal = Convert.ToInt32(lbMinSal.Text);

            if (valorSal < minSal || valorSal > maxSal)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private bool CommIsNull()
        {
            if (txtComissao.Text.Length == 0)
            {
                return false;
            };
            return true;
        }
        #endregion

        #region Metodos Protected

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregaRepeatEmployee();
                CarregaddlDepartament();
                CarregaddlManager();
                CarregaddlJobs();
            }
        }

        protected void ddlJobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlJobs.Text == "AD_PRES")
            {
                ddlMng.SelectedValue = "1";
                ddlMng.Enabled = false;
                txtComissao.Text = "";
                txtComissao.Enabled = false;
            }


            JobBO set = new JobBO();
            var job = set.ObterJob(ddlJobs.SelectedValue);
            lbMaxSal.Text = job[0].SalaryMax.ToString();
            lbMinSal.Text = job[0].SalaryMin.ToString();
        }

        protected void lbtEditar_Command(object sender, CommandEventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            pnlEditInsert.Visible = true;
            EmployeeBO dataset = new EmployeeBO();
            EmployeeBE dados = new EmployeeBE();

            CarregaddlDepartament();
            CarregaddlManager();
            CarregaddlJobs();
            LimparCampos();

            dados = dataset.ObterEmployee(Convert.ToInt16(btn.CommandArgument)).First();
            txtCodEmp.Text = dados.EmpId.ToString();
            txtPrimNome.Text = dados.FirstName;
            txtSegNome.Text = dados.LastName;
            txtEmail.Text = dados.Email;
            txtFone.Text = dados.FoneNum;
            txtComissao.Text = dados.Comissao.ToString();
            ddlJobs.SelectedValue = dados.JobId;
            cldDiaCont.SelectedDate = Convert.ToDateTime(dados.HireDate);
            cldDiaCont.VisibleDate = Convert.ToDateTime(dados.HireDate);
            if (dados.MngId != 0)
            {
                ddlMng.SelectedValue = dados.MngId.ToString();
            }
            txtSal.Text = dados.Salary.ToString();
            lbMaxSal.Text = dados.MaxSalary.ToString();
            lbMinSal.Text = dados.Minsalary.ToString();
            ddlDpt.SelectedValue = dados.DptId.ToString();
        }

        #region Click

        protected void btnEditSave_Click(object sender, EventArgs e)
        {
            var dataset = new EmployeeBO();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-FR");

            if (Inserir && VerifSalario())
            {
                if (CommIsNull())
                {
                    dataset.SalvarEmployees(txtPrimNome.Text, txtSegNome.Text, txtEmail.Text, txtFone.Text, cldDiaCont.SelectedDate, ddlJobs.SelectedValue, Convert.ToInt32(txtSal.Text), Convert.ToInt32(txtComissao.Text), Convert.ToInt32(ddlMng.SelectedValue), Convert.ToInt32(ddlDpt.SelectedValue));
                }
                else
                {
                    dataset.SalvarEmployees(txtPrimNome.Text, txtSegNome.Text, txtEmail.Text, txtFone.Text, cldDiaCont.SelectedDate, ddlJobs.SelectedValue, Convert.ToInt32(txtSal.Text), Convert.ToInt32(ddlMng.SelectedValue), Convert.ToInt32(ddlDpt.SelectedValue));
                }
                btnEditSave.Text = "Salvar";
                Inserir = false;
            }
            else if (VerifSalario())
            {
                if (ddlJobs.Text == "AD_PRES")
                {
                    dataset.AlterarEmployees(Convert.ToInt32(txtCodEmp.Text), txtPrimNome.Text, txtSegNome.Text, txtEmail.Text, txtFone.Text, cldDiaCont.SelectedDate, ddlJobs.SelectedValue, Convert.ToInt32(txtSal.Text), Convert.ToInt32(ddlDpt.SelectedValue));
                }
                else
                {
                    if (CommIsNull())
                    {
                        dataset.AlterarEmployees(Convert.ToInt32(txtCodEmp.Text), txtPrimNome.Text, txtSegNome.Text, txtEmail.Text, txtFone.Text, cldDiaCont.SelectedDate, ddlJobs.SelectedValue, Convert.ToInt32(txtSal.Text), Convert.ToInt32(txtComissao.Text), Convert.ToInt32(ddlMng.SelectedValue), Convert.ToInt32(ddlDpt.SelectedValue));
                    }
                    else
                    {
                        dataset.AlterarEmployees(Convert.ToInt32(txtCodEmp.Text), txtPrimNome.Text, txtSegNome.Text, txtEmail.Text, txtFone.Text, cldDiaCont.SelectedDate, ddlJobs.SelectedValue, Convert.ToInt32(txtSal.Text), Convert.ToInt32(ddlMng.SelectedValue), Convert.ToInt32(ddlDpt.SelectedValue));
                    }
                }

            }
            CarregaRepeatEmployee();
            LimparCampos();
            pnlEditInsert.Visible = false;
        }

        protected void lbtAdcionar_Click(object sender, EventArgs e)
        {
            CarregaddlDepartament();
            CarregaddlManager();
            CarregaddlJobs();
            LimparCampos();
            txtCodEmp.Text = "O Código é Implementado automaticamente pelo sistema";
            pnlEditInsert.Visible = true;
            Inserir = true;
            Button btn = btnEditSave;
            btn.Text = "Inserir";
        }

        protected void lbtExportarExcel_Click(object sender, EventArgs e)
        {
            EmployeeBO dataset = new EmployeeBO();
            var colecao = dataset.ObterEmployee().AsEnumerable();

            MemoryStream stream = new MemoryStream();

            using (ExcelPackage pck = new ExcelPackage())
            {
                int linha = 2;
                int coluna = 1;
                string content = string.Format("A1:J{0}", colecao.Count() + 1);

                ExcelWorksheet workSheet = pck.Workbook.Worksheets.Add("Colaboradores");

                #region Formatador
                workSheet.Cells[content].Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                workSheet.Cells[content].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[content].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[content].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                workSheet.Cells[content].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                #endregion

                #region Cabecalho
                workSheet.Cells["A1:K1"].Style.Font.Bold = true;
                workSheet.Cells["A1:K1"].Style.Fill.PatternType = ExcelFillStyle.Solid;
                workSheet.Cells["A1:K1"].Style.Fill.BackgroundColor.SetColor(Color.WhiteSmoke);
                workSheet.Cells["A1"].Value = "Código";
                workSheet.Cells["B1"].Value = "Nome Completo";
                workSheet.Cells["C1"].Value = "Email";
                workSheet.Cells["D1"].Value = "Número Fone";
                workSheet.Cells["E1"].Value = "Data da Contratação";
                workSheet.Cells["F1"].Value = "Função";
                workSheet.Cells["G1"].Value = "Salário";
                workSheet.Cells["H1"].Value = "Comissão";
                workSheet.Cells["I1"].Value = "Código Manager";
                workSheet.Cells["J1"].Value = "Departamento";

                #endregion

                #region Dados

                foreach (var item in colecao)
                {
                    workSheet.Cells[linha, coluna].Value = item.EmpId;
                    workSheet.Cells[linha, coluna + 1].Value = item.FirstName + " " + item.LastName;
                    workSheet.Cells[linha, coluna + 2].Value = item.Email;
                    workSheet.Cells[linha, coluna + 3].Value = item.FoneNum;
                    workSheet.Cells[linha, coluna + 4].Value = item.HireDate.ToString();
                    workSheet.Cells[linha, coluna + 5].Value = item.JobName;
                    workSheet.Cells[linha, coluna + 6].Value = item.Salary.ToString();
                    workSheet.Cells[linha, coluna + 7].Value = item.Comissao.ToString();
                    workSheet.Cells[linha, coluna + 8].Value = item.MngId.ToString();
                    workSheet.Cells[linha, coluna + 9].Value = item.DptNome;

                    linha++;
                }

                #endregion

                #region Stream
                workSheet.Cells.AutoFitColumns();
                pck.SaveAs(stream);

                Response.Clear();
                Response.ContentType = "application/force-download";
                Response.AddHeader("content-disposition", "attachment; filename=Employees.xlsx");
                Response.BinaryWrite(stream.ToArray());
                Response.End();
                #endregion
            }
        }

        #endregion

        #endregion
    }
}