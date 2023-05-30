<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="articleDetail.aspx.cs" Inherits="Tp4_Carrito.articleDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Detalle de pagina</h2>
    <hr />

    <asp:Label Text="text" ID="lblId" runat="server" />

    <div id="carouselExample" class="carousel slide">


    <%
      foreach (domain.Article art in ListadoDeArticulos)
      {
       %>

        <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="<%:art.ArticleImage%>" class="d-block w-10" alt="..."
                    onerror="this.src='https://static.wikia.nocookie.net/videojuego/images/9/9c/Imagen_no_disponible-0.png/revision/latest/thumbnail/width/360/height/360?cb=20170910134200'">
                <h5 class="carousel-dark"><%:art.Name%></h5>
                <p class="text-bg-info"><%:art.ArticleId %></p>
                <p class="text-bg-info"><%:art.ArticleBrand %></p>
                <p class="text-bg-info"><%:art.ArticleCategory %></p>
                <p class="text-bg-info"><%:art.Description %></p>
                <p></p>
            </div>
        </div>
        <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
        </button>

   <% } %>
    </div>


</asp:Content>
