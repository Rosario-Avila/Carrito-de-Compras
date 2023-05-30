using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using domain;

namespace Tp4_Carrito
{
    public partial class articleDetail : System.Web.UI.Page
    {
        public List<Article> ListadoDeArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticleConector conector = new ArticleConector();
            ListadoDeArticulos = conector.ListarConSp();

            /* if (Request.QueryString["id"] != null)
             {
                 string id = Request.QueryString["id"].ToString();


             }*/

        }
    }
}