<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AppSeguridad.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <div class="row">
        <div class="col">
        </div>
        <div class="col-6">
            <div class="px-4 py-3">
                <div class="mb-3">
                    <label for="exampleInputEmail1" class="form-label">Usuario</label>
                    <asp:TextBox ID="InputUser" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="exampleInputPassword1" class="form-label">Contraseña</label>
                    <asp:TextBox ID="InputPassword" class="form-control" runat="server" type="password"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="dropdownCheck">
                        <label class="form-check-label" for="dropdownCheck">
                            Recordar
                        </label>
                    </div>
                </div>
                <asp:Button class="btn-crema" ID="btn_Login" type="submit" runat="server" Text="Login" OnClick="btn_Login_Click" />
            </div>
            <br />
            <asp:Label ID="LabelLogin" runat="server" Text="" ForeColor="#CC3300" Font-Size="Large"></asp:Label>
        </div>
        <div class="col">
        </div>
    </div>

</asp:Content>
