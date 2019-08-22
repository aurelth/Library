<%@ Page Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="tbRegions.aspx.cs" Inherits="WebApplication1.Regions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">


    <script type="text/javascript">

        function validaLetras() {

            var str = document.getElementById("txtNomeRegião").value

            if (!str.match(/^[A-zÀ-ú]([A-zÀ-ú \s?]?)+$/)) {
                alert("Preencha o Nome da região somente com letras");

                return false;
            }
            else {
                firstModified = document.lastModified;
            }
        }

    </script>

    <div>

        <asp:Panel ID="pnlEditInsert" runat="server" Visible="false">
            <asp:HiddenField ID="txtCodigo" runat="server" />
            <br />
            <asp:Label Text="Nome da Região" runat="server" />
            <asp:TextBox ID="txtNomeRegião" runat="server" />
            <hr />
            <asp:Button ID="btnEditSave" Text="Salvar" runat="server" OnClick="btnEditSave_Click" OnClientClick="validaLetras();" />
        </asp:Panel>

        <asp:LinkButton ID="lbtAdcionar" Text="(+) Adicionar nova Região" runat="server" OnClick="lbtAdcionar_Click" />


        <asp:LinkButton ID="lbtExportarExcel" Text="Exportar Para Excel" runat="server"
            OnClick="lbtExportarExcel_Click" />

        <asp:Repeater ID="rptRegion" runat="server">
            <HeaderTemplate>
                <table>
                    <tr class="tableTitle">
                        <th>Ações</th>
                        <th>Código</th>
                        <th>Nome da Região</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:LinkButton ID="lbtEditar" Text="Editar" runat="server"
                            CommandArgument='<%# DataBinder.Eval(Container.DataItem,"RegionID") %>'
                            OnCommand="lbtEditar_Command" />
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "RegionID") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "RegionName") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>

        </asp:Repeater>
    </div>
</asp:Content>
