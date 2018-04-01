using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace malakar.Models.Helpers
{
    public class SearchArticle
    {
        public int? CategoryId { get; set; }

        public string Title { get; set; }

        public bool? Published { get; set; }
    }
}