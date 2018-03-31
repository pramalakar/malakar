using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace malakar.Models.Entities
{
    public class ArticleCategoryToArticle
    {
        public int Id { get; set; }
        public int ArticleCategoryId { get; set; }
        public int ArticleId { get; set; }

        public virtual ArticleCategory ArticleCategory{ get; set; }
        public virtual Article Article { get; set; }
    }
}