namespace domain
{
    public class CartArticle
    {
        public CartArticle(int cartItemId)
        {
            CartItemId = cartItemId;
            Quantity = 1;
        }

        public int CartItemId { get; set; }
        public int Quantity { get; set; }
    }
    
}
