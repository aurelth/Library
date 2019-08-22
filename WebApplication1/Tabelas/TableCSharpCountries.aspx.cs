using System;
using DAO;
using Entities;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace WebApplication1.Tabelas
{
    public partial class TableCSharpCountries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CriarTable();
        }

        private void CriarTable()
        {
            var setDados = new CountryDAO();
            List<CountryBE> dados = new List<CountryBE>();

            dados = setDados.ObterCountry();

            Table tabela = new Table();

            #region Cabeçalho
            TableHeaderRow linhaTitulo = new TableHeaderRow();

            TableHeaderCell ctIdC = new TableHeaderCell();
            TableHeaderCell ctNomeC = new TableHeaderCell();
            TableHeaderCell ctNomeR = new TableHeaderCell();

            linhaTitulo.CssClass = "tableTitle";


            ctIdC.Text =   "Código";
            ctNomeC.Text = "País  ";
            ctNomeR.Text = "Região";

            linhaTitulo.Controls.Add(ctIdC);
            linhaTitulo.Controls.Add(ctNomeC);
            linhaTitulo.Controls.Add(ctNomeR);

            tabela.Controls.Add(linhaTitulo);

            #endregion
            #region Linhas

            foreach (var item in dados)
            {
                TableRow linha = new TableRow();

                TableCell cID = new TableCell();
                TableCell cNomeC = new TableCell();
                TableCell cNomeR = new TableCell();

                cID.Text = item.CountryId;
                cNomeC.Text = item.CountryName;
                cNomeR.Text = item.RegionName;

                linha.Controls.Add(cID);
                linha.Controls.Add(cNomeC);
                linha.Controls.Add(cNomeR);

                tabela.Controls.Add(linha);
            }
            #endregion

            phlTableCountries.Controls.Add(tabela);
        }
    }
}