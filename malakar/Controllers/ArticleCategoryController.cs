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
                             articleCategory.Banner
                         };
            return Ok(result);
        }

        [HttpPost]
        [Route("api/Article/CreateCategory")]
        public ArticleCategoryDto createLayout(ArticleCategoryDto articleCategoryDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            //layoutDto.StatusID = 1;
            var articleCategory = Mapper.Map<ArticleCategoryDto, ArticleCategory>(articleCategoryDto);

            db.ArticleCategory.Add(articleCategory);
            db.SaveChanges();

            articleCategoryDto.Id = articleCategory.Id;
            return articleCategoryDto;
        }

    }
}
