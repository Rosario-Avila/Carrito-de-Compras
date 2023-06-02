using System.Collections.Generic;

namespace domain
{
    public class Cart
    {
        List<CartArticle> ArtList = new List<CartArticle>();

        public void AddArticle(CartArticle art)
        {
            CartArticle existingArticle = ArtList.Find(a => a.CartItemId == art.CartItemId);
            if (existingArticle != null)
            {
                existingArticle.Quantity++;
            }
            else
            {
                ArtList.Add(art);
            }
        }

        public void RemoveArticle(CartArticle art)
        {
            ArtList.Remove(art);
        }

        public CartArticle GetArticle(int id)
        {
            return ArtList.Find(a => a.CartItemId == id);
        }

        public List<CartArticle> GetArticles()
        {
            return ArtList;
        }

        public int GetTotalItems()
        {
            int total = 0;
            foreach (var article in ArtList)
            {
                total += article.Quantity;
            }
            return total;
        }
    }
}
