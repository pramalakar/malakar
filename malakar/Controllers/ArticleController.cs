﻿using AutoMapper;
using malakar.Data;
using malakar.Dtos;
using malakar.Models;
using malakar.Models.Entities;
using malakar.Models.Helpers;
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

        //Get /api/Article/GetArticlesByCategory?id=1
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

        //POST /api/Article/GetArticlesByCategory?id=1
        [HttpPost]
        [Route("api/Article/SearchArticle")]
        public IHttpActionResult searchArticle(SearchArticle searchArticle)
        {
            try
            {
                var result = (from article in db.Article
                              from ab in article.ArticleCategoryToArticle
                              select new
                              {
                                  ab.ArticleCategoryId,
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
                              }).AsQueryable();

                if (searchArticle != null)
                {
                    if (searchArticle.CategoryId.HasValue)
                        result = result.Where(x => x.ArticleCategoryId == searchArticle.CategoryId);
                    if (!string.IsNullOrEmpty(searchArticle.Title))
                        result = result.Where(x => x.Title.Contains(searchArticle.Title));
                    if (searchArticle.Published.HasValue)
                        result = result.Where(x => x.Published == searchArticle.Published);

                }

                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("api/Article/CreateArticle")]
        public ArticleDto createLayout(int id, ArticleDto articleDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var articleCategory = db.ArticleCategory.Where(c => c.Id == id).SingleOrDefault();
            if (articleCategory != null)
            {
                articleDto.StatusID = 1;
                var article = Mapper.Map<ArticleDto, Article>(articleDto);

                var articleCategoryToArticle = new ArticleCategoryToArticle
                {
                    Article = article,
                    ArticleCategory = articleCategory
                };

                db.ArticleCategoryToArticle.Add(articleCategoryToArticle);
                db.SaveChanges();

                articleDto.Id = article.Id;
                return articleDto;
            }
            return null;
        }

}
}
