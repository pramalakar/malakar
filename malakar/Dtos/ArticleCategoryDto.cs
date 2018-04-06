using malakar.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace malakar.Dtos
{
    public class ArticleCategoryDto : EntityBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public string Banner { get; set; }
    }
}