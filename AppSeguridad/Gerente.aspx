<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Gerente.aspx.cs" Inherits="AppSeguridad.Gerente" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ContentScripts" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <asp:GridView ID="gv_solicitudes" runat="server" 
            CssClass="table table-hover" 
            AutoGenerateColumns="False"
            OnSelectedIndexChanged="gv_solicitudes_SelectedIndexChanged"
            DataKeyNames="Id"
            EmptyDataText="No hay solicitudes pendientes"
            ShowHeaderWhenEmpty="True">     
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Dni" HeaderText="DNI" />
                <asp:BoundField DataField="TipoTrabajo" HeaderText="Tipo de Trabajo y Duracion" />
                <asp:BoundField DataField="Nombre" HeaderText="Cliente" />

                <asp:BoundField DataField="Descripcion" HeaderText="Descripcion" />


                <asp:BoundField DataField="Telefono" HeaderText="Nro Tel" />
                <asp:BoundField DataField="Provincia" HeaderText="Prov" />
                <asp:BoundField DataField="Localidad" HeaderText="Localidad" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnSelect" runat="server" CommandName="Select" 
                            Text="Seleccionar" CssClass="btn btn-secondary btn-sm"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>



    <!-- Botón para ir a Tarjetas de Técnicos -->
    <asp:Button ID="btnTarjetasTecnicos" runat="server" Text="Ver Tarjetas de Técnicos"
        CssClass="btn btn-primary" OnClick="btnTarjetasTecnicos_Click" />

    <div class="mt-3">
        <asp:Button ID="btnAsignarTrabajo" runat="server" Text="Asignar trabajo" CssClass="btn btn-secondary " OnClick="btnAsignarTrabajo_Click"
            Enabled="false" />
        <asp:Button ID="btnRegistroSolicitudes" runat="server" Text="Registro Trabajos Asignados" CssClass="btn btn-primary" OnClick="btnRegistroSolicitudes_Click" />
    </div>

</asp:Content>
