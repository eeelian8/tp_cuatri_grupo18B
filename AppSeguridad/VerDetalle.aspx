<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="VerDetalle.aspx.cs" Inherits="AppSeguridad.VerDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        #formDetalle {
            background-color: white;
            border: 2px;
            border-radius: 22px;
        }
    </style>
    <br />
    <br />
    <div class="row g-3" id="formDetalle">
        <br />
        <div class="col-md-6">
            <asp:Label ID="lbl_nombre" runat="server" CssClass="form-label" AssociatedControlID="lbl_nombreDetalle" ForeColor="Black"> Nombre </asp:Label>
            <asp:Label ID="lbl_nombreDetalle" runat="server" CssClass="form-control text-bg-dark" TextMode=""></asp:Label>
        </div>
        <div class="col-md-6">
            <asp:Label ID="lbl_apellido" runat="server" CssClass="form-label" AssociatedControlID="lbl_apellidoDetalle" ForeColor="Black"> Apellido </asp:Label>
            <asp:Label ID="lbl_apellidoDetalle" runat="server" CssClass="form-control text-bg-dark" TextMode=""></asp:Label>
        </div>
        <div class="col-12">
            <asp:Label ID="lbl_direccion" runat="server" CssClass="form-label" AssociatedControlID="lbl_direccionDetalle" ForeColor="Black"> Direccion </asp:Label>
            <asp:Label ID="lbl_direccionDetalle" runat="server" CssClass="form-control text-bg-dark"></asp:Label>
        </div>
        <div class="col-md-6">
            <asp:Label ID="lbl_nroDocumento" runat="server" CssClass="form-label" AssociatedControlID="lbl_nroDocumentoDetalle" ForeColor="Black"> Documento </asp:Label>
            <asp:Label ID="lbl_nroDocumentoDetalle" runat="server" CssClass="form-control text-bg-dark"></asp:Label>
        </div>
        <div class="col-md-6">
            <asp:Label ID="lbl_nroTelefono" runat="server" CssClass="form-label" AssociatedControlID="lbl_nroTelefonoDetalle" ForeColor="Black"> Telefono </asp:Label>
            <asp:Label ID="lbl_nroTelefonoDetalle" runat="server" CssClass="form-control text-bg-dark"></asp:Label>
        </div>
        <div class="col-12">
            <asp:Label ID="lbl_tipoTrabajo" runat="server" CssClass="form-label" AssociatedControlID="lbl_tipoTrabajoDetalle" ForeColor="Black"> Tipo de trabajo </asp:Label>
            <asp:Label ID="lbl_tipoTrabajoDetalle" runat="server" CssClass="form-control text-bg-dark"></asp:Label>
        </div>
        <div class="col-12">
            <asp:Label ID="lbl_descripcion" runat="server" CssClass="form-label" AssociatedControlID="lbl_descripcionDetalle" ForeColor="Black"> Descripcion </asp:Label>
            <asp:Label ID="lbl_descripcionDetalle" runat="server" CssClass="form-control text-bg-dark"></asp:Label>
        </div>
        <div class="col-md-4">
            <asp:Label ID="lbl_provincia" runat="server" CssClass="form-label" AssociatedControlID="lbl_provinciaDetalle" ForeColor="Black"> Provincia </asp:Label>
            <asp:Label ID="lbl_provinciaDetalle" runat="server" CssClass="form-control text-bg-dark"></asp:Label>
        </div>
        <div class="col-md-4">
            <asp:Label ID="lbl_localidad" runat="server" CssClass="form-label" AssociatedControlID="lbl_localidadDetalle" ForeColor="Black"> Localidad </asp:Label>
            <asp:Label ID="lbl_localidadDetalle" runat="server" CssClass="form-control text-bg-dark"></asp:Label>
        </div>
        <div class="col-md-4">
            <asp:Label ID="lbl_cp" runat="server" CssClass="form-label" AssociatedControlID="lbl_cpDetalle" ForeColor="Black"> CP </asp:Label>
            <asp:Label ID="lbl_cpDetalle" runat="server" CssClass="form-control text-bg-dark"></asp:Label>
        </div>
        <div class="col-12 mb-3">
            <asp:Button ID="btn_cerrarDetalle" runat="server" CssClass="btn btn-danger" Text="Cerrar" OnClick="btn_cerrarDetalle_Click" />
        </div>
    </div>

</asp:Content>
