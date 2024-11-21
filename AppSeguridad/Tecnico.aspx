<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Tecnico.aspx.cs" Inherits="AppSeguridad.Tecnico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="container">
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
            <asp:Label ID="LabelAction" runat="server"></asp:Label><br />
        </div>
    </div>
</asp:Content>
