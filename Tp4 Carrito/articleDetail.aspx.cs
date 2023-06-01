using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using domain;
using commerce;

namespace Tp4_Carrito
{
    public partial class articleDetail : System.Web.UI.Page
    {
        public List<Article> ListadoDeArticulos { get; set; }

        public List<ImageClass> ImageList = new List<ImageClass>();
        protected void Page_Load(object sender, EventArgs e)
        {

            Article art = new Article();
            ArticleConector conector = new ArticleConector();

            ImageClass images = new ImageClass();
            ImageConector iConector = new ImageConector();


            if (Request.QueryString["id"] != null)
            {
                int id = int.Parse(Request.QueryString["id"].ToString());
                art = conector.ListarConId(id);
                lblId.Text = art.ArticleId.ToString();
                lblBrand.Text = art.ArticleBrand.Description;
                lblName.Text = art.Name;
                lblCategory.Text = art.ArticleCategory.Description;
                lblDescription.Text = art.Description;
                lblPrice.Text = art.Price.ToString();

                ImageList = iConector.FetchImageById(id);

                imageRepeater.DataSource = ImageList;
                imageRepeater.DataBind();

            }

        }
    }
}