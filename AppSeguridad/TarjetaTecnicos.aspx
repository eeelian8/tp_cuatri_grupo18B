<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="TarjetaTecnicos.aspx.cs" Inherits="AppSeguridad.TarjetaTecnicos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Bootstrap CSS (si no está ya incluido en tu MasterPage) -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="row">
            <% foreach (var tecnico in ListaTecnicos) { %>
                <div class="col-md-4 mb-4">
                    <div class="card">
                        <img src='<%= !string.IsNullOrEmpty(tecnico.ImgUrl) ? tecnico.ImgUrl : "https://thumbs.dreamstime.com/z/perfil-de-usuario-vectorial-avatar-predeterminado-179376714.jpg?ct=jpeg" %>' class="card-img-top" alt='<%= tecnico.Nombre + " " + tecnico.Apellido %>' />
                        <div class="card-body">
                            <h5 class="card-title"><%= tecnico.Nombre + " " + tecnico.Apellido %></h5>
                            <p class="card-text text-primary">
                                <strong>Código Tecnico:</strong> <%= tecnico.CodTecnico %><br>
                                <strong>Rol:</strong> <%= tecnico.NivelRol %><br>
                                <strong>Contacto:</strong> <%= tecnico.Celular %><br>
                                <strong>Localidad:</strong> <%= tecnico.Localidad %>, <%= tecnico.Provincia %><br>
                                <strong>Documento:</strong> <%= tecnico.NroDocumento %>

                            </p>
                        </div>
                    </div>
                </div>
            <% } %>
        </div>
    </div>
</asp:Content>