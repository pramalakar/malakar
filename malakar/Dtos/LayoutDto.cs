using malakar.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace malakar.Dtos
{
    public class LayoutDto : EntityBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}