<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="Recepcion.aspx.cs" Inherits="AppSeguridad.Clientes" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        body {
            background-image: url('/Images/FondoRecepcion.jpg');
            background-size: cover;
            background-repeat: no-repeat;
            background-attachment: fixed;
            background-position: center;
            margin: 0;
            padding: 0;
            height: 100vh;
        }

        .RequiredMessage {
            font-style: italic;
            padding: 0;
            margin: 0;
            font-size: 14px;
        }

        h1, h2, p, label {
            color: white;
        }
    </style>

    <div class="container">
        <h2>Solicitud de Trabajo</h2>
        <p>Complete el formulario para enviar la solicitud.</p>
        <div class="row justify-content-center">
            <div class="col-8">

                <div class="form-check">
                    <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault1">
                    <label class="form-check-label" for="flexRadioDefault1">PRESUPUESTO</label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="radio" name="flexRadioDefault" id="flexRadioDefault2" checked>
                    <label class="form-check-label" for="flexRadioDefault2">REPARACIONES</label>
                </div>
                <div class="row mb-3">
                    <label for="txtFechaCarga" class="col-sm-3 col-form-label">Fecha de Carga :</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtFechaCarga" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                <div class="row mb-3">
                    <label for="txtDni" class="col-sm-3 col-form-label">DNI:</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtDni" runat="server" CssClass="form-control" OnTextChanged="DNIUsuario_TextChanged" AutoPostBack="true" Placeholder="Ingrese DNI"></asp:TextBox>
                    </div>
                </div>

                <div class="row mb-3">
                    <div class="col-sm-6">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />
                    </div>
                </div>
                <!-- Alerta de advertencia, oculta -->
                <asp:Panel ID="alertaDniNoExiste" runat="server" CssClass="alert alert-warning" Visible="false">
                    El DNI ingresado no existe en nuestra base de datos.
                </asp:Panel>

                <div class="mb-3">
                    <label for="ddlItems" class="col-sm-3 col-form-label">Tipo Trabajo :</label>
                    <asp:DropDownList ID="ddlItems" runat="server"></asp:DropDownList>
                </div>


                <div class="row mb-3">
                    <label for="txtNombre" class="col-sm-3 col-form-label">Nombre :</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Placeholder="Ej: Juan Pérez"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtNombre" ErrorMessage="El nombre es obligatorio" CssClass="text-danger" runat="server" />
                    </div>
                </div>


                <div class="row mb-3">
                    <label for="txtTelefono" class="col-sm-3 col-form-label">Teléfono:</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" Placeholder="Ej: 15-4567-8900"></asp:TextBox>
                        <asp:RegularExpressionValidator ControlToValidate="txtTelefono" ErrorMessage="Formato de teléfono inválido" CssClass="text-danger" runat="server" ValidationExpression="\d{3}-\d{3}-\d{4}" />
                    </div>
                </div>
                <div class="row mb-3">
                    <label for="txtDireccion" class="col-sm-3 col-form-label">Direccion :</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" Placeholder="Ej: calle Wallaby, 42"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtDireccion" ErrorMessage="La direccion es obligatoria" CssClass="text-danger" runat="server" />
                    </div>
                </div>
                <div class="row mb-3">
                    <label for="txtLocalidad" class="col-sm-3 col-form-label">Localidad :</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtLocalidad" runat="server" CssClass="form-control" Placeholder="Ej: Tigre"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtLocalidad" ErrorMessage="La localidad es obligatoria" CssClass="text-danger" runat="server" />
                    </div>
                </div>
                <div class="row mb-3">
                    <label for="txtProvincia" class="col-sm-3 col-form-label">Provincia :</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtProvincia" runat="server" CssClass="form-control" Placeholder="Ej: Buenos Aires"></asp:TextBox>
                        <asp:RequiredFieldValidator ControlToValidate="txtProvincia" ErrorMessage="La provincia es obligatoria" CssClass="text-danger" runat="server" />
                    </div>
                </div>
                <div class="row mb-3">
                    <label for="txtObservaciones" class="col-sm-3 col-form-label">Observaciones:</label>

                    <div class="col-sm-4">
                        <asp:TextBox ID="txtObservaciones" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="mb-3">

                    <div class="form-check form-switch">
                        <input class="form-check-input" type="checkbox" id="flexSwitchCheckDefault">
                        <label class="form-check-label" for="flexSwitchCheckDefault">Urgente</label>
                    </div>

                </div>
                <div class="col-sm-4 mb-3">
                    <asp:FileUpload ID="fileUploadImagen" runat="server" CssClass="file-upload-hidden" AllowMultiple="true" />
                </div>

                <div class="row mb-3">

                    <div class="col-sm-6">
                        <asp:Button ID="btnSubmit" runat="server" Text="Enviar" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
                    </div>

                </div>


                <asp:Label ID="lblConfirmacion" runat="server" Text="Solicitud enviada con éxito" CssClass="text-success" Visible="false"></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>
