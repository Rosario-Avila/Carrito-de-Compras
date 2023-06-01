using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp4_Carrito
{
    public partial class cartPage : System.Web.UI.Page
    {
        public string idArt { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            idArt = Session["idArticulo"] != null ? Session["idArticulo"].ToString() : "";
            probando.Text = "el id es : " + idArt;
        }
    }
}