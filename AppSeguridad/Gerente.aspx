<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Gerente.aspx.cs" Inherits="AppSeguridad.Gerente" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentScripts" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <asp:GridView ID="gv_solicitudes" runat="server" class="table"></asp:GridView>
        
        <!-- Botón para ir a Tarjetas de Técnicos -->
        <asp:Button ID="btnTarjetasTecnicos" runat="server" Text="Ver Tarjetas de Técnicos" 
            CssClass="btn btn-primary" OnClick="btnTarjetasTecnicos_Click" />
    </div>
</asp:Content>