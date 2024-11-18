<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="Recepcion.aspx.cs" Inherits="AppSeguridad.Clientes" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Solicitud de Trabajo</h2>
        <p>Complete el formulario para enviar la solicitud.</p>
        <div class="row justify-content-center">
            <div class="col-8">

                <div class="form-check">
                    <input class="form-check-input" type="radio" runat="server" name="flexRadioDefault" id="flexRadioDefault1">
                    <label class="form-check-label" for="flexRadioDefault1">PRESUPUESTO</label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="radio" runat="server" name="flexRadioDefault" id="flexRadioDefault2" checked>
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
                        <asp:TextBox ID="txtDni" runat="server" CssClass="form-control" Placeholder="Ingrese DNI"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDNI" ControlToValidate="txtDni" CssClass="RequiredMessage" runat="server" ErrorMessage="*El campo DNI es obligatorio." Display="Dynamic" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorDNI" CssClass="RequiredMessage" runat="server" ErrorMessage="*Solo se aceptan valores numéricos." ControlToValidate="txtDni" ValidationExpression="^\d+$" EnableClientScript="true" Display="Dynamic" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="row mb-3">
                    <div class="col-sm-6">
                        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" CssClass="btn btn-primary" />
                    </div>
                </div>
                <!-- Alerta de advertencia, oculta -->
                <asp:Panel ID="alertaDniNoExiste" runat="server" CssClass="alert alert-warning" Visible="false">
                    El DNI ingresado no existe en nuestra base de datos.
                </asp:Panel>
                <script type="text/javascript">
                    function hideAlertAfterTimeout() {
                        // Muestra el panel de alerta por 5 segundos y luego lo oculta
                        setTimeout(function () {
                            var alerta = document.getElementById('<%= alertaDniNoExiste.ClientID %>');
                            if (alerta) {
                                alerta.style.display = 'none';
                            }
                        }, 5000); // 5000 milisegundos = 5 segundos
                    }
                </script>
                <div class="mb-3">
                    <label for="ddlItems" class="col-sm-3 col-form-label">Tipo Trabajo :</label>
                    <asp:DropDownList ID="ddlItems" runat="server"></asp:DropDownList>
                </div>


                <div class="row mb-3">
                    <label for="txtNombre" class="col-sm-3 col-form-label">Nombre :</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Placeholder="Ej: Juan Pérez"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombre" ControlToValidate="txtNombre" CssClass="RequiredMessage" runat="server" ErrorMessage="*El campo Nombre es obligatorio." Display="Dynamic" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidatorNombre" CssClass="RequiredMessage" runat="server" ErrorMessage="*Solo se aceptan letras." ControlToValidate="txtNombre" ValidationExpression="[a-zA-Z ]{2,254}" EnableClientScript="true" Display="Dynamic" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                    </div>
                </div>


                <div class="row mb-3">
                    <label for="txtTelefono" class="col-sm-3 col-form-label">Teléfono:</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" Placeholder="Ej: 15-4567-8900"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTelefono" ControlToValidate="txtTelefono" CssClass="RequiredMessage" runat="server" ErrorMessage="*El campo Dirección es obligatorio." Display="Dynamic" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorTelefono" ControlToValidate="txtTelefono" CssClass="RequiredMessage" runat="server"  ErrorMessage="*Formato de teléfono inválido. Ej: 12-3456-7890"  ValidationExpression="^\d{2}-\d{4}-\d{4}$"  EnableClientScript="true"    Display="Dynamic"   ForeColor="#CC0000"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="row mb-3">
                    <label for="txtDireccion" class="col-sm-3 col-form-label">Direccion :</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" Placeholder="Ej: calle Wallaby, 42"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorDireccion" ControlToValidate="txtDireccion" CssClass="RequiredMessage" runat="server" ErrorMessage="*El campo Dirección es obligatorio." Display="Dynamic" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorDireccion" CssClass="RequiredMessage" runat="server" ErrorMessage="*El campo acepta solo letras y números." ControlToValidate="txtDireccion" ValidationExpression="^[a-zA-Z0-9 ]+$" EnableClientScript="true" Display="Dynamic" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="row mb-3">
                    <label for="txtLocalidad" class="col-sm-3 col-form-label">Localidad :</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtLocalidad" runat="server" CssClass="form-control" Placeholder="Ej: Tigre"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatorLocalidad" ControlToValidate="txtLocalidad" CssClass="RequiredMessage" runat="server" ErrorMessage="*El campo Localidad es obligatorio." Display="Dynamic" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorLocalidad" CssClass="RequiredMessage" runat="server" ErrorMessage="*El campo acepta solo letras." ControlToValidate="txtLocalidad" ValidationExpression="^[a-zA-Z ]+$" EnableClientScript="true" Display="Dynamic" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="row mb-3">
                    <label for="txtProvincia" class="col-sm-3 col-form-label">Provincia :</label>
                    <div class="col-sm-8">
                        <asp:TextBox ID="txtProvincia" runat="server" CssClass="form-control" Placeholder="Ej: Buenos Aires"></asp:TextBox>
                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtProvincia" CssClass="RequiredMessage" runat="server" ErrorMessage="*El campo Provincia es obligatorio." Display="Dynamic" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator1" CssClass="RequiredMessage" runat="server" ErrorMessage="*El campo acepta solo letras." ControlToValidate="txtProvincia" ValidationExpression="^[a-zA-Z ]+$" EnableClientScript="true" Display="Dynamic" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="row mb-3">
                    <label for="txtObservaciones" class="col-sm-3 col-form-label">Observaciones:</label>
                    <div class="col-sm-4">
                        <asp:TextBox ID="txtObservaciones" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorObservaciones"  ControlToValidate="txtObservaciones" CssClass="RequiredMessage"  runat="server"  ErrorMessage="*El campo Observaciones solo permite letras, números y ciertos caracteres especiales." ValidationExpression="^[a-zA-Z0-9\s.,!?()'-]+$"  EnableClientScript="true" Display="Dynamic"  ForeColor="#CC0000"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="mb-3">
                   <div class="form-check form-switch">
                        <input class="form-check-input" type="checkbox" runat="server" id="flexSwitchCheckDefault">
                        <label class="form-check-label" for="flexSwitchCheckDefault">Urgente</label>
                   </div>

                </div>

                <div class="col-sm-4 mb-3">
                    <asp:FileUpload ID="fileUploadImagen" runat="server" CssClass="file-upload-hidden" AllowMultiple="true" />
                </div>

                <div class="row mb-3">

                    <div class="col-sm-6">
                        <asp:Button ID="btnSubmit" runat="server" Text="Enviar" OnClick="btnSubmit_Click"  CssClass="btn btn-primary" />
                    </div>
                </div>
                    <asp:Label ID="lblConfirmacion" runat="server" Text="Solicitud enviada con éxito" CssClass="text-success" Visible="false"></asp:Label>
            </div>
        </div>
    </div>

</asp:Content>
