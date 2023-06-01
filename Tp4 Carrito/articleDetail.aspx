﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="articleDetail.aspx.cs" Inherits="Tp4_Carrito.articleDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Detalle de pagina</h2>
    <hr />
    <asp:Label Text="" ID="lblId" runat="server" />
    <hr />


    <%-- <asp:Repeater ID="imageRepeater" runat="server">
        <ItemTemplate>
            <img src='<%#Eval("ImageUrl") %>' alt="Imagen del Prdocuto"
                onerror="this.src='https://static.wikia.nocookie.net/videojuego/images/9/9c/Imagen_no_disponible-0.png/revision/latest/thumbnail/width/360/height/360?cb=20170910134200'">
        </ItemTemplate>
    </asp:Repeater>--%>


    <div id="carouselExample" class="carousel slide" data-bs-ride="carousel">
        <div class="carousel-inner">
            <asp:Repeater ID="imageRepeater" runat="server">
                <ItemTemplate>
                    <div class="carousel-item active">
                        <img src='<%# Eval("ImageUrl") %>' class="d-block w-100" alt="Imagen del Articulo" onerror="this.src='https://static.wikia.nocookie.net/videojuego/images/9/9c/Imagen_no_disponible-0.png/revision/latest/thumbnail/width/360/height/360?cb=20170910134200'" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>
    </div>



    <asp:Label Text="" ID="lblBrand" runat="server" />
    <asp:Label Text="" ID="lblCategory" runat="server" />
    <asp:Label Text="" ID="lblName" runat="server" />
    <asp:Label Text="" ID="lblDescription" runat="server" />
    <asp:Label Text="" ID="lblPrice" runat="server" />
    <asp:Label Text="" ID="lblImg" runat="server" />


</asp:Content>
