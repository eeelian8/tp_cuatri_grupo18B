<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="Administrador.aspx.cs" Inherits="AppSeguridad.Administrador" %>

<asp:Content ID="ContenidoHead" ContentPlaceHolderID="head" runat="server">
    <!-- cabecera para scripts, metadatos -->
</asp:Content> 
<asp:Content ID="ContenidoAdmin" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <!-- botones -->
        <div class="row">
            <div class="col">
                <asp:Button ID="btnPersonal" runat="server" Text="Personal" CssClass="btn btn-primary btn-lg me-2 px-4" />
                <asp:Button ID="btnServicios" runat="server" Text="Servicios" CssClass="btn btn-secondary btn-lg me-2 px-4" />
                <asp:Button ID="btnClientes" runat="server" Text="Clientes" CssClass="btn btn-primary btn-lg me-2 px-4" />
            </div>
        </div>
                
        <div class="row mt-4"><!-- listView -->
            <div class="col">
                <h4>Últimos Movimientos</h4>
                <div class="list-group">
                    <div class="list-group-item">· 1</div>
                    <div class="list-group-item">· 2</div>
                    <div class="list-group-item">· 3</div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>