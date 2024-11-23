<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AsignarTecnico.aspx.cs" Inherits="AppSeguridad.AsignarTecnico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-3">
        <%-- Calendario miausis --%>
        <div class="row mb-3">
            <div class="col">
                <asp:Calendar ID="calFecha" runat="server" BackColor="White" 
                    OnSelectionChanged="calFecha_SelectionChanged" 
                    OnDayRender="calFecha_DayRender"
                    Width="70%">
                </asp:Calendar>
            </div>
        </div>

        <%--repetidor tecnicos --%>
        <div class="row mb-3">
            <div class="col">
                <asp:Repeater ID="repTecnicos" runat="server" OnItemDataBound="repTecnicos_ItemDataBound">
                    <ItemTemplate>
                        <div class="card mb-2">
                            <div class="card-body">
                                <asp:RadioButton ID="rbTecnico" runat="server" GroupName="tecnicos"/>
                                <asp:Label ID="lblNombreTecnico" runat="server"></asp:Label>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

        <%-- btn asignar --%>
        <div class="row">
            <div class="col">
                <asp:Button ID="btnAsignar" runat="server" Text="Asignar Técnico" 
                    CssClass="btn btn-primary" OnClick="btnAsignar_Click" />
            </div>
        </div>
    </div>
</asp:Content>