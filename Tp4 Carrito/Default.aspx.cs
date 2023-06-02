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
        public Repeater RepeaterCart
        {
            get { return ((MasterPage)Master).FindControl("repeaterCart") as Repeater; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticleConector conector = new ArticleConector();
            ListadoDeArticulos = conector.ListarConSp();


            if (!IsPostBack)
            {
                repRepeater.DataSource = ListadoDeArticulos;
                repRepeater.DataBind();
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
            }
            UpdateCartItemCount();
        }
        protected void UpdateCartItemCount()
        {
            MasterPage master = Master as MasterPage;
            if (master != null)
            {
                Label lblTotalItems = master.FindControl("lblTotalItems") as Label;
                if (lblTotalItems != null)
                {
                    Cart currentCart = Session["Cart"] as Cart;
                    if (currentCart != null)
                    {
                        int totalItems = currentCart.GetTotalItems();
                        lblTotalItems.Text = totalItems.ToString();
                    }
                    else
                    {
                        lblTotalItems.Text = "0";
                    }
                }
            }
        }
    }
}