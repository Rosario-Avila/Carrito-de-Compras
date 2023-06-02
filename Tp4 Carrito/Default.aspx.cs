using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using domain;

namespace Tp4_Carrito
{

    public partial class Default : System.Web.UI.Page
    {
        public List<Article> ListadoDeArticulos { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticleConector conector = new ArticleConector();
            ListadoDeArticulos = conector.ListarConSp();


            if (!IsPostBack)
            {
                repRepeater.DataSource = ListadoDeArticulos;
                repRepeater.DataBind();
            }

            Cart currentCart = Session["Cart"] as Cart;
            if (currentCart != null)
            {
                Master.UpdateCartItemCount(currentCart.GetTotalItems());
            }
        }

        protected void verMas_Click(object sender, EventArgs e)
        {

            Button verMas = (Button)sender;
            string id = verMas.CommandArgument;

            Response.Redirect("articleDetail.aspx?id=" + id);
        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            Button btnAgregar = (Button)sender;
            string id = btnAgregar.CommandArgument;

            // Obtener el carrito actual de la sesión
            Cart currentCart = Session["Cart"] as Cart;
            if (currentCart == null)
            {
                currentCart = new Cart();
                Session["Cart"] = currentCart;
            }

            // Crear un objeto CartArticle con el ID convertido a entero
            int articleId;
            if (int.TryParse(id, out articleId))
            {
                CartArticle articleToAdd = new CartArticle(articleId);

                currentCart.AddArticle(articleToAdd);
                Session["Cart"] = currentCart;
                Master.UpdateCartItemCount(currentCart.GetTotalItems());
            }
        }
    }
}