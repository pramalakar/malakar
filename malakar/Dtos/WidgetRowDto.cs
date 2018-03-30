using malakar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace malakar.Dtos
{
    public class WidgetRowDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }

        public int LayoutId { get; set; }
    }
}