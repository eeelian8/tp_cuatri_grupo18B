<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="TarjetaTecnicos.aspx.cs" Inherits="AppSeguridad.TarjetaTecnicos" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <asp:Repeater ID="repTarjetas" runat="server">
                <ItemTemplate>
                    <div class="col-md-4 mb-4">
                        <div class="card h-100 shadow-sm">
                            <img src='<%# Eval("ImagenUrl") %>' 
                                 class="card-img-top" 
                                 alt='<%# Eval("Nombre") %>'
                                 style="object-fit: cover; height: 250px;">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Nombre") %></h5>
                                <p class="card-text"><%# Eval("CodTecnico") %></p>
                                <a href="#" class="btn-crema">Ver más</a>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>

