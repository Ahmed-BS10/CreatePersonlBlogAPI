using Personal_Blog_API.Dto;
using Personal_Blog_API.Modles;

namespace Personal_Blog_API.Repositorues
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetAllArticle();
        Article GetArticleById(int id);
        bool AddArticle(Article article);
        bool DeleteArticle(int id);
        bool UpdateArticle(Article article , int id);

    }
}
