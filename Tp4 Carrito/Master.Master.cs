using domain;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tp4_Carrito
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Cart currentCart = Session["Cart"] as Cart;
            if (currentCart != null && currentCart.GetTotalItems() > 0)
            {
                lblItemCountSpan.Style["display"] = "inline-flex;";
            }
            else
            {
                lblItemCountSpan.Style["display"] = "none";
            }
        }

        public void UpdateCartItemCount(int itemCount)
        {
            lblItemCount.Text = itemCount.ToString();
            lblItemCountNav.Text = itemCount.ToString();
            lblItemCountSpan.Style["display"] = "inline-flex;";
        }
    }
}