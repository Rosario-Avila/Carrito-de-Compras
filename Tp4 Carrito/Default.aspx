<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tp4_Carrito.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
    <h1>Hello, estamos en el inicio :D</h1>

    <asp:GridView runat="server" ID="dgvArticle" CssClass="table" AutoGenerateColumns="false">
   <Columns>
       <asp:BoundField HeaderText="Name" DataField ="Name" />
       <asp:BoundField HeaderText="Description" DataField ="Description" />
       <asp:BoundField HeaderText="Price" DataField ="Price" />
       <asp:BoundField HeaderText="Brand" DataField ="ArticleBrand.Description" />
       <asp:BoundField HeaderText="Category" DataField ="ArticleCategory.Description" />

   </Columns>
    </asp:GridView>
    
</asp:Content>
