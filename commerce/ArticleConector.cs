using System;
using System.Collections.Generic;

namespace domain
{
    public class ArticleConector
    {
        public List<Article> Listar()
        {
            List<Article> ArticlesList = new List<Article>();
            DataAccess data = new DataAccess();

            try
            {
                data.setQuery("Select A.Id as artId, Nombre as name, A.Descripcion as artDescrip, Codigo as artCode, Precio as price, C.Descripcion as category, A.IdCategoria as categoryId, " +
                    "M.Descripcion as brand, A.IdMarca as brandId From ARTICULOS A, CATEGORIAS C, MARCAS M Where C.Id = A.IdCategoria And M.Id = A.IdMarca");
                data.execute();

                while (data.sqlReader.Read())
                {
                    Article aux = new Article();
                    aux.ArticleId = (!(data.sqlReader["artId"] is DBNull)) ? (int)data.sqlReader["artId"] : 0;
                    aux.Name = (!(data.sqlReader["name"] is DBNull)) ? (string)data.sqlReader["name"] : "";
                    aux.Description = (!(data.sqlReader["artDescrip"] is DBNull)) ? (string)data.sqlReader["artDescrip"] : "";
                    aux.ArticleCode = (!(data.sqlReader["artCode"] is DBNull)) ? (string)data.sqlReader["artCode"] : "";
                    aux.Price = (!(data.sqlReader["price"] is DBNull)) ? (decimal) data.sqlReader["price"] : 0;
                    aux.ArticleCategory = new Category(
                        (!(data.sqlReader["categoryId"] is DBNull)) ? (int)data.sqlReader["categoryId"] : 0,
                        (!(data.sqlReader["category"] is DBNull)) ? (string)data.sqlReader["category"] : ""
                        );
                    aux.ArticleBrand = new Brand(
                        (!(data.sqlReader["brandId"] is DBNull)) ? (int)data.sqlReader["brandId"] : 0,
                        (!(data.sqlReader["brand"] is DBNull)) ?(string)data.sqlReader["brand"] : ""
                        );
              
                    ArticlesList.Add(aux);
                }
                return ArticlesList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.close();
            }
        }

        public List<Article> ListarConSp()
        {
            List<Article> list = new List<Article>();
            DataAccess data = new DataAccess();
            try
            {
                data.setSp("SP_Article");


                data.execute();

                while (data.sqlReader.Read())
                {

                    Article aux = new Article();
                    aux.ArticleId = (!(data.sqlReader["artId"] is DBNull)) ? (int)data.sqlReader["artId"] : 0;
                    aux.Name = (!(data.sqlReader["Nombre"] is DBNull)) ? (string)data.sqlReader["Nombre"] : "";
                    aux.Description = (!(data.sqlReader["artDescrip"] is DBNull)) ? (string)data.sqlReader["artDescrip"] : "";
                    aux.ArticleCode = (!(data.sqlReader["artCode"] is DBNull)) ? (string)data.sqlReader["artCode"] : "";
                    aux.Price = (!(data.sqlReader["price"] is DBNull)) ? (decimal)data.sqlReader["price"] : 0;
                    aux.ArticleCategory = new Category(
                        (!(data.sqlReader["categoryId"] is DBNull)) ? (int)data.sqlReader["categoryId"] : 0,
                        (!(data.sqlReader["category"] is DBNull)) ? (string)data.sqlReader["category"] : ""
                        );
                    aux.ArticleBrand = new Brand(
                        (!(data.sqlReader["brandId"] is DBNull)) ? (int)data.sqlReader["brandId"] : 0,
                        (!(data.sqlReader["brand"] is DBNull)) ? (string)data.sqlReader["brand"] : ""
                        );

                    list.Add(aux);
                }
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Modify(Article article)
        {
            DataAccess dataAcces = new DataAccess();

            try
            {
                dataAcces.setQuery("update Articulos set Codigo = @cod , Nombre = @name, Descripcion = @description, IdMarca = @idMarca, Precio = @price, IdCategoria = @categoria  where Id= @id");
                dataAcces.setearParametro("@cod", article.ArticleCode);
                dataAcces.setearParametro("@name", article.Name);
                dataAcces.setearParametro("@description", article.Description);
                dataAcces.setearParametro("@idMarca", article.ArticleBrand.Id);
                dataAcces.setearParametro("@categoria", article.ArticleCategory.Id);
                dataAcces.setearParametro("@id", article.ArticleId);
                dataAcces.setearParametro("@price", article.Price);

                dataAcces.executeAction();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                dataAcces.close();
            }

        }

        public int CreateNewArticle(Article newArt)
        {
            DataAccess acces = new DataAccess();

            try
            {
                string query = "INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, Precio) OUTPUT Inserted.ID values('" + newArt.ArticleCode + "', '" + newArt.Name + "', '" + newArt.Description +"', " + newArt.ArticleBrand.Id + ", " + newArt.ArticleCategory.Id + ", " + newArt.Price + ")";
                acces.setQuery(query);
                int newArticleId = (int) acces.executeScalar();
                acces.ClearQuery();

                acces.setQuery("INSERT INTO IMAGENES (IdArticulo, ImagenUrl) values(" + newArticleId + ", '"+ newArt.Image + "')");
                acces.executeAction();
                return newArticleId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Listar();
                acces.close();
            }
        }

        public void eliminar(int id)
        {
            try
            {
                DataAccess data = new DataAccess();
                data.setQuery("delete from Articulos where id = @id");
                data.setearParametro("@id", id);
                data.executeAction();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Article> filtrar(string campo, string criterio, string filter)
         {
            List<Article> list = new List<Article>();
            DataAccess data = new DataAccess();
            try
            {
                string consulta = "Select A.Id as artId, A.Nombre, A.Descripcion as artDescrip, Codigo as artCode, Precio as price, C.Descripcion as category, A.IdCategoria as categoryId, " +
                    "M.Descripcion as brand, A.IdMarca as brandId From ARTICULOS A, CATEGORIAS C, MARCAS M Where C.Id = A.IdCategoria And M.Id = A.IdMarca AND ";
                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += "Precio > " + filter;
                            break;
                        case "Menor a":
                            consulta += "Precio < " + filter;
                            break;
                        case "Descripcion":
                            consulta += "Precio = " + filter;
                            break;
                    }
                }else{
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "A." + campo + " like '" + filter + "%' ";
                            break;
                        case "Termina con":
                            consulta += "A." + campo + " like '%" + filter + "'";
                            break;
                        case "Contiene":
                            consulta += "A." + campo + " like '%" + filter + "%' ";
                            break;
                    }
                }

                data.setQuery(consulta);
                data.execute();
                while (data.sqlReader.Read())
                {

                    Article aux = new Article();
                    aux.ArticleId = (!(data.sqlReader["artId"] is DBNull)) ? (int)data.sqlReader["artId"] : 0;
                    aux.Name = (!(data.sqlReader["Nombre"] is DBNull)) ? (string)data.sqlReader["Nombre"] : "";
                    aux.Description = (!(data.sqlReader["artDescrip"] is DBNull)) ? (string)data.sqlReader["artDescrip"] : "";
                    aux.ArticleCode = (!(data.sqlReader["artCode"] is DBNull)) ? (string)data.sqlReader["artCode"] : "";
                    aux.Price = (!(data.sqlReader["price"] is DBNull)) ? (decimal)data.sqlReader["price"] : 0;
                    aux.ArticleCategory = new Category(
                        (!(data.sqlReader["categoryId"] is DBNull)) ? (int)data.sqlReader["categoryId"] : 0,
                        (!(data.sqlReader["category"] is DBNull)) ? (string)data.sqlReader["category"] : ""
                        );
                    aux.ArticleBrand = new Brand(
                        (!(data.sqlReader["brandId"] is DBNull)) ? (int)data.sqlReader["brandId"] : 0,
                        (!(data.sqlReader["brand"] is DBNull)) ? (string)data.sqlReader["brand"] : ""
                        );

                    list.Add(aux);
                }
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }   
}

