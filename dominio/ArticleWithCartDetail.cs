namespace domain
{
    public class ArticleWithCartDetail: Article
    {
        public int Quantity { get; set; }
        public decimal PriceOld { get; set; }
    }
}

