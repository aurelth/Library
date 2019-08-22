<%@ Page Title="" Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="tbDepartments.aspx.cs" Inherits="WebApplication1.tbDepartment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function validaLetras() {
            var strNomeD = document.getElementById("MainContent_txtNomeDepart").value
            if (strNomeD.length === 0) {
                alert("O Nome do departamento não pode estar vazio!!");
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
            <asp:Label ID="lbCodDepart" Text="Código do departamento " runat="server" />
            <asp:TextBox ID="txtCodDepart" runat="server" Enabled="true" />
            <br />
            <asp:Label Text="Nome do departamento" runat="server" />
            <asp:TextBox ID="txtNomeDepart" runat="server" MaxLength="30" />
            <br />
            <asp:Label Text="Manager" runat="server" />
            <asp:DropDownList ID="ddlCodManag" runat="server" Width="300" Height="25" DataTextField="LastName" DataValueField="EmpId" />
            <br />
            <asp:Label Text="Localidade" runat="server" />
            <asp:DropDownList ID="ddlLocal" runat="server" Width="300" Height="25" DataTextField="StreetAddress" DataValueField="LocationId" />
            <hr />
            <asp:Button ID="btnEditSave" Text="Salvar" runat="server" OnClick="btnEditSave_Click" />
        </asp:Panel>
        <asp:LinkButton ID="lbtAdcionar" Text="(+) Adicionar nova locação" runat="server" OnClick="lbtAdcionar_Click" OnClientClick="return validaLetras()" />
        <asp:LinkButton ID="lbtExportarExcel" Text="Exportar Para Excel" runat="server"
            OnClick="lbtExportarExcel_Click" />
        <asp:Repeater ID="rptDepart" runat="server">
            <HeaderTemplate>
                <table>
                    <tr class="tableTitle">
                        <th>Ações</th>
                        <th>Código</th>
                        <th>Departamento</th>
                        <th>Manager</th>
                        <th>Localidade</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:LinkButton ID="lbtEditar" Text="Editar" runat="server"
                            CommandArgument='<%# DataBinder.Eval(Container.DataItem,"DepId") %>'
                            OnCommand="lbtEditar_Command" />
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "DepId") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "DepName") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "ManagName") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "LocatName") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
