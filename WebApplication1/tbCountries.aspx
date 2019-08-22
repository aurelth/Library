<%@ Page Title="" Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="tbCountries.aspx.cs" Inherits="WebApplication1.tbCountries" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function validaLetras() {
            var strNomeC = document.getElementById("MainContent_txtNomePais").value
            var strIdC = document.getElementById("MainContent_txtCodPais").value
            if (strIdC.length === 0) {
                alert("O Código do país não pode estar vazio!!");
                return false;
            }
            else if (strNomeC.length === 0) {
                alert("O Nome do país não pode estar vazio!!");
                return false;
            } else {
                firstModified = document.lastModified;
                return true;
            }
        }
    </script>
    <div>
        <asp:Panel ID="pnlEditInsert" runat="server" Visible="false">
            <br />
            <asp:Label Text="Código do Pais" runat="server" />
            <asp:TextBox ID="txtCodPais" runat="server" MaxLength="2" Enabled="false" />
            <br />
            <asp:Label Text="Nome do Pais" runat="server" />
            <asp:TextBox ID="txtNomePais" runat="server" MaxLength="40" />
            <br />
            <asp:Label Text="Região" runat="server" />
            <asp:DropDownList ID="ddlNomeRegiao" runat="server" Width="300" Height="20" DataTextField="RegionName" DataValueField="RegionId"></asp:DropDownList>
            <hr />
            <asp:Button ID="btnEditSave" Text="Salvar" runat="server" OnClick="btnEditSave_Click" OnClientClick="return validaLetras()" />
        </asp:Panel>
        <asp:LinkButton ID="lbtAdcionar" Text="(+) Adicionar novo País" runat="server" OnClick="lbtAdcionar_Click" />
        <asp:LinkButton ID="lbtExportarExcel" Text="Exportar Para Excel" runat="server"
            OnClick="lbtExportarExcel_Click" />
        <asp:Repeater ID="rptCountry" runat="server">
            <HeaderTemplate>
                <table>
                    <tr class="tableTitle">
                        <th>Ações</th>
                        <th>Código</th>
                        <th>País</th>
                        <th>Região</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:LinkButton ID="lbtEditar" Text="Editar" runat="server"
                            CommandArgument='<%# DataBinder.Eval(Container.DataItem,"CountryId") %>'
                            OnCommand="lbtEditar_Command" />
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "CountryId") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "CountryName") %>
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
