using AutoMapper;
using malakar.Data;
using malakar.Dtos;
using malakar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace malakar.Controllers
{
    public class ArticleCategoryController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ArticleCategoryController()
        {
        }


        // To populate Categories (Id, Name) in dropdown list
        //Get /api/Article/getCategoryNames
        [HttpGet]
        [Route("api/Article/getCategoryNames")]
        public IHttpActionResult getCategoryNames()
        {
            var result = from articleCategory in db.ArticleCategory
                          select new
                          {
                              articleCategory.Id,
                              articleCategory.Name
                          };
            return Ok(result);
        }


        //Get /api/Article/getAllCategory
        [HttpGet]
        [Route("api/Article/getAllCategory")]
        public IHttpActionResult getAllCategory()
        {
            var result = from articleCategory in db.ArticleCategory
                         select new
                         {
                             articleCategory.Id,
                             articleCategory.Name,
                             articleCategory.Content,
                             articleCategory.Banner,
                             articleCategory.StatusID
                         };
            return Ok(result);
        }

        [HttpPost]
        [Route("api/Article/CreateCategory")]
        public ArticleCategoryDto createCategory(ArticleCategoryDto articleCategoryDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            articleCategoryDto.StatusID = 1;
            var articleCategory = Mapper.Map<ArticleCategoryDto, ArticleCategory>(articleCategoryDto);

            db.ArticleCategory.Add(articleCategory);
            db.SaveChanges();

            articleCategoryDto.Id = articleCategory.Id;
            return articleCategoryDto;
        }

        //TODO delete category record in articleCategoryToArticles table also
        // DELETE /api/category?id=1
        [HttpDelete]
        [Route("api/Article/DeleteCategory")]
        public void deleteCategory(int id)
        {
            var categoryInDb = db.ArticleCategory.SingleOrDefault(l => l.Id == id);

            if (categoryInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            db.ArticleCategory.Remove(categoryInDb);
            db.SaveChanges();
        }

        //PUT /api/article/updateCategory
        //Update status = 2 to delete category (Active 1, Inactive 0, Deleted 2)
        //Category contains articles, so not actually deleted but just set status to deleted
        [HttpPut]
        [Route("api/Article/UpdateCategory")]
        public void updateCategory(int id, ArticleCategoryDto articleCategoryDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var categoryInDb = db.ArticleCategory.SingleOrDefault(c => c.Id == id);

            if (categoryInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map<ArticleCategoryDto, ArticleCategory>(articleCategoryDto, categoryInDb);

            db.SaveChanges();
        }

    }
}
