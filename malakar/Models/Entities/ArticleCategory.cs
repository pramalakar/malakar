using malakar.Data.Abstract;
using malakar.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace malakar.Models
{
    public class ArticleCategory: EntityBase
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public string Content { get; set; }
        public string Banner{ get; set; }

        public virtual ICollection<ArticleCategoryToArticle> ArticleCategoryToArticle { get; set; }
    }
}