using malakar.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace malakar.Dtos
{
    public class ArticleDto: EntityBase
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Brief { get; set; }

        public string Content { get; set; }

        public bool Published { get; set; }

        public DateTime Date { get; set; }
        public string Banner { get; set; }
        public int OwnerId { get; set; }
    }
}