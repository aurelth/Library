<%@ Page Language="C#" MasterPageFile="~/Sistema.Master" AutoEventWireup="true" CodeBehind="CadastroRegions.aspx.cs" Inherits="WebApplication1.CadastroRegions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Content/Cadastro.css" rel="stylesheet" />

    <script type="text/javascript">

        function validaLetras() {

            var str = document.getElementById("region_name").value

            if (!str.match(/^[A-zÀ-ú]([A-zÀ-ú \s?]?)+$/)) {
                alert("Preencha o Nome da região somente com letras");

                return false;
            }
            else {
                __doPostBack(this.id, '');
                firstModified = document.lastModified;
            }
        }


    </script>
    <fieldset>
        <div class="lblRegions">
            <div class="lbllabelregion">
                Nome Região:
            </div>
        </div>

        <div class="txtcaixasdetexto">
            <asp:TextBox CssClass="textespacamento" ID="region_name" ClientIDMode="Static" runat="server"></asp:TextBox>
        </div>
        <div class="btnenviar">
            <asp:Button ID="btnRegions" runat="server" Text="Enviar" OnClientClick="validaLetras(this);return false;" />
        </div>
    </fieldset>
</asp:Content>
