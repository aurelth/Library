using System;
using System.Collections.Generic;
using Entities;
using DAO;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WebApplication1.Tabelas
{
    public partial class TableCSharpEmployees : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CriarTableEmp();
        }

        private void CriarTableEmp()
        {
            EmployeeDAO setDados = new EmployeeDAO();
            List<EmployeeBE> employees = new List<EmployeeBE>();

            employees = setDados.ObterEmployees();

            Table tabela = new Table();

            #region Cabeçalho

            TableHeaderRow linhaTitulo = new TableHeaderRow();

            TableHeaderCell ctEmpId = new TableHeaderCell();
            TableHeaderCell ctName = new TableHeaderCell();
            TableHeaderCell ctEmail = new TableHeaderCell();
            TableHeaderCell ctFoneNum = new TableHeaderCell();
            TableHeaderCell ctHireDate = new TableHeaderCell();
            TableHeaderCell ctJobName = new TableHeaderCell();
            TableHeaderCell ctSalary = new TableHeaderCell();
            TableHeaderCell ctComm = new TableHeaderCell();
            TableHeaderCell ctMngId = new TableHeaderCell();
            TableHeaderCell ctDptName = new TableHeaderCell();

            linhaTitulo.CssClass = "tableTitle";

            ctEmpId.Text = "Código";
            ctName.Text = "Nome Completo";
            ctEmail.Text = "Email";
            ctFoneNum.Text = "Número Fone";
            ctHireDate.Text = "Data da Contratação";
            ctJobName.Text = "Função";
            ctSalary.Text = "Salário";
            ctComm.Text = "Comissão";
            ctMngId.Text = "Código Manager";
            ctDptName.Text = "Departamento";

            linhaTitulo.Controls.Add(ctEmpId);
            linhaTitulo.Controls.Add(ctName);
            linhaTitulo.Controls.Add(ctEmail);
            linhaTitulo.Controls.Add(ctFoneNum);
            linhaTitulo.Controls.Add(ctHireDate);
            linhaTitulo.Controls.Add(ctJobName);
            linhaTitulo.Controls.Add(ctSalary);
            linhaTitulo.Controls.Add(ctComm);
            linhaTitulo.Controls.Add(ctMngId);
            linhaTitulo.Controls.Add(ctDptName);

            tabela.Controls.Add(linhaTitulo);
            #endregion

            #region Linhas

            foreach (var item in employees)
            {
                TableRow row = new TableRow();

                TableCell cEmpId = new TableCell();
                TableCell cName = new TableCell();
                TableCell cEmail = new TableCell();
                TableCell cFoneNum = new TableCell();
                TableCell cHireDate = new TableCell();
                TableCell cJobName = new TableCell();
                TableCell cSalary = new TableCell();
                TableCell cComm = new TableCell();
                TableCell cMngId = new TableCell();
                TableCell cDptName = new TableCell();

                cEmpId.Text = item.EmpId.ToString();
                cName.Text = item.FirstName + " " + item.LastName;             
                cEmail.Text = item.Email;
                cFoneNum.Text = item.FoneNum;
                cHireDate.Text = item.HireDate.ToString();
                cJobName.Text = item.JobName;
                cSalary.Text = item.Salary.ToString();
                cComm.Text = item.Comissao.ToString();
                cMngId.Text = item.MngId.ToString();
                cDptName.Text = item.DptNome;

                row.Controls.Add(cEmpId);
                row.Controls.Add(cName);
                row.Controls.Add(cEmail);
                row.Controls.Add(cFoneNum);
                row.Controls.Add(cHireDate);
                row.Controls.Add(cJobName);
                row.Controls.Add(cSalary);
                row.Controls.Add(cComm);
                row.Controls.Add(cMngId);
                row.Controls.Add(cDptName);

                tabela.Controls.Add(row);

            }

            #endregion

            phlTableEmployees.Controls.Add(tabela);

        }
    }
}