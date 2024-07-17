using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Personal_Blog_API.Modles;
using Personal_Blog_API.Repositorues;

namespace Personal_Blog_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private IArticleRepository _articleRepo;

        public ArticlesController(IArticleRepository articleRepo)
        {
            _articleRepo=articleRepo;
        }

        [HttpGet("GetAll")]
       public IActionResult GetAllItem()
        {
            var articles = _articleRepo.GetAllArticle();

            return Ok(articles);
        }

        [HttpGet("GetById")]
        public IActionResult GetArticleById(int id)
        {
            var article = _articleRepo.GetArticleById(id);
            return Ok(article);
        }

        [HttpPost("Add")]
        public IActionResult Add(Article article)
        {
            if (_articleRepo.AddArticle(article))
            {
                return Ok(true);
            }

            return BadRequest();
        }
        [HttpDelete("Delete")]
        public IActionResult Delete(int id)
        {
            if(_articleRepo.DeleteArticle(id))
            {
                return Ok(true);
            }

            return BadRequest();
        }

        [HttpPut("Update")]
        public IActionResult Update(Article article , int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_articleRepo.UpdateArticle(article , id))
            {
                return Ok(article);
            }



            return BadRequest();
        }




    }
}
