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

        public void deleteArticle(CartArticle art)
        {
            CartArticle existingArticle = ArtList.Find(a => a.CartItemId == art.CartItemId);
            if (existingArticle != null && existingArticle.Quantity>0)
            {
                existingArticle.Quantity--;
            }
        }


        public void RemoveArticle(CartArticle art)
        {
            CartArticle current = GetArticle(art.CartItemId);
            ArtList.Remove(current);
        }

        public CartArticle GetArticle(int id)
        {
            return ArtList.Find(a => a.CartItemId == id);
        }

        public bool HasArticleId(int id)
        {
            return ArtList.Contains(GetArticle(id));
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

        public int GetArticleQuantity(int id)
        {
            return GetArticle(id).Quantity;
        }
    }
}
