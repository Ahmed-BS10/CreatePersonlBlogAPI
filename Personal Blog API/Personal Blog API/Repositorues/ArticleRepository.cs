using Personal_Blog_API.Data;
using Personal_Blog_API.Dto;
using Personal_Blog_API.Modles;

namespace Personal_Blog_API.Repositorues
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly AppDbCnotext _db;
        public ArticleRepository(AppDbCnotext db)
        {
            _db=db;
        }

        public bool AddArticle(Article article)
        {
            if (article == null)
            {
                return false;
            }

            try
            {
                article.createdAt = DateTime.Now;
                _db.articles.Add(article);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteArticle(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            try
            {

                var article = _db.articles.Find(id);

                _db.articles.Remove(article);
                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IEnumerable<Article>  GetAllArticle()
        {
            return _db.articles.ToList();
        }

        public Article  GetArticleById(int id)
        {
            return _db.articles.Find(id);
        }


        public bool UpdateArticle(Article newArticle, int id)
        {
            if (newArticle == null)
            {
                return false;
            }
            try
            {
                Article oldArticle = _db.articles.Find(id);

                //id does not exist
                if (oldArticle == null)
                    return false;

                oldArticle.updatedAt = DateTime.Now;
                oldArticle.Author = newArticle.Author;
                oldArticle.Title = newArticle.Title;


                _db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        
    }
}



