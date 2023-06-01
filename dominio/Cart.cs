using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domain
{
    class Cart
    {
       List<Article> ArtList = new List<Article>();

        public void addArticle(Article art)
        {
            ArtList.Add(art);
        }

        public void removeArticle(Article art)
        {
            ArtList.Remove(art);
        }

        public List<Article> getArticle()
        {
            return ArtList;
        }

    }
}
