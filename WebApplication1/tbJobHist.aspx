<%@ Page Title="" Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="tbJobHist.aspx.cs" Inherits="WebApplication1.tbJobHist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:Panel ID="pnlInsert" runat="server" Visible="false">
            <br />
            <asp:Label Text="Colaborador" runat="server" />
            <asp:DropDownList ID="ddlColaborador" runat="server" Width="250" Height="25" AutoPostBack="true" DataTextField="NomeComp" DataValueField="EmpId" />
            <br />
            <asp:Label Text="Data inicial" runat="server" />
            <asp:Calendar ID="cldDataInicial" runat="server" Width="150" Height="150">
                <OtherMonthDayStyle ForeColor="LightGray"></OtherMonthDayStyle>
                <TitleStyle BackColor="DarkGray"
                    ForeColor="White"></TitleStyle>
                <DayStyle BackColor="gray"></DayStyle>
                <SelectedDayStyle BackColor="LightGray"
                    Font-Bold="True"></SelectedDayStyle>
            </asp:Calendar>
            <br />
            <asp:Label Text="Data Final" runat="server" />
            <asp:Calendar ID="cldDataFinal" runat="server" Width="150" Height="150">
                <OtherMonthDayStyle ForeColor="LightGray"></OtherMonthDayStyle>
                <TitleStyle BackColor="DarkGray"
                    ForeColor="White"></TitleStyle>
                <DayStyle BackColor="gray"></DayStyle>
                <SelectedDayStyle BackColor="LightGray"
                    Font-Bold="True"></SelectedDayStyle>
            </asp:Calendar>
            <br />
            <asp:Label Text="Função" runat="server" />
            <asp:DropDownList ID="ddlFunção" runat="server" Width="200" Height="25" DataTextField="JobName" DataValueField="JobId" />
            <br />
            <asp:Label Text="Departamento" runat="server" />
            <asp:DropDownList ID="ddlDpt" runat="server" Width="200" Height="25" DataTextField="DepName" DataValueField="DepId" />
            <hr />
            <asp:Button ID="btnSave" Text="Salvar" runat="server" OnClick="btnSave_Click"/>
        </asp:Panel>
        <asp:LinkButton ID="lbtAdcionar" Text="(+) Adicionar novo Colaborador" runat="server" OnClick="lbtAdcionar_Click" />
        <asp:LinkButton ID="lbtExportarExcel" Text="Exportar Para Excel" runat="server"
            OnClick="lbtExportarExcel_Click" />
        <asp:Repeater ID="rptJobHist" runat="server">
            <HeaderTemplate>
                <table>
                    <tr class="tableTitle">
                        <th>Colaborador</th>
                        <th>Data Inicial</th>
                        <th>Data Final</th>
                        <th>Função</th>
                        <th>Departamento</th>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "EmpName") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "StartDate") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "EndDate") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "JobName") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "DeptName") %>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
