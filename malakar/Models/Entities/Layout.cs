using malakar.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace malakar.Models
{
    public class Layout: EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<WidgetRow> WidgetRows { get; set; }
    }
}