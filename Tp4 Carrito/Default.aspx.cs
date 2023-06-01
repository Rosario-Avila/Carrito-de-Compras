using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using commerce;
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
            
        }

        protected void verMas_Click(object sender, EventArgs e)
        {

            Button verMas = (Button)sender;
            string id = verMas.CommandArgument;

            Response.Redirect("articleDetail.aspx?id=" + id);
        }

        protected void Agregar_Click(object sender, EventArgs e)
        {
            Button Agregar = (Button)sender;
            string id = Agregar.CommandArgument;

            Session.Add("idArticulo", id);

            Response.Redirect("cartPage.aspx", false);
        }
    }
}