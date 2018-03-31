using malakar.Data.Abstract;
using malakar.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace malakar.Models
{
    public class Article: EntityBase
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string Title { get; set; }

        [MaxLength(255)]
        public string Brief { get; set; }

        public string Content { get; set; }

        public bool Published { get; set; }

        public DateTime Date { get; set; }
        public string Banner { get; set; }
        public int OwnerId { get; set; }

        public virtual ICollection<ArticleCategoryToArticle> ArticleCategoryToArticle { get; set; }
    }
}