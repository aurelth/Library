using System;
using System.Collections.Generic;
using DAO;
using Entities;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Tabelas
{
    public partial class TableCSharpDepartment : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CriarTableD();
        }

        private void CriarTableD()
        {
            var setdados = new DepartDAO();
            List<DepartmentBE> departments = new List<DepartmentBE>();

            departments = setdados.ObterDepart();

            Table tabela = new Table();

            #region Cabeçalho

            TableHeaderRow linhaTitulo = new TableHeaderRow();

            TableHeaderCell ctDpaId = new TableHeaderCell();
            TableHeaderCell ctDpaName = new TableHeaderCell();
            TableHeaderCell ctManager= new TableHeaderCell();
            TableHeaderCell ctLocalidade = new TableHeaderCell();

            linhaTitulo.CssClass = "tableTitle";

            ctDpaId.Text = "Código";
            ctDpaName.Text = "Departamento";
            ctManager.Text = "Manager";
            ctLocalidade.Text = "Localidade";

            linhaTitulo.Controls.Add(ctDpaId);
            linhaTitulo.Controls.Add(ctDpaName);
            linhaTitulo.Controls.Add(ctManager);
            linhaTitulo.Controls.Add(ctLocalidade);

            tabela.Controls.Add(linhaTitulo);
            #endregion

            #region Linhas

            foreach (var item in departments)
            {
                TableRow linha = new TableRow();

                TableCell cDpaId = new TableCell();
                TableCell cDpaName = new TableCell();
                TableCell cManager = new TableCell();
                TableCell cLocalidade = new TableCell();

                cDpaId.Text = item.DepId.ToString();
                cDpaName.Text = item.DepName;
                cManager.Text = item.ManagName;
                cLocalidade.Text = item.LocatName;

                linha.Controls.Add(cDpaId);
                linha.Controls.Add(cDpaName);
                linha.Controls.Add(cManager);
                linha.Controls.Add(cLocalidade);

                tabela.Controls.Add(linha);
            }
            #endregion

            phlTableDepartment.Controls.Add(tabela);
        }
    }
}