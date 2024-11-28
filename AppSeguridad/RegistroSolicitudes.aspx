<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistroSolicitudes.aspx.cs" Inherits="AppSeguridad.RegistroSolicitudes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
        <asp:GridView ID="gvRegistroSolicitudes" runat="server" OnSelectedIndexChanged="gvRegistroSolicitudes_SelectedIndexChanged"
            CssClass="table table-hover" AutoGenerateColumns="false"
            EmptyDataText="No hay solicitudes activas"
            ShowHeaderWhenEmpty="True">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="TipoTrabajo" HeaderText="Tipo de Trabajo y Días" />
                <asp:BoundField DataField="Nombre" HeaderText="Cliente" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />
                <asp:BoundField DataField="TecnicoAsignado" HeaderText="Tecnico" />
                <asp:BoundField DataField="Localidad" HeaderText="Localidad" />

                <asp:TemplateField>
                    <ItemTemplate>
                            <asp:Button ID="btnSeleccionar" runat="server" CommandName="Select" 
                                Text="Seleccionar" CssClass="btn btn-secondary btn-sm"/>
                        </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

            <div class="col-md-6">
            <div class="card mt-3" id="cardDetalles" runat="server" >
            <div class="card-header">
                <h5>Detalles de la Solicitud</h5>
            </div>
            <div class="card-body">
                <asp:Label ID="lblTipoTrabajo" runat="server" ForeColor="Gray" Text="Tipo: "></asp:Label>
                    <asp:Label ID="lblTT" runat="server"></asp:Label><br />

                <asp:Label ID="lblTituloCliente" runat="server" ForeColor="Gray" Text="Cliente: "></asp:Label>
                    <asp:Label ID="lblCliente" runat="server"></asp:Label><br />

                <asp:Label ID="lblTituloTecnico" runat="server" ForeColor="Gray" Text="Tecnico: "></asp:Label>
                <asp:Label ID="lblTecnico" runat="server"></asp:Label><br />

                <asp:Label ID="lblTituloFechaInicio" runat="server" ForeColor="Gray" Text="Fecha Inicio: "></asp:Label>
                    <asp:Label ID="lblFechaInicio" runat="server"></asp:Label><br />

                <asp:Label ID="lblTituloFechaFin" runat="server" ForeColor="Gray" Text="Fecha Fin: "></asp:Label>
                    <asp:Label ID="lblFechaFin" runat="server"></asp:Label><br />

                <asp:Label ID="lblTituloDireccion" runat="server" ForeColor="Gray" Text="Direccion: "></asp:Label>
                <asp:Label ID="lblDireccion" runat="server"></asp:Label><br />

                <asp:Label ID="lblTituloDescripcion" runat="server" ForeColor="Gray" Text="Descripcion: "></asp:Label>
                <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
            </div>
            </div>
        </div>
        
        <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-secondary" OnClick="btnVolver_Click" />
    

</asp:Content>
