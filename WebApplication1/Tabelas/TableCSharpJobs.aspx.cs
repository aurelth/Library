using System;
using System.Collections.Generic;
using Entities;
using DAO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Tabelas
{
    public partial class TableCSharpJobs : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CriarTableJ();
        }

        private void CriarTableJ()
        {
            var setdados = new JobDAO();
            List<JobBE> jobs = new List<JobBE>();

            jobs = setdados.ObterJobs();

            Table tabela = new Table();

            #region Cabeçalho
            TableHeaderRow linhaTitulo = new TableHeaderRow();

            TableHeaderCell ctJobID= new TableHeaderCell();
            TableHeaderCell ctJobName = new TableHeaderCell();
            TableHeaderCell ctMinSal= new TableHeaderCell();
            TableHeaderCell ctMaxSal = new TableHeaderCell();


            linhaTitulo.CssClass = "tableTitle";

            ctJobID.Text = "Código";
            ctJobName.Text = "Job";
            ctMinSal.Text = "Salário Mínimo";
            ctMaxSal.Text = "Salário Máximo";


            linhaTitulo.Controls.Add(ctJobID);
            linhaTitulo.Controls.Add(ctJobName);
            linhaTitulo.Controls.Add(ctMinSal);
            linhaTitulo.Controls.Add(ctMaxSal);

            tabela.Controls.Add(linhaTitulo);
            #endregion

            #region Linhas

            foreach (var item in jobs)
            {
                TableRow linha = new TableRow();

                TableCell cJobID = new TableCell();
                TableCell cJobName = new TableCell();
                TableCell cMinSal = new TableCell();
                TableCell cMaxSal = new TableCell();

                cJobID.Text = item.JobId;
                cJobName.Text = item.JobName;
                cMinSal.Text = item.SalaryMin.ToString();
                cMaxSal.Text = item.SalaryMax.ToString();

                linha.Controls.Add(cJobID);
                linha.Controls.Add(cJobName);
                linha.Controls.Add(cMinSal);
                linha.Controls.Add(cMaxSal);

                tabela.Controls.Add(linha);
            }
            #endregion

            phlTableJobs.Controls.Add(tabela);
        }
    }
}