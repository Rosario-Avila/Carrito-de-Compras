using domain;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace Tp4_Carrito
{
    public partial class cartPage : System.Web.UI.Page
    {
        public List<ArticleWithCartDetail> ListadoDeArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticleConector conector = new ArticleConector();
            ListadoDeArticulos = conector.GetArticleWithCartDetails();
            List<ArticleWithCartDetail> toShow = new List<ArticleWithCartDetail>();
            Cart cart = Session["Cart"] as Cart;

            if (cart != null) {
                foreach (var item in ListadoDeArticulos)
                {
                    if (cart.HasArticleId(item.ArticleId))
                    {
                        item.Quantity = cart.GetArticleQuantity(item.ArticleId);
                        toShow.Add(item);
                    }
                }

                if (!IsPostBack)
                {
                    repRepeater.DataSource = toShow;
                    repRepeater.DataBind();
                }

                decimal total = 0;
                foreach(var item in toShow)
                {
                    total += item.Price * item.Quantity;
                }

                lblTotal.Text =  total.ToString("0.00");

                Cart currentCart = Session["Cart"] as Cart;
                if (currentCart != null)
                {
                    Master.UpdateCartItemCount(currentCart.GetTotalItems());
                }
            }
           
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {

            Button btnAdd_Click = (Button)sender;
            int artId = int.Parse( btnAdd_Click.CommandArgument);

            Cart cart = Session["Cart"] as Cart;
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            CartArticle current = new CartArticle(artId);

            cart.AddArticle(current);
            Response.Redirect("cartPage.aspx");



        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Button btnDelete_Click = (Button)sender;
            int artId = int.Parse(btnDelete_Click.CommandArgument);

            Cart cart = Session["Cart"] as Cart;
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            CartArticle current = new CartArticle(artId);

            cart.deleteArticle(current);
            Response.Redirect("cartPage.aspx");


        }

        protected void btnDanger_Click(object sender, EventArgs e)
        {
            Button btnDanger_Click = (Button)sender;
            int artId = int.Parse(btnDanger_Click.CommandArgument);

            Cart currentCart = Session["Cart"] as Cart;
            if (currentCart != null)
            {
               
                    CartArticle current = new CartArticle(artId);
                    currentCart.RemoveArticle(current);

                Response.Redirect("cartPage.aspx");
            }

        }
    }
}