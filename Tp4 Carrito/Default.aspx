﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Tp4_Carrito.Default" %>

<%@ MasterType VirtualPath="~/Master.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Productos en stock!</h1>

    <asp:TextBox ID="TxtFilter" runat="server"></asp:TextBox>
    <asp:Button ID="BtnFilter" Text="buscar" class="btn btn-dark"  runat="server" OnClick="BtnFilter_Click" />

    <section style="background-color: #eee;">
        <div class="container py-5">
            <div class="row">
                <asp:Repeater runat="server" ID="repRepeater" OnItemDataBound="repRepeater_ItemDataBound">
                    <ItemTemplate>
                        <div class="col-md-6 col-lg-4 mb-4 mb-md-0">
                            <div class="card">
                                <img
                                    src="<%#Eval("ArticleImage") %>"
                                    class="card-img-top"
                                    alt="Imagen del producto <%#Eval("Name") %>"
                                    onerror="this.src='https://static.wikia.nocookie.net/videojuego/images/9/9c/Imagen_no_disponible-0.png/revision/latest/thumbnail/width/360/height/360?cb=20170910134200'" />

                                <div class="card-body">
                                    <div class="d-flex justify-content-between">
                                        <p class="small"><a href="#!" class="text-muted"><%#Eval("ArticleCategory.Description") %></a></p>
                                        <p class="small text-danger"><s>$<%#Eval("PriceOld") %></s></p>
                                    </div>

                                    <div class="d-flex justify-content-between mb-3">
                                        <h5 class="mb-0"><%#Eval("Name") %></h5>
                                        <p class="card-text"><%#Eval("ArticleBrand") %></p>
                                        <h5 class="text-dark mb-0">$<%#Eval("Price") %></h5>
                                    </div>

                                    <asp:Label Visible="false" ID="lblArticleId" Text='<%#Eval("ArticleId")%>' runat="server" />

                                    <asp:Button Text="Ver Mas" CssClass="btn btn-primary" runat="server"
                                        ID="verMas" OnClick="verMas_Click"
                                        CommandArgument='<%#Eval("ArticleId")%>'
                                        NavigateUrl='<%# String.Format("articleDetail.aspx?id={0}", Eval("ArticleId")) %>' />

                                    <asp:Button
                                        Text="Agregado!"
                                        CssClass="btn btn-primary"
                                        runat="server" ID="BtnAgregado"
                                        OnClick="goToCard_Click"
                                        Visible="false" />
                                    <asp:Button
                                        Text="Agregar al carrito"
                                        CssClass="btn btn-primary"
                                        runat="server" ID="BtnAgregar"
                                        OnClick="Agregar_Click"
                                        CommandArgument='<%# Eval("ArticleId") %>'
                                        UseSubmitBehavior="false"
                                        Visible="false" />
                                    <asp:Button
                                        Text="Eliminar"
                                        CssClass="btn btn-danger"
                                        runat="server" ID="BtnEliminar"
                                        OnClick="Remove_Click"
                                        CommandArgument='<%# Eval("ArticleId") %>'
                                        UseSubmitBehavior="false"
                                        Visible="false" />
                                    <div>
                                    <asp:Button Text="-" ID="btnRestar" 
                                        class="btn btn-info" runat="server" 
                                        OnClick="btnRestar_Click"
                                        CommandArgument='<%# Eval("ArticleId") %>' />
                                    <asp:Button Text="+" ID="btnSumar" 
                                        class="btn btn-info" runat="server" 
                                        OnClick="btnSumar_Click"
                                        CommandArgument='<%# Eval("ArticleId") %>' />
                                    </div>

                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </section>

</asp:Content>
