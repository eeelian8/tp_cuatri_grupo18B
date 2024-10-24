<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="Clientes.aspx.cs" Inherits="AppSeguridad.Clientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-4">
        </div>
        <div class="col-6">
            <br />
            <br />
            <div class="form-check">
                <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault1">
                <label class="form-check-label" for="flexRadioDefault1">
                    PRESUPUESTO
                </label>
            </div>
            <div class="form-check">
                <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2" checked>
                <label class="form-check-label" for="flexRadioDefault2">
                    SOLICITUD DE TRABAJO
                </label>
            </div>
            <br />
            <br />

            <div class="mb-3">

                <asp:Label ID="lblTipo" runat="server" Text="Tipo de trabajo:"></asp:Label>

                <asp:DropDownList ID="ddlItems" runat="server">
                </asp:DropDownList>
            </div>
            <div class="container">
                <div class="row mb-3">
                    <label for="txtNombre" class="col-sm-3 col-form-label">Nombre :</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="row mb-3">
                    <label for="txtDireccion" class="col-sm-3 col-form-label">Direccion:</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="row mb-3">
                    <label for="txtTelefono" class="col-sm-3 col-form-label">Telefono:</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="row mb-3">
                    <label for="txtObservaciones" class="col-sm-3 col-form-label">Observaciones:</label>

                    <div class="col-sm-4">
                        <asp:TextBox ID="txtObservaciones" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
        <div class="row mb-3">
            <div class="col-sm-2">  
                <i class="bi bi-plus-circle" style="font-size: 1.5rem;"></i>
            </div>
            <div class="col-sm-4">
                <asp:FileUpload ID="fileUploadImagen" runat="server" CssClass="form-control" />
            </div>
        </div>
                <div class="row">
                    <div class="col-sm-6">
                        <asp:Button ID="btnSubmit" runat="server" Text="Enviar" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
