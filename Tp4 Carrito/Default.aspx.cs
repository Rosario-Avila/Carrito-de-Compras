using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using domain;
using System.Linq;

namespace Tp4_Carrito
{

    public partial class Default : System.Web.UI.Page
    {
        public List<ArticleWithCartDetail> ListadoDeArticulos { get; set; }

        public List<Article> ArtList = new List<Article>();

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticleConector conector = new ArticleConector();
            ListadoDeArticulos = conector.GetArticleWithCartDetails();
            ArtList = ListadoDeArticulos.Cast<Article>().ToList();


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

        protected void goToCard_Click(object sender, EventArgs e)
        {
            Response.Redirect("cartPage.aspx");
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
                repRepeater.DataSource = ListadoDeArticulos;
                repRepeater.DataBind();
            }
        }

        protected void Remove_Click(object sender, EventArgs e)
        {
            Button ItemToRemove = (Button)sender;
            string id = ItemToRemove.CommandArgument;

            // Obtener el carrito actual de la sesión
            Cart currentCart = Session["Cart"] as Cart;
            if (currentCart != null)
            {
                int articleId;
                if (int.TryParse(id, out articleId))
                {
                    CartArticle current = new CartArticle(articleId);
                    currentCart.RemoveArticle(current);
                    Session["Cart"] = currentCart;
                    Master.UpdateCartItemCount(currentCart.GetTotalItems());    
                    repRepeater.DataSource = ListadoDeArticulos;
                    repRepeater.DataBind();
                }
            }
        }

        protected void repRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ArticleWithCartDetail article = e.Item.DataItem as ArticleWithCartDetail;

                Button btnAgregado = e.Item.FindControl("BtnAgregado") as Button;
                Button btnAgregar = e.Item.FindControl("BtnAgregar") as Button;
                Button btnEliminar = e.Item.FindControl("BtnEliminar") as Button;

                Cart currentCart = Session["Cart"] as Cart;

                if (currentCart != null && currentCart.HasArticleId(article.ArticleId))
                {
                    btnAgregado.Visible = true;
                    btnEliminar.Visible = true;  
                    btnAgregar.Visible = false;
                }
                else
                {
                    btnAgregar.Visible = true;
                    btnEliminar.Visible = false;
                    btnAgregado.Visible = false;
                }
            }
        }

        
            protected void BtnFilter_Click(object sender, EventArgs e)
            {
                string filter = TxtFilter.Text;

               List<Article> listaFiltrada = 
               ArtList.FindAll(x => x.Name.ToUpper().Contains(filter.ToUpper())
               || x.ArticleBrand.Description.ToUpper().Contains(filter.ToUpper())
               || x.ArticleCategory.Description.ToUpper().Contains(filter.ToUpper())
               );

               repRepeater.DataSource = listaFiltrada;
                repRepeater.DataBind();
            }


        
    }
}