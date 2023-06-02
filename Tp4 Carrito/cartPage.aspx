<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="cartPage.aspx.cs" Inherits="Tp4_Carrito.cartPage" %>

<%@ MasterType VirtualPath="~/Master.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .button-container{
            margin-top:10px;
        }

    </style>

  <asp:Label Text="" ID="probando" runat="server" />

    <section class="h-100" style="background-color: #eee;">
        <div class="container h-100 py-5">
            <div class="row d-flex justify-content-center align-items-center h-100">
                <div class="col-10">

                    <div class="d-flex justify-content-between align-items-center mb-4">
                        <h3 class="fw-normal mb-0 text-black">Shopping Cart</h3>
                    </div>
                    <asp:Repeater runat="server" ID="repRepeater">
                        <ItemTemplate>
                            <div class="card rounded-3 mb-4">
                                <div class="card-body p-4">
                                    <div class="row d-flex justify-content-between align-items-center">
                                        <div class="col-md-2 col-lg-2 col-xl-2">
                                            <img
                                                src="<%#Eval("ArticleImage") %>"
                                                class="img-fluid rounded-3"
                                                alt="Imagen del producto <%#Eval("Name") %>"
                                                onerror="this.src='https://static.wikia.nocookie.net/videojuego/images/9/9c/Imagen_no_disponible-0.png/revision/latest/thumbnail/width/360/height/360?cb=20170910134200'" />
                                        </div>
                                        <div class="col-md-3 col-lg-3 col-xl-3">
                                            <p class="lead fw-normal mb-2"><%#Eval("Name") %></p>
                                            <p><span class="text-muted">Category: </span><%#Eval("ArticleCategory.Description")%> <span class="text-muted">Brand: </span><%#Eval("ArticleBrand") %></p>
                                            <p><span class="text-muted"><%#Eval("Description")%> </span></p>
                                        </div>

                                        <div class="col-md-3 col-lg-3 col-xl-2 d-flex">
                                            <span class="badge text-bg-light"><%#Eval("Quantity") %></span>
                                        </div>

                                        <div class="col-md-3 col-lg-2 col-xl-2 offset-lg-1">
                                            <asp:Label Visible="false" ID="lblArticleId" Text='<%#Eval("ArticleId")%>' runat="server" />
                                            <h5 class="mb-0">$<%#Eval("Price") %></h5>
                                            <asp:Button Text="-" ID="btnDelete" class="btn btn-info" runat="server" OnClick="btnDelete_Click"
                                                CommandArgument='<%# Eval("ArticleId") %>' />
                                            <asp:Button Text="+" ID="btnAdd" class="btn btn-info" runat="server" OnClick="btnAdd_Click"
                                                CommandArgument='<%# Eval("ArticleId") %>' />
                                            <div class="button-container">
                                            <asp:Button Text="Delete" ID="btnDanger" class="btn btn-danger" runat="server" OnClick="btnDanger_Click"
                                                CommandArgument='<%# Eval("ArticleId") %>' />
                                                </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="card">
                        <div class="card-body">
                            <button type="button" class="btn btn-warning btn-block btn-lg">Total to Pay : </button>
                            <asp:Label ID="lblTotal" runat="server"></asp:Label>
                           </div>
                    </div>
                    



                    <div class="card mb-4">
                        <div class="card-body p-4 d-flex flex-row">
                            <div class="form-outline flex-fill">
                                <input type="text" id="form1" class="form-control form-control-lg" />
                                <label class="form-label" for="form1">Discound code</label>
                            </div>
                            <button type="button" class="btn btn-outline-warning btn-lg ms-3">Apply</button>
                        </div>
                    </div>

                    <div class="card">
                        <div class="card-body">
                            <button type="button" class="btn btn-warning btn-block btn-lg">Proceed to Pay</button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>




</asp:Content>
