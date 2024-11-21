<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Tecnico.aspx.cs" Inherits="AppSeguridad.Tecnico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container text-center">
        <div class="row">
            <div class="col"></div>
            <div class="col">
                <div>
                    <asp:Calendar ID="Calendario" runat="server" BackColor="White" BorderColor="Black" DayNameFormat="Full" Font-Names="Verdana" Font-Size="8pt" ForeColor="Black" Height="450px" OnDayRender="Calendario_DayRender" OnSelectionChanged="Calendario_SelectionChanged" OnVisibleMonthChanged="Calendario_VisibleMonthChanged" Width="1050px" CellPadding="4" BorderStyle="Outset" DayStyle-BorderStyle="Outset" ShowGridLines="True" OtherMonthDayStyle-ForeColor="Black" OtherMonthDayStyle-BackColor="#FFFFCC" DayHeaderStyle-BorderStyle="Outset" NextPrevStyle-BorderStyle="None" SelectedDayStyle-BorderWidth="2" BorderWidth="2">
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
                    <asp:Label ID="LabelAction" runat="server" ForeColor="White"></asp:Label><br />
                </div>
                <br />
                <div>
                    <div class="container text-center">
                        <asp:Label ID="lbl_FechaActual" runat="server" Text=""></asp:Label>
                        <div class="row">
                            <div class="col"></div>
                            <div class="col">
                                <asp:Label ID="lbl_Trabajo" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col"></div>
                        </div>
                        <div class="row">
                            <div class="col-3">
                                <asp:Label ID="lbl_FechaInicio" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="col-6"></div>
                            <div class="col-3">
                                <asp:Label ID="lbl_FechaFin" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                    <asp:Button ID="Button1" runat="server" Text="Button" />
                    <asp:Button ID="Button2" runat="server" Text="Button" />
                    <asp:Button ID="Button3" runat="server" Text="Button" />
                </div>
            </div>
            <div class="col"></div>
        </div>
    </div>
</asp:Content>


