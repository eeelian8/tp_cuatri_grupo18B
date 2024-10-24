<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Gerente.aspx.cs" Inherits="AppSeguridad.Gerente" %>
<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentScripts" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="card">
            <div class="card-header">
                <h3>Casilla pendientes</h3>
            </div>
            <div class="card-body">
                <div class="list-group">
                    <div class="list-group-item">· Instalacion completa #00720 (Olivos)</div>
                    <div class="list-group-item">· Calculo de presupuesto #00354 (San Isidro)</div>
                    <div class="list-group-item">· Reparacion desperfecto #01072 (Las Toninas) </div>
                </div>
            </div>
        </div>

        <div class="mt-3">
            <asp:Button ID="btnAsignar" runat="server" Text="Asignar trabajo" CssClass="btn btn-primary" />
            <asp:Button ID="btnEstado" runat="server" Text="Estado solicitudes" CssClass="btn btn-secondary ms-2" />
        </div>
    </div>
</asp:Content>