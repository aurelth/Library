using System;
using System.Collections.Generic;
using DAO;
using Entities;
using System.Web.UI.WebControls;

namespace WebApplication1.Tabelas
{
    public partial class TableCSharpJobHist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CriarTableJH();
        }

        private void CriarTableJH()
        {
            var setdados = new JobHistDAO();
            List<JobHistBE> jobHists = new List<JobHistBE>();

            jobHists = setdados.ObterJobsHist();

            Table tabela = new Table();

            #region Cabeçalho
            TableHeaderRow linhaTitulo = new TableHeaderRow();

            TableHeaderCell ctEmpName = new TableHeaderCell();
            TableHeaderCell ctStartDate = new TableHeaderCell();
            TableHeaderCell ctEndDate = new TableHeaderCell();
            TableHeaderCell ctJobName = new TableHeaderCell();
            TableHeaderCell ctDptName = new TableHeaderCell();

            linhaTitulo.CssClass = "tableTitle";

            ctEmpName.Text = "Colaborador";
            ctStartDate.Text = "Data inical";
            ctEndDate.Text = "Data final";
            ctJobName.Text = "Função Excercida";
            ctDptName.Text = "Departamento";


            linhaTitulo.Controls.Add(ctEmpName);
            linhaTitulo.Controls.Add(ctStartDate);
            linhaTitulo.Controls.Add(ctEndDate);
            linhaTitulo.Controls.Add(ctJobName);
            linhaTitulo.Controls.Add(ctDptName);

            tabela.Controls.Add(linhaTitulo);
            #endregion

            #region Linhas

            foreach (var item in jobHists)
            {
                TableRow linha = new TableRow();

                TableCell cEmpName = new TableCell();
                TableCell cStartDate = new TableCell();
                TableCell cEndDate = new TableCell();
                TableCell cJobName = new TableCell();
                TableCell cDptName = new TableCell();

                cEmpName.Text = item.EmpName.ToString();
                cStartDate.Text = item.StartDate;
                cEndDate.Text = item.EndDate;
                cJobName.Text = item.JobName;
                cDptName.Text = item.DeptName;

                linha.Controls.Add(cEmpName);
                linha.Controls.Add(cStartDate);
                linha.Controls.Add(cEndDate);
                linha.Controls.Add(cJobName);
                linha.Controls.Add(cDptName);

                tabela.Controls.Add(linha);
            }
            #endregion

            phlTableJobHist.Controls.Add(tabela);
        }
    }
}