using malakar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace malakar.Controllers
{
    public class ArticleController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ArticleController()
        {
        }

        //POST /api/Article/GetArticlesByCategory?id=1
        [HttpGet]
        [Route("api/Article/GetArticlesByCategory")]
        public IHttpActionResult getArticlesByCategory(int id)
        {
            var result = (from article in db.Article
                         from ab in article.ArticleCategoryToArticle
                         where ab.ArticleCategoryId == id
                         select new
                         {
                             ab.Article.Id,
                             ab.Article.Title,
                             ab.Article.Brief,
                             ab.Article.Content,
                             ab.Article.Published,
                             ab.Article.Date,
                             ab.Article.Banner,
                             ab.Article.OwnerId,
                             //ab.Article.ArticleCategoryToArticle,
                             ab.Article.StatusID,
                             ab.Article.DateAdded
                         });
            return Ok(result.ToList());
        }

    }
}
