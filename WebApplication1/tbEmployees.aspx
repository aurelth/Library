<%@ Page Title="" Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="tbEmployees.aspx.cs" Inherits="WebApplication1.tbEmployees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <script type="text/javascript">
        function validaLetSal() {
            var primNome = document.getElementById("MainContent_txtPrimNome").value
            var segNome = document.getElementById("MainContent_txtSegNome").value
            var email = document.getElementById("MainContent_txtEmail").value
            var fone = document.getElementById("MainContent_txtFone").value
            var salario = document.getElementById("MainContent_txtSal").value

            var valorSal = document.getElementById("MainContent_txtSal").value
            var maxSal = document.getElementById("MainContent_lbMaxSal").textContent
            var minSal = document.getElementById("MainContent_lbMinSal").textContent

            if (valorSal < minSal || valorSal > maxSal) {
                alert("O salário não está setado de acordo com os requisitos!!")
                return false;
            }

            if (primNome.length === 0) {
                alert("O Primeiro Nome não pode estar vazio!!");
                return false;
            } else if (segNome.length === 0) {
                alert("O Segundo Nome não pode estar vazio!!");
                return false;
            } else if (email.length === 0) {
                alert("O Email não pode estar vazio!!");
                return false;
            } else if (fone.length === 0) {
                alert("O Telefone não pode estar vazio!!");
                return false;
            } else if (salario.length === 0) {
                alert("O Salario não pode estar vazio!!");
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

    </script>

    <div>
        <asp:Panel ID="pnlEditInsert" runat="server" Visible="false">
            <br />
            <asp:Label Text="Cód. do Colaborador" runat="server" />
            <asp:TextBox ID="txtCodEmp" runat="server" Enabled="false" />
            <br />
            <asp:Label Text="Primeiro Nome" runat="server" />
            <asp:TextBox ID="txtPrimNome" runat="server" MaxLength="20" Width="200" />
            <asp:Label Text="Segundo Nome " runat="server" />
            <asp:TextBox ID="txtSegNome" runat="server" MaxLength="25" Width="200" />
            <br />
            <asp:Label Text="E-mail" runat="server" />
            <asp:TextBox ID="txtEmail" runat="server" MaxLength="25" Width="200" />
            <asp:Label Text="Telefone" runat="server" />
            <asp:TextBox ID="txtFone" runat="server" MaxLength="20" Width="200" onkeypress="SomenteNumeros()" />
            <br />
            <asp:Label Text="% da Commissão" runat="server" />
            <asp:TextBox ID="txtComissao" runat="server" MaxLength="2" Width="100" onkeypress="SomenteNumeros()" />
            <asp:Label Text="Função" runat="server" />
            <asp:DropDownList ID="ddlJobs" runat="server" Width="200" Height="20" DataTextField="JobName" DataValueField="JobId" AutoPostBack="true" OnSelectedIndexChanged="ddlJobs_SelectedIndexChanged" />
            <br />
            <asp:Label Text="Dia da Contratação" runat="server" />
            <asp:Calendar ID="cldDiaCont" runat="server" Width="150" Height="150">
                <OtherMonthDayStyle ForeColor="LightGray"></OtherMonthDayStyle>
                <TitleStyle BackColor="DarkGray"
                    ForeColor="White"></TitleStyle>
                <DayStyle BackColor="gray"></DayStyle>
                <SelectedDayStyle BackColor="LightGray"
                    Font-Bold="True"></SelectedDayStyle>
            </asp:Calendar>
            <asp:Label Text="Salário" runat="server" />
            <asp:TextBox ID="txtSal" runat="server" MaxLength="8" Width="200" onkeypress="SomenteNumeros()" />
            <asp:Label Text="Máx: " runat="server" />
            <asp:Label ID="lbMaxSal" Text="" runat="server" />
            <asp:Label Text="Min: " runat="server" />
            <asp:Label ID="lbMinSal" Text="" runat="server" />
            <br />
            <asp:Label Text="Manager" runat="server" />
            <asp:DropDownList ID="ddlMng" runat="server" Width="200" Height="20" DataTextField="LastName" DataValueField="EmpID" />
            <asp:Label Text="Departamento" runat="server" />
            <asp:DropDownList ID="ddlDpt" runat="server" Width="200" Height="20" DataTextField="DepName" DataValueField="DepId" />
            <hr />
            <asp:Button ID="btnEditSave" Text="Salvar" runat="server" OnClick="btnEditSave_Click" OnClientClick="return validaLetSal()" />
        </asp:Panel>
        <asp:LinkButton ID="lbtAdcionar" Text="(+) Adicionar novo Colaborador" runat="server" OnClick="lbtAdcionar_Click" />
        <asp:LinkButton ID="lbtExportarExcel" Text="Exportar Para Excel" runat="server"
            OnClick="lbtExportarExcel_Click" />
        <asp:Repeater ID="rptEmployees" runat="server">
            <HeaderTemplate>
                <table>
                    <tr class="tableTitle">
                        <th>Ações</th>
                        <th>Código</th>
                        <th>Nome</th>
                        <th>E-mail</th>
                        <th>Telefone</th>
                        <th>Dia da Admissão</th>
                        <th>Função</th>
                        <th>Salário</th>
                        <th>Comissão</th>
                        <th>Manager</th>
                        <th>Departamento</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:LinkButton ID="lbtEditar" Text="Editar" runat="server"
                            CommandArgument='<%# DataBinder.Eval(Container.DataItem,"EmpId") %>'
                            OnCommand="lbtEditar_Command" />
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "EmpId") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "NomeComp") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "Email") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "FoneNum") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "HireDate") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "JobName") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "Salary") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "Comissao") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "MngId") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "DptNome") %>
                    </td>

                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
