<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="articleDetail.aspx.cs" Inherits="Tp4_Carrito.articleDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Detalle de pagina</h2>
    <hr />
    <asp:Label Text="" ID="lblId" runat="server" />
    <hr />
    <asp:ImageMap ID="ImgArt" runat="server"
     onerror="this.src='https://static.wikia.nocookie.net/videojuego/images/9/9c/Imagen_no_disponible-0.png/revision/latest/thumbnail/width/360/height/360?cb=20170910134200'"></asp:ImageMap>

    <asp:Label Text="" ID="lblBrand" runat="server" />
    <asp:Label Text="" ID="lblCategory" runat="server" />
    <asp:Label Text="" ID="lblName" runat="server" />
    <asp:Label Text="" ID="lblDescription" runat="server" />
    <asp:Label Text="" ID="lblPrice" runat="server" />
    <asp:Label Text="" ID="lblImg" runat="server" />
    
     <%-- <div id="carouselExample" class="carousel slide">

        <asp:Repeater runat="server" ID="repRepeater">
            <ItemTemplate>
                <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="<%#Eval("ImageUrl")%>" class="d-block w-10" alt="..."
                    onerror="this.src='https://static.wikia.nocookie.net/videojuego/images/9/9c/Imagen_no_disponible-0.png/revision/latest/thumbnail/width/360/height/360?cb=20170910134200'">
          
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

            </ItemTemplate>
        </asp:Repeater>
         </div>--%>

<%--    <%
      foreach (domain.Article art in ListadoDeArticulos)
      {
       %>
        
            <%if ( TxtId.Text == art.ArticleId.ToString())
                {
                    %>

        <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="<%:art.ArticleImage%>" class="d-block w-10" alt="..."
                    onerror="this.src='https://static.wikia.nocookie.net/videojuego/images/9/9c/Imagen_no_disponible-0.png/revision/latest/thumbnail/width/360/height/360?cb=20170910134200'">
          
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

   <% } %>
    </div>--%>


</asp:Content>
