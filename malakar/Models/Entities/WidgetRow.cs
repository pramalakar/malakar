using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace malakar.Models
{
    public class WidgetRow
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }

        public int LayoutId { get; set; }
        public Layout Layout { get; set; }

        public ICollection<Widget> Widget { get; set; }
    }
}