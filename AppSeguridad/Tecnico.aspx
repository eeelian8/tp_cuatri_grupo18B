<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Tecnico.aspx.cs" Inherits="AppSeguridad.Tecnico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        #trabajoActual {
            background-color: ghostwhite;
            border-radius: 12px;
        }

        #usr {
            display: flex;
            align-content: end;
            justify-content: end;
            flex-wrap: wrap;
            flex-flow: row;
        }
    </style>
    <br />
    <div id="usr">
        <img src="Images/logoUsuario.png" alt="Logo Usuario" height="35" width="40" />
        <asp:Label ID="txtUsuario" runat="server" BorderStyle="None" Font-Bold="True" Font-Size="Larger" ForeColor="White" Font-Italic="True"></asp:Label>
    </div>
    <br />
    <div class="container text-center">
        <div class="row">
            <div class="col"></div>
            <div class="col">
                <div>
                    <asp:Calendar ID="Calendario" runat="server" BackColor="White" BorderColor="Black" DayNameFormat="Full" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="450px" OnDayRender="Calendario_DayRender" Width="1050px" CellPadding="4" BorderStyle="Outset" DayStyle-BorderStyle="Outset" ShowGridLines="True" OtherMonthDayStyle-ForeColor="Black" OtherMonthDayStyle-BackColor="#FFFFCC" DayHeaderStyle-BorderStyle="Outset" NextPrevStyle-BorderStyle="None" SelectedDayStyle-BorderWidth="2" BorderWidth="2">
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" BackColor="#CCCCCC" />
                        <NextPrevStyle VerticalAlign="Bottom" />
                        <SelectedDayStyle BackColor="#666666" ForeColor="White" Font-Bold="True" />
                        <SelectorStyle BackColor="#CCCCCC" />
                        <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                        <TodayDayStyle BackColor="Yellow" ForeColor="Black" BorderStyle="Outset" BorderWidth="2" />
                    </asp:Calendar>
                </div>
                <br />
                <div>
                    <div class="container text-center" id="trabajoActual">
                        <br />
                        <div class="row">
                            <div class="col-3">
                                <asp:Label ID="lbl_FechaActual" runat="server" Text="" Font-Size="Medium"></asp:Label>
                            </div>
                            <div class="col-5"></div>
                            <div class="col-4"></div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col"></div>
                            <div class="col">
                                <asp:Label ID="lbl_Trabajo" runat="server" Font-Size="Large" BorderStyle="None" Font-Bold="True"></asp:Label>
                            </div>
                            <div class="col"></div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-3">
                                <asp:Label ID="lbl_FechaInicio" runat="server" Text="" Font-Size="Medium"></asp:Label>
                            </div>
                            <div class="col-6"></div>
                            <div class="col-3">
                                <asp:Label ID="lbl_FechaFin" runat="server" Text="" Font-Size="Medium"></asp:Label>
                            </div>
                        </div>
                        <br />
                    </div>
                    <br />
                    <asp:Button ID="btn_verDetalle" runat="server" Text="Ver Detalle" CssClass="btn-crema" OnClick="btn_verDetalle_Click" />
                    <asp:Button ID="btn_informar" runat="server" Text="Crear Informe" CssClass="btn-crema" OnClick="btn_informar_Click" />
                    <asp:Button ID="btn_cambiarEstado" runat="server" Text="Cambiar estado" CssClass="btn-crema" />
                </div>
            </div>
            <div class="col"></div>
        </div>
    </div>
</asp:Content>


