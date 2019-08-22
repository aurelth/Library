<%@ Page Title="" Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="tbJobs.aspx.cs" Inherits="WebApplication1.tbJob" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function validaLetras() {
            var strNomeJ = document.getElementById("MainContent_txtNomeJob").value
            var strIdJ = document.getElementById("MainContent_txtCodJob").value
            var strminSal = document.getElementById("MainContent_txtMinSal").value
            var strMaxSal = document.getElementById("MainContent_txtMaxSal").value

            if (strNomeJ.length === 0) {
                alert("O Nome do departamento não pode estar vazio!!");
                return false;
            } else if (strIdJ.length === 0) {
                alert("O Código do Job não pode estar vazio!!");
                return false;
            } else if (strminSal.length === 0) {
                alert("O Salário Mínimo não pode estar vazio!!");
                return false;
            } else if (strMaxSal.length === 0) {
                alert("O Salário Máximo não pode estar vazio!!");
                return false;
            } else {
                firstModified = document.lastModified;
                return true;
            }
        }

        function SomenteNumeros() {
            if ((event.keyCode < 48 || event.keyCode > 57)) {
                event.returnValue = false;
            }
        }

        function NumEVir() {
            if ((event.keyCode < 48 || event.keyCode > 57)) {
                if (event.keyCode != 110) {
                event.returnValue = false;
                }
            }
        }
    </script>
    <div>
        <asp:Panel ID="pnlEditInsert" runat="server" Visible="false">
            <br />
            <asp:Label ID="lbCodJob" Text="Código do Job" runat="server" />
            <asp:TextBox ID="txtCodJob" runat="server" Enabled="true" MaxLength="10" />
            <br />
            <asp:Label Text="Nome do Job  " runat="server" />
            <asp:TextBox ID="txtNomeJob" runat="server" MaxLength="35" />
            <br />
            <asp:Label Text="Salário Máximo" runat="server" />
            <asp:TextBox ID="txtMaxSal" runat="server" MaxLength="6" onkeypress="SomenteNumeros()" />

            <br />
            <asp:Label Text="Salário Mínimo" runat="server" />
            <asp:TextBox ID="txtMinSal" runat="server" MaxLength="6" onkeypress="SomenteNumeros()" />
            <hr />
            <asp:Button ID="btnEditSave" Text="Salvar" runat="server" OnClick="btnEditSave_Click" OnClientClick="return validaLetras()" />
        </asp:Panel>
        <asp:LinkButton ID="lbtAdcionar" Text="(+) Adicionar novo Job" runat="server" OnClick="lbtAdcionar_Click" />
        <asp:LinkButton ID="lbtExportarExcel" Text="Exportar Para Excel" runat="server"
            OnClick="lbtExportarExcel_Click" />
        <asp:Repeater ID="rptJob" runat="server">
            <HeaderTemplate>
                <table>
                    <tr class="tableTitle">
                        <th>Ações</th>
                        <th>Código</th>
                        <th>Job</th>
                        <th>Salário Mínimo</th>
                        <th>Salário Máximo</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:LinkButton ID="lbtEditar" Text="Editar" runat="server"
                            CommandArgument='<%# DataBinder.Eval(Container.DataItem,"JobId") %>'
                            OnCommand="lbtEditar_Command" />
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "JobId") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "JobName") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "SalaryMin") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "SalaryMax") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
