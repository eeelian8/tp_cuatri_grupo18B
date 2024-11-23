<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="Recepcion.aspx.cs" Inherits="AppSeguridad.Clientes" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <div class="container">
        <h2>Solicitud de Trabajo</h2>
        <p>Complete el formulario para enviar la solicitud.</p>
        <div class="d-flex justify-content-end position-fixed" style="top: 10px; right: 20px; z-index: 1050;">
            <asp:Button ID="btnHistorial" runat="server" Text="Historial Trabajos"
                OnClick="btnHistorial_Click"
                CssClass="btn-crema"
                CausesValidation="false" />
        </div>

        <div class="container">
            <div class="row justify-content-center">
                <div class="col-10">
                    <div class="row align-items-center g-3">
                        <label for="txtDni" class="col-sm-1 col-form-label text-end">DNI:</label>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtDni" runat="server" CssClass="form-control" Placeholder="Ingrese DNI"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorDNI" ControlToValidate="txtDni"
                                CssClass="RequiredMessage" runat="server" ErrorMessage="*El campo DNI es obligatorio."
                                Display="Dynamic" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorDNI"
                                CssClass="RequiredMessage" runat="server" ErrorMessage="*Solo se aceptan valores numéricos."
                                ControlToValidate="txtDni" ValidationExpression="^\d+$" EnableClientScript="true"
                                Display="Dynamic" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-sm-3 d-flex justify-content-center">
                            <asp:Button ID="btnBuscar" runat="server" Text="Completar Formulario"
                                OnClick="btnBuscar_Click" CausesValidation="false" CssClass="btn-crema" />
                        </div>
                        <div class="col-sm-3 d-flex justify-content-center">
                            <asp:Button ID="BtnHistorialCliente" runat="server" Text="Historial Cliente"
                                OnClick="btnHistorialCliente_Click" CausesValidation="false" CssClass="btn-crema" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <asp:Panel ID="alertaDniNoExiste" runat="server" CssClass="alert alert-warning" Visible="false">
            El DNI ingresado no existe en nuestra base de datos.
        </asp:Panel>
    </div>

    <div class="row">
        <div class="col-8">
            <div class="row mb-3">
                <div class="col-sm-8">
                    <div class="form-check radio-crema">
                        <input class="form-check-input" type="radio" runat="server" name="flexRadioDefault" id="flexRadioDefault1">
                        <label class="form-check-label" for="flexRadioDefault1">PRESUPUESTO</label>
                    </div>
                    <div class="form-check radio-crema">
                        <input class="form-check-input" type="radio" runat="server" name="flexRadioDefault" id="flexRadioDefault2" checked>
                        <label class="form-check-label" for="flexRadioDefault2">REPARACIONES</label>
                    </div>
                </div>
            </div>
            <div class="row mb-3">
                <label for="txtFechaCarga" class="col-sm-2 col-form-label">Fecha de Carga:</label>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtFechaCarga" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                </div>
            </div>
            <div class="mb-3">
                <label for="ddlItems" class="col-sm-2 col-form-label">Tipo Trabajo:</label>
                <asp:DropDownList ID="ddlItems" runat="server"></asp:DropDownList>
            </div>

            <div class="row mb-3">
                <label for="txtNombre" class="col-sm-2 col-form-label">Nombre Completo:</label>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Placeholder="Ej: Juan Pérez"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombre" ControlToValidate="txtNombre" CssClass="RequiredMessage" runat="server" ErrorMessage="*El campo Nombre es obligatorio." Display="Dynamic" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorNombre" CssClass="RequiredMessage" runat="server" ErrorMessage="*Solo se aceptan letras." ControlToValidate="txtNombre" ValidationExpression="[a-zA-Z ]{2,254}" EnableClientScript="true" Display="Dynamic" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="row mb-3">
                <label for="txtTelefono" class="col-sm-2 col-form-label">Teléfono:</label>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" Placeholder="Ej: 1545678900"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTelefono" ControlToValidate="txtTelefono" CssClass="RequiredMessage" runat="server" ErrorMessage="*El campo Teléfono es obligatorio." Display="Dynamic" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorTelefono" ControlToValidate="txtTelefono" CssClass="RequiredMessage" runat="server" ErrorMessage="*Solo se aceptan números." ValidationExpression="^\d{10}$" EnableClientScript="true" Display="Dynamic" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="row mb-3">
                <label for="txtDireccion" class="col-sm-2 col-form-label">Direccion:</label>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" Placeholder="Ej: calle Wallaby, 42"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorDireccion" ControlToValidate="txtDireccion" CssClass="RequiredMessage" runat="server" ErrorMessage="*El campo Dirección es obligatorio." Display="Dynamic" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorDireccion" CssClass="RequiredMessage" runat="server" ErrorMessage="*El campo acepta solo letras y números." ControlToValidate="txtDireccion" ValidationExpression="^[a-zA-Z0-9 ]+$" EnableClientScript="true" Display="Dynamic" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="row mb-3">
                <label for="txtLocalidad" class="col-sm-2 col-form-label">Localidad:</label>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtLocalidad" runat="server" CssClass="form-control" Placeholder="Ej: Tigre"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorLocalidad" ControlToValidate="txtLocalidad" CssClass="RequiredMessage" runat="server" ErrorMessage="*El campo Localidad es obligatorio." Display="Dynamic" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorLocalidad" CssClass="RequiredMessage" runat="server" ErrorMessage="*El campo acepta solo letras." ControlToValidate="txtLocalidad" ValidationExpression="^[a-zA-Z ]+$" EnableClientScript="true" Display="Dynamic" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="row mb-3">
                <label for="txtProvincia" class="col-sm-2 col-form-label">Provincia:</label>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtProvincia" runat="server" CssClass="form-control" Placeholder="Ej: Buenos Aires"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtProvincia" CssClass="RequiredMessage" runat="server" ErrorMessage="*El campo Provincia es obligatorio." Display="Dynamic" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" CssClass="RequiredMessage" runat="server" ErrorMessage="*El campo acepta solo letras." ControlToValidate="txtProvincia" ValidationExpression="^[a-zA-Z ]+$" EnableClientScript="true" Display="Dynamic" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="row mb-3">
                <label for="txtObservaciones" class="col-sm-2 col-form-label">Observaciones:</label>
                <div class="col-sm-6">
                    <asp:TextBox ID="txtObservaciones" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorObservaciones" ControlToValidate="txtObservaciones" CssClass="RequiredMessage" runat="server" ErrorMessage="*El campo Observaciones solo permite letras, números y ciertos caracteres especiales." ValidationExpression="^[a-zA-Z0-9\s.,!?()'-]+$" EnableClientScript="true" Display="Dynamic" ForeColor="#CC0000"></asp:RegularExpressionValidator>
                </div>
            </div>

            <div class="mb-3">
                <div class="form-check radio-crema form-switch">
                    <input class="form-check-input" type="checkbox" runat="server" id="flexSwitchCheckDefault">
                    <label class="form-check-label" for="flexSwitchCheckDefault">Urgente</label>
                </div>
            </div>

            <div class="col-sm-4 mb-3 ">
                <asp:FileUpload ID="fileUploadImagen" runat="server" CssClass="file-upload-hidden btn-crema" Visible="false" AllowMultiple="true" />
            </div>

            <div class="row mb-3">
                <div class="col-sm-6 offset-sm-2">
                    <asp:Button ID="btnSubmit" runat="server" Text="Enviar" OnClick="btnSubmit_Click" CssClass="btn-crema" />
                </div>
            </div>
            <asp:Label ID="lblConfirmacion" runat="server" Text="Solicitud enviada con éxito" CssClass="text-success" Visible="false"></asp:Label>
        </div>
    </div>

   <!-- Modal Historial General -->
<div class="modal fade" id="modalHistorial" data-bs-backdrop="static" tabindex="-1" aria-labelledby="modalHistorialLabel" aria-hidden="true">
    <div class="modal-dialog modal-xl">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="modalHistorialLabel">Historial de Trabajos</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="table-responsive" style="max-height: 60vh; overflow-y: auto;">
                            <asp:GridView ID="dgvHistorial" runat="server"
                                CssClass="table table-bordered table-striped table-hover"
                                AutoGenerateColumns="True"
                                GridLines="None"
                                AllowPaging="True"
                                PageSize="15"
                                OnPageIndexChanging="dgvHistorial_PageIndexChanging"
                                CellPadding="4">
                                <HeaderStyle CssClass="table-dark sticky-top" />
                                <RowStyle CssClass="align-middle" />
                                <AlternatingRowStyle CssClass="table-light" />
                                <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
                                <PagerTemplate>
                                    <div class="d-flex justify-content-center align-items-center gap-2 my-2">
                                        <asp:LinkButton ID="PreviousPage" runat="server"
                                            CommandName="Page"
                                            CommandArgument="Prev"
                                            CssClass="btn btn-sm btn-outline-secondary"
                                            Enabled="<%# ((GridView)Container.Parent.Parent).PageIndex > 0 %>">
                                            <span aria-hidden="true">&laquo;</span> Anterior
                                        </asp:LinkButton>

                                        <span class="mx-2">
                                            Página <%# ((GridView)Container.Parent.Parent).PageIndex + 1 %> 
                                            de <%# ((GridView)Container.Parent.Parent).PageCount %>
                                        </span>

                                        <asp:LinkButton ID="NextPage" runat="server"
                                            CommandName="Page"
                                            CommandArgument="Next"
                                            CssClass="btn btn-sm btn-outline-secondary"
                                            Enabled="<%# ((GridView)Container.Parent.Parent).PageIndex < ((GridView)Container.Parent.Parent).PageCount - 1 %>">
                                            Siguiente <span aria-hidden="true">&raquo;</span>
                                        </asp:LinkButton>
                                    </div>
                                </PagerTemplate>
                            </asp:GridView>
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="btnHistorial" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="dgvHistorial" EventName="PageIndexChanging" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
            </div>
        </div>
    </div>
</div>

    <!-- Modal Historial Cliente -->
    <div class="modal fade" id="modalHistorialCliente" data-bs-backdrop="static" tabindex="-1" aria-labelledby="modalHistorialClienteLabel" aria-hidden="true">
        <div class="modal-dialog modal-xl">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalHistorialClienteLabel">Historial del Cliente</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="table-responsive">
                                <asp:GridView ID="dgvHistorialCliente" runat="server"
                                    CssClass="table table-bordered table-striped table-hover"
                                    AutoGenerateColumns="True"
                                    GridLines="None"
                                    AllowPaging="True"
                                    PageSize="10"
                                    CellPadding="4">
                                    <HeaderStyle CssClass="table-dark" />
                                    <RowStyle CssClass="align-middle" />
                                    <AlternatingRowStyle CssClass="table-light" />
                                    <PagerStyle CssClass="pagination-ys" />
                                </asp:GridView>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="BtnHistorialCliente" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            console.log("EndRequest fired");
            initializeModals();
        });

        function initializeModals() {
            console.log("Initializing modals");
            $('.modal').each(function () {
                var $modal = $(this);
                $modal.on('shown.bs.modal', function () {
                    console.log("Modal shown event fired");
                    $modal.find('.table-responsive').css('max-height', (window.innerHeight * 0.7) + 'px');
                });
            });
        }

        function showHistorialModal() {
            console.log("Showing historial modal");
            var modalEl = document.getElementById('modalHistorial');
            var modal = new bootstrap.Modal(modalEl);
            modal.show();
        }

        function showHistorialClienteModal() {
            console.log("Showing historial cliente modal");
            var modalEl = document.getElementById('modalHistorialCliente');
            var modal = new bootstrap.Modal(modalEl);
            modal.show();
        }

        function hideAlertAfterTimeout() {
            setTimeout(function () {
                var alerta = document.getElementById('<%= alertaDniNoExiste.ClientID %>');
                if (alerta) {
                    alerta.style.display = 'none';
                }
            }, 5000);
        }

        // Inicialización cuando el documento está listo
        $(document).ready(function () {
            console.log("Document ready");
            initializeModals();
        });
    </script>
</asp:Content>