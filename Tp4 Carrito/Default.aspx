<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tp4_Carrito.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Hello, estamos en el inicio :D</h1>

    <div class="row row-cols-1 row-cols-md-3 g-4">

        <%
            foreach (domain.Article article in ListadoDeArticulos)
            { 
                %>
                        
                 <div class="col">
                    <div class="card h-100">
                        <img src="..." class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%: article.Name  %></h5>
                            <p class="card-text"><%: article.Description  %></p>
                        </div>
                    </div>
                </div>
   
        <%  } %>
    </div>
            


    <asp:GridView runat="server" ID="dgvArticle" CssClass="table" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Name" DataField="Name" />
            <asp:BoundField HeaderText="Description" DataField="Description" />
            <asp:BoundField HeaderText="Price" DataField="Price" />
            <asp:BoundField HeaderText="Brand" DataField="ArticleBrand.Description" />
            <asp:BoundField HeaderText="Category" DataField="ArticleCategory.Description" />

        </Columns>
    </asp:GridView> 

</asp:Content>
