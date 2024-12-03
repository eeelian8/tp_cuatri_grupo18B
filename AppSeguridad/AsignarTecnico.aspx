<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AsignarTecnico.aspx.cs" Inherits="AppSeguridad.AsignarTecnico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  

    <div class="container mt-3">
    <div class="row mb-3">
        <%-- Calendario --%>
        <div class="col-7">
            <asp:Calendar ID="calendarioFecha" runat="server" BackColor="White" 
                OnSelectionChanged="calendarioFecha_SelectionChanged" 
                OnDayRender="calendarioFecha_DayRender"
                Width="100%">
            </asp:Calendar>
        </div>
        
        <%--detalles task --%>
        <div class="col-5">
            <div class="card">
                <div class="card-header">
                    <h5>Detalles de la Tarea</h5>
                </div>
                <div class="card-body">
                    <asp:Label ID="lblTipoTrabajo" runat="server" ForeColor="Gray" Text="Tipo: "></asp:Label>
                    <asp:Label ID="lblTT" runat="server"></asp:Label><br />

                    <asp:Label ID="lblTituloCliente" runat="server" ForeColor="Gray" Text="Cliente: " ></asp:Label>
                     <asp:Label ID="lblCliente" runat="server"></asp:Label><br />

                    <asp:Label ID="lblTituloTelefono"  runat="server" ForeColor="Gray" Text="Tel: "></asp:Label>
                         <asp:Label ID="lblTelefono" runat="server"></asp:Label><br />

                    <asp:Label ID="lblTituloDireccion" runat="server" ForeColor="Gray" Text="Direccion: "></asp:Label>
                        <asp:Label ID="lblDireccion" runat="server"></asp:Label><br />

                    <asp:Label ID="lblTituloDescripcion" runat="server" ForeColor="Gray" Text="Descripcion: "></asp:Label>
                    <asp:Label ID="lblDescripcion" runat="server"></asp:Label><br />

                    <asp:Label ID="lblTituloDuracion" runat="server"  ForeColor="Gray" Text="Duracion en dias: "> </asp:Label>
                    <asp:Label ID="lblDuracion" runat="server"></asp:Label><br />
                </div>
            </div>
        </div>
    </div>
    </div>

        <%--repetidor tecnicos --%>
        <div class="row mb-3">
            <div class="col-7">
                <asp:Repeater ID="repTecnicos" runat="server" OnItemDataBound="repTecnicos_ItemDataBound">
                    <ItemTemplate>
                        <div class="card mb-2">
                            <div class="card-body">
                                <asp:RadioButton ID="rbTecnico" runat="server" GroupName="tecnicos"/>
                
                                <asp:Label ID="lblTituloNombre" runat="server" ForeColor="Gray" Text="Nombre: "></asp:Label>
                                <asp:Label ID="lblNombreTecnico" runat="server"></asp:Label><br />

                                <asp:Label ID="lblTituloCelular" runat="server" ForeColor="Gray" Text="Celular: "></asp:Label>
                                <asp:Label ID="lblCelular" runat="server"></asp:Label><br />

                                <asp:Label ID="lblTituloCodigo" runat="server" ForeColor="Gray" Text="Código: "></asp:Label>
                                <asp:Label ID="lblCodigo" runat="server"></asp:Label><br />

                                <asp:Label ID="lblTituloLocalidad" runat="server" ForeColor="Gray" Text="Localidad: "></asp:Label>
                                <asp:Label ID="lblLocalidad" runat="server"></asp:Label>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="col-5">

            <asp:Label ID="lbAvisoExito" runat="server" Text="Asignación de solicitud exitosa!" Visible="False" ForeColor="#33CC33">

            </asp:Label>
    </div>
        </div>

        <%-- btn asignar --%>
        <div class="row">
            <div class="col">
                <asp:Button ID="btnAsignar" runat="server" Text="Asignar Técnico" 
                    CssClass="btn btn-primary" OnClick="btnAsignar_Click" />
                <asp:Button ID="btnVolver" runat="server" Text="Volver" 
                    CssClass="btn btn-secondary ms-2" OnClick="btnVolver_Click" />
            </div>
        </div>
</asp:Content>