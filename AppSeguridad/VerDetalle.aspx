<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="VerDetalle.aspx.cs" Inherits="AppSeguridad.VerDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container text-center">
        <div class="input-group mb-3">
            <span class="input-group-text">Nombre</span>
            <asp:Label ID="lbl_Nombre" runat="server" Text="" class="form-control"></asp:Label>
        </div>
        <div class="input-group mb-3">
            <span class="input-group-text">Apellido</span>
            <asp:Label ID="lbl_Apellido" runat="server" Text="" class="form-control"></asp:Label>
        </div>

        <div class="input-group mb-3">
            <span class="input-group-text">Documento</span>
            <asp:Label ID="lbl_Documento" runat="server" Text="" class="form-control"></asp:Label>
        </div>

        <div class="mb-3">
            <div class="input-group">
                <span class="input-group-text">Tipo de trabajo</span>
                <asp:Label ID="lbl_TipoTrabajo" class="form-control" runat="server" Text=""></asp:Label>
            </div>
        </div>

        <div class="input-group mb-3">
            <span class="input-group-text">Provincia</span>
            <asp:Label ID="lbl_Provincia" class="form-control" runat="server" Text=""></asp:Label>
        </div>

        <div class="input-group mb-3">
            <span class="input-group-text">Localidad</span>
            <asp:Label ID="lbl_Localidad" class="form-control" runat="server" Text=""></asp:Label>
        </div>

        <div class="input-group mb-3">
            <span class="input-group-text">Direccion</span>
            <asp:Label ID="lbl_Direccion" class="form-control" runat="server" Text=""></asp:Label>
        </div>

        <div class="input-group mb-3">
            <span class="input-group-text">Imagenes</span>
            <asp:Image ID="imgSt" runat="server" ImageUrl="https://agroguia.com/wp-content/uploads/2024/09/66eddada4b403.webp" Height="200" Width="320" />
        </div>

    </div>
</asp:Content>
