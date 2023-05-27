<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tp4_Carrito.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Hello, estamos en el inicio :D</h1>

    <div class="row row-cols-1 row-cols-md-3 g-4">

       <%--<%
            foreach (domain.Article article in ListadoDeArticulos)
            { 
                %>
                        
                 <div class="col">
                    <div class="card h-100">
                        <img src="..." class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%: article.Name  %></h5>
                            <p class="card-text"><%: article.Description  %></p>
                            <a href="#">content</a>
                        </div>
                    </div>
                </div>
   
        <%  } %>--%>

        <asp:Repeater runat="server" ID="repRepeater">
            <ItemTemplate>
                <div class="col">
                    <div class="card h-100">
                        <img src="<%#Eval("ArticleImage") %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Name") %></h5>
                            <p class="card-text"><%#Eval("ArticleBrand") %></p>
                            <p class="card-text"><%#Eval("Description") %></p>
                            <%--<a href="#">content</a> --%>
                            <asp:Button Text="Agregar" CssClass="btn btn-primary" runat="server" ID="btnAgregar" CommandArgument='<%#Eval("ArticleId")%>' CommandName="ArticleId" Onclick="btnAgregar_Click" />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    

    </div>

</asp:Content>
