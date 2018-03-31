using malakar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace malakar.Dtos
{
    public class WidgetDto
    {
        public int Id { get; set; }
        public WidgetType Type { get; set; }
        public int Order { get; set; }
        public string Key { get; set; }
        public string Data { get; set; }
        public string Image { get; set; }

        public int WidgetRowId { get; set; }
    }
}