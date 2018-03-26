using malakar.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace malakar.Models
{
    public class Widget : EntityBase
    {
        public int Id { get; set; }
        public WidgetType Type { get; set; }
        public int Order { get; set; }
        public string Key { get; set; }
        public string Data { get; set; }
        public string Image { get; set; }

        public int WidgetRowId { get; set; }
        public WidgetRow WidgetRow { get; set; }
    }

    public enum WidgetType
    {
        Pending = 1,
        Active = 2,
        Blocked = 3
    }
}