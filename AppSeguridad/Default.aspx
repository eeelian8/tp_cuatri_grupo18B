<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AppSeguridad.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%--    <div class="dropdown-menu">
        <form class="px-4 py-3">
            <div class="mb-3">
                <label for="exampleDropdownFormEmail1" class="form-label">Email address</label>
                <input type="email" class="form-control" id="exampleDropdownFormEmail1" placeholder="email@example.com">
            </div>
            <div class="mb-3">
                <label for="exampleDropdownFormPassword1" class="form-label">Password</label>
                <input type="password" class="form-control" id="exampleDropdownFormPassword1" placeholder="Password">
            </div>
            <div class="mb-3">
                <div class="form-check">
                    <input type="checkbox" class="form-check-input" id="dropdownCheck">
                    <label class="form-check-label" for="dropdownCheck">
                        Remember me
                    </label>
                </div>
            </div>
            <button type="submit" class="btn btn-primary">Sign in</button>
        </form>
        <div class="dropdown-divider"></div>
        <a class="dropdown-item" href="#">New around here? Sign up</a>
        <a class="dropdown-item" href="#">Forgot password?</a>
    </div>--%>
    <br />
    <br />
    <div class="row">
        <div class="col">
        </div>
        <div class="col-6">
            <br />
            <div class="mb-3">
                <label for="exampleInputEmail1" class="form-label">Usuario</label>
                <asp:TextBox ID="InputUser" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="exampleInputPassword1" class="form-label">Contraseña</label>
                <asp:TextBox ID="InputPassword" class="form-control" runat="server" type="password"></asp:TextBox>
            </div>
            <asp:Button class="btn-crema" ID="btn_Login" type="submit" runat="server" Text="Login" OnClick="btn_Login_Click" />
            <br />
            <br />
            <asp:Label ID="LabelLogin" runat="server" Text="" ForeColor="#EA0000"></asp:Label>
        </div>
        <div class="col">
        </div>
    </div>

</asp:Content>
