<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AppSeguridad.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        body {
            background-color: #343A40;
            color: white;
        }
    </style>
    <br />
    <br />
    <div class="row">
        <div class="col">
        </div>
        <div class="col-6">
            <asp:ListBox ID="ListBoxLogin" class="form-select form-select-sm" runat="server" Rows="1" Font-Bold="True">
                <asp:ListItem Value="1" Text="Administrador"></asp:ListItem>
                <asp:ListItem Value="2" Text="Gerente"></asp:ListItem>
                <asp:ListItem Value="3" Text="Recepcionista"></asp:ListItem>
                <asp:ListItem Value="4" Text="Tecnico"></asp:ListItem>
            </asp:ListBox>
            <br />
            <div class="mb-3">
                <label for="exampleInputEmail1" class="form-label">Usuario</label>
                <asp:TextBox ID="InputUser" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="exampleInputPassword1" class="form-label">Contraseña</label>
                <asp:TextBox ID="InputPassword" class="form-control" runat="server" type="password"></asp:TextBox>
            </div>
            <asp:Button class="btn btn-primary" ID="btn_Login" type="submit" runat="server" Text="Login" OnClick="btn_Login_Click" />
            <br />
            <br />
            <asp:Label ID="LabelLogin" runat="server" Text="" ForeColor="#EA0000"></asp:Label>
        </div>
        <div class="col">
        </div>
    </div>

</asp:Content>
