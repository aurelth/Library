using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAO;
using Entities;

namespace WebApplication1.Tabelas
{
    public partial class TableCSharp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CriarTabela();
        }

        protected void CriarTabela()
        {
            var dataSet = new RegionDAO();
            List<RegionBE> dados = new List<RegionBE>();

            dados = dataSet.ObterRegion();

            Table tabela = new Table();

            #region Cabecalho

           
            TableHeaderRow linhaTitulo = new TableHeaderRow();

            TableHeaderCell celulaTituloID = new TableHeaderCell();
            TableHeaderCell celulaTituloNome = new TableHeaderCell();

            linhaTitulo.CssClass = "tableTitle";


            celulaTituloID.Text = "Código da Região";
            celulaTituloNome.Text = "Nome da Região";

            linhaTitulo.Controls.Add(celulaTituloID);
            linhaTitulo.Controls.Add(celulaTituloNome);

            tabela.Controls.Add(linhaTitulo);

            #endregion

            #region Linha
            
            foreach (var item in dados)
            {
                TableRow linha = new TableRow();

                TableCell celulaID = new TableCell();
                TableCell celulaNome = new TableCell();

                celulaID.Text = item.RegionID.ToString();
                celulaNome.Text = item.RegionName;

                linha.Controls.Add(celulaID);
                linha.Controls.Add(celulaNome);

                tabela.Controls.Add(linha);
            }

            #endregion

            phlTabelaRegions.Controls.Add(tabela);
        }
    }
}