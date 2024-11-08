<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Tecnico.aspx.cs" Inherits="AppSeguridad.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function abrirModalDenegar() {
            var myModal = new bootstrap.Modal(document.getElementById('modalDenegar'));
            myModal.show();
            return false;
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row">
        <div class="col"></div>
        <div class="col-6">
            <!-- panel de trabajos pendientes -->
            <div class="card mb-4">
                <div class="card-header">
                    <h5 class="mb-0">Trabajos Pendientes</h5>
                </div>
                <div class="card-body p-0">
                    <div class="list-group list-group-flush">
                        <asp:Repeater ID="repTareas" runat="server" OnItemCommand="tareaSeleccionada" OnItemDataBound="CargarDatos">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkTrabajo" runat="server" CssClass="list-group-item list-group-item-action" 
                                              CommandName="Select">
                                    <div class="d-flex w-100 justify-content-between">
                                        <h6 class="mb-1"><asp:Label ID="lblTipoTrabajo" runat="server" /></h6>
                                        <small class="text-muted">#<asp:Label ID="lblId" runat="server" /></small>
                                    </div>
                                    <div class="row mt-2">
                                        <div class="col-8">
                                            <div class="border p-2 mb-2">
                                                <asp:Label ID="lblDescripcion" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-4">
                                            <p class="mb-1"><asp:Label ID="lblDireccion" runat="server" /></p>
                                            <p class="mb-1"><asp:Label ID="lblLocalidad" runat="server" /></p>
                                            <p class="mb-1"><asp:Label ID="lblProvincia" runat="server" /></p>
                                            <p class="mb-1">Tel: <asp:Label ID="lblTelefono" runat="server" /></p>
                                        </div>
                                    </div>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>

            <!-- botones -->
            <div class="d-grid gap-2 d-md-flex justify-content-center mb-4">
                <asp:Button ID="btnAceptar" runat="server" Text="Aceptar ✓" 
                            CssClass="btn btn-secondary px-4" Enabled="false"
                            OnClick="btnAceptar_Click" />
                <asp:Button ID="btnDenegar" runat="server" Text="Rechazar X" 
                            CssClass="btn btn-secondary px-4" Enabled="false" 
                            OnClientClick="return abrirModalDenegar();" />
            </div>

            <!-- historial -->
            <div class="d-grid">
                <asp:Button ID="btnHistorial" runat="server" Text="Historial de trabajos" 
                           CssClass="btn btn-primary" OnClick="btnHistorial_Click" />
            </div>
        </div>
        <div class="col"></div>
    </div>

    <!-- modal de rechazo -->
    <div class="modal fade" id="modalDenegar" tabindex="-1" aria-labelledby="modalDenegarLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalDenegarLabel">Motivo de Denegación</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <asp:TextBox ID="txtMotivoDenegacion" runat="server" CssClass="form-control" 
                                TextMode="MultiLine" Rows="4" placeholder="Ingrese motivo...">
                    </asp:TextBox>
                </div>
                <div class="modal-footer">
                    <asp:Button ID="btnConfirmarDenegar" runat="server" Text="Confirmar" 
                              CssClass="btn btn-primary" OnClick="btnConfirmarDenegar_Click"/>
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>