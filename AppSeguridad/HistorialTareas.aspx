<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="HistorialTareas.aspx.cs" Inherits="AppSeguridad.HistorialTareas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <!-- Panel Tarea Seleccionada -->
            <div class="col-md-4">
                <div class="card mb-3">
                    <div class="card-header">
                        <h5 class="mb-0">Tarea Seleccionada</h5>
                    </div>
                    <div class="card-body">
                        <h6 class="card-title d-flex justify-content-between">
                            <span id="tituloTarea">Título Tarea</span>
                            <small class="text-muted">#<asp:Label ID="lblCodigo" runat="server" /></small>
                        </h6>
                        <p class="card-text">
                            <strong>Dirección: </strong>
                            <asp:Label ID="lblDireccion" runat="server" />
                        </p>
                        <div class="form-group mb-3">
                            <label>Descripción:</label>
                            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" ReadOnly="true" />
                        </div>
                        <div class="form-group">
                            <label>Observaciones:</label>
                            <asp:TextBox ID="txtObservaciones" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="2" />
                        </div>
                    </div>
                </div>
            </div>

            <!-- tareas Aceptadas -->
            <div class="col-md-8">
                <div class="card">
                    <div class="card-header">
                        <h5 class="mb-0">Tareas Aceptadas</h5>
                    </div>
                    <div class="card-body">
                        <asp:Repeater ID="repTareasAceptadas" runat="server">
                            <ItemTemplate>
                                <div class="card mb-3">
                                    <div class="card-body">
                                        <h6 class="card-title d-flex justify-content-between">
                                            <span><%# Eval("TipoTrabajo") %></span>
                                            <small class="text-muted">#<%# Eval("Id") %></small>
                                        </h6>
                                        <div class="border p-2 mb-2">
                                            <%# Eval("Descripcion") %>
                                        </div>
                                        <p class="card-text">
                                            <%# Eval("Direccion") %>,
                                            <%# Eval("Localidad") %>,
                                            <%# Eval("Provincia") %>
                                        </p>
                                        <small class="text-muted">Tel: <%# Eval("Telefono") %></small>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>