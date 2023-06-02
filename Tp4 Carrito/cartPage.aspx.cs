using domain;
using System;
using System.Collections.Generic;

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

                Cart currentCart = Session["Cart"] as Cart;
                if (currentCart != null)
                {
                    Master.UpdateCartItemCount(currentCart.GetTotalItems());
                }
            }
        }
    }
}