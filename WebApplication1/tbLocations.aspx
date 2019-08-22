<%@ Page Title="" Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="tbLocations.aspx.cs" Inherits="WebApplication1.tbLocations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function validaLetras() {      
            var Endereco = document.getElementById("MainContent_txtEndereco").value
            var LocId = document.getElementById("MainContent_txtCodLoc").value
            var CodPost = document.getElementById("MainContent_txtCodPost").value
            var Cidade = document.getElementById("MainContent_txtCity").value
            var State = document.getElementById("MainContent_txtState").value
            if (LocId.length === 0) {
                alert("O Código do local não pode estar vazio!!");
                return false;
            } else if (Endereco.length === 0) {
                alert("O Nome do local não pode estar vazio!!");
                return false;
            } else if (CodPost.length === 0) {
                alert("O Código Postal não pode estar vazio!!");
                return false;
            } else if (Cidade.length === 0) {
                alert("O Nome da cidade não pode estar vazio!!");
                return false;
            } else if (State.length === 0) {
                alert("O Nome do estado/província não pode estar vazio!!");
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
            <asp:Label ID="lbCodloc" Text="Código do local  " runat="server" />
            <asp:TextBox ID="txtCodLoc" runat="server" />
            <br />
            <asp:Label Text="Endereço         " runat="server" />
            <asp:TextBox ID="txtEndereco"  runat="server" MaxLength="40"/>
            <br />
            <asp:Label Text="Codigo Postal    " runat="server" />
            <asp:TextBox ID="txtCodPost" runat="server" MaxLength="12"/>
            <br />
            <asp:Label Text="Cidade           " runat="server" />
            <asp:TextBox ID="txtCity" runat="server" MaxLength="30"/>
            <br />
            <asp:Label Text="Estado/Província " runat="server" />
            <asp:TextBox ID="txtState"  runat="server" MaxLength="25"/>
            <br />
            <asp:Label Text="País             " runat="server"/>
            <asp:DropDownList ID="ddlCountry" runat="server" Width="300" Height="20" DataTextField="CountryName" DataValueField="CountryId"></asp:DropDownList>
            <hr />
            <asp:Button ID="btnEditSave" Text="Salvar" runat="server" OnClick="btnEditSave_Click" />
        </asp:Panel>
        <asp:LinkButton ID="lbtAdcionar" Text="(+) Adicionar nova locação" runat="server" OnClick="lbtAdcionar_Click" OnClientClick="return validaLetras()"/>
        <asp:LinkButton ID="lbtExportarExcel" Text="Exportar Para Excel" runat="server"
                        OnClick="lbtExportarExcel_Click" />
        <asp:Repeater ID="rptLocation" runat="server">
            <HeaderTemplate>
                <table>
                    <tr class="tableTitle">
                        <th>Ações</th>
                        <th>Código</th>
                        <th>Endereço</th>
                        <th>Código Postal</th>
                        <th>Cidade</th>
                        <th>Estado</th>
                        <th>País</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:LinkButton ID="lbtEditar" Text="Editar" runat="server"
                            CommandArgument='<%# DataBinder.Eval(Container.DataItem,"LocationId") %>'
                            OnCommand="lbtEditar_Command" />
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "LocationId") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "StreetAddress") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "PostalCod") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "City") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "State") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "CountryName") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
