using System;
using System.Collections.Generic;
using System.Web.UI;
using DAO;
using Entities;
using System.Web.UI.WebControls;

namespace WebApplication1.Tabelas
{
    public partial class TableCSharpLocations : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CriarTableL();
        }

        private void CriarTableL()
        {
            var setdados = new LocationDAO();
            List<LocationBE> locations = new List<LocationBE>();

            locations = setdados.ObterLocation();

            Table tabela = new Table();

            #region Cabeçalho
            TableHeaderRow linhaTitulo = new TableHeaderRow();

            TableHeaderCell ctIdLoc = new TableHeaderCell();
            TableHeaderCell ctStreet = new TableHeaderCell();
            TableHeaderCell ctPostCod = new TableHeaderCell();
            TableHeaderCell ctCity = new TableHeaderCell();
            TableHeaderCell ctState = new TableHeaderCell();
            TableHeaderCell ctNomePais= new TableHeaderCell();

            linhaTitulo.CssClass = "tableTitle";

            ctIdLoc.Text = "Código";
            ctStreet.Text = "Endereço";
            ctPostCod.Text = "Código Postal";
            ctCity.Text = "Cidade";
            ctState.Text = "Estado";
            ctNomePais.Text = "País ";

            linhaTitulo.Controls.Add(ctIdLoc);
            linhaTitulo.Controls.Add(ctStreet);
            linhaTitulo.Controls.Add(ctPostCod);
            linhaTitulo.Controls.Add(ctCity);
            linhaTitulo.Controls.Add(ctState);
            linhaTitulo.Controls.Add(ctNomePais);

            tabela.Controls.Add(linhaTitulo);
            #endregion

            #region Linhas

            foreach (var item in locations)
            {
                TableRow linha = new TableRow();

                TableCell cIdLoc = new TableCell();
                TableCell cStreet = new TableCell();
                TableCell cPostCod = new TableCell();
                TableCell cCity = new TableCell();
                TableCell cState = new TableCell();
                TableCell cNomePais = new TableCell();

                cIdLoc.Text = item.LocationId.ToString();
                cStreet.Text = item.StreetAddress;
                cPostCod.Text = item.PostalCod;
                cCity.Text = item.City;
                cState.Text = item.State;
                cNomePais.Text = item.CountryName;

                linha.Controls.Add(cIdLoc);
                linha.Controls.Add(cStreet);
                linha.Controls.Add(cPostCod);
                linha.Controls.Add(cCity);
                linha.Controls.Add(cState);
                linha.Controls.Add(cNomePais);

                tabela.Controls.Add(linha);
            }
            #endregion

            phlTableLocations.Controls.Add(tabela);
        }
    }
}