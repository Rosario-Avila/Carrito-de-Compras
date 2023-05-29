<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tp4_Carrito.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Hello, estamos en el inicio :D</h1>

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <asp:Repeater runat="server" ID="repRepeater">
            <ItemTemplate>
                <div class="col">
                    <div class="card h-100">
                        <img 
                            src="<%#Eval("ArticleImage") %>" 
                            class="card-img-top" 
                            alt="Imagen del producto <%#Eval("Name") %>" 
                            onerror="this.src='https://static.wikia.nocookie.net/videojuego/images/9/9c/Imagen_no_disponible-0.png/revision/latest/thumbnail/width/360/height/360?cb=20170910134200'"
                        >
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Name") %></h5>
                            <p class="card-text"><%#Eval("ArticleBrand") %></p>
                            <a href="articleDetail.aspx">Ver mas</a>

                            <asp:Button Text="Ver Mas" CssClass="btn btn-primary" runat="server" ID="verMas" CommandArgument='<%#Eval("ArticleId")%>' CommandName="ArticleId" Onclick="verMas_Click" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    

    </div>

</asp:Content>
