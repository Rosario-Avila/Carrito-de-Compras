using domain;
using System;
using System.Collections.Generic;

namespace commerce
{
    public class ImageConector
    {
        private List<ImageClass> _images;
        private int _imageIndex;
        public void FindImageById(int ArticleId)
        {
            this._imageIndex = 0;
            this._images = this.FetchImageById(ArticleId);
        }

        public string GetCurremtImg()
        {
            if (this._images != null && this._imageIndex < this._images.Count)
            {
                return this._images[this._imageIndex].ImageUrl;
            }
            return "";
        }

        public void Next()
        {
            if (_imageIndex < (this._images.Count - 1)) { this._imageIndex++; } else { this._imageIndex = 0; }
        }

        public void Previous()
        {
            if (_imageIndex > 0) { this._imageIndex--; }
        }

        private List<ImageClass> FetchImageById(int idArticle)
        {
            List<ImageClass> imageList = new List<ImageClass>();
            DataAccess db = new DataAccess();

            try
            {
                db.setQuery("select Id, IdArticulo, ImagenUrl from IMAGENES where IdArticulo  = " + idArticle);
                db.execute();

                while (db.sqlReader.Read())
                {
                    ImageClass aux = new ImageClass(
                        (!(db.sqlReader["Id"] is DBNull)) ? (int)db.sqlReader["Id"] : 0,
                        (!(db.sqlReader["IdArticulo"] is DBNull)) ? (int)db.sqlReader["IdArticulo"] : 0,
                        (!(db.sqlReader["ImagenUrl"] is DBNull)) ? (string)db.sqlReader["ImagenUrl"] : ""
                        );
                    imageList.Add(aux);
                }
                return imageList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                db.close();
            }
        }
    }
}
