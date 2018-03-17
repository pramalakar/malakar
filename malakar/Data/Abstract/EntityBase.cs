using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace malakar.Data.Abstract
{
    public abstract class EntityBase : IEntityBase
    {
        public int Id { get; set; }
        [Display(Name = "Status")]
        public int StatusID { get; set; }//Active 1, Inactive 0, Deleted 2

        [ScaffoldColumn(false)]
        public DateTime DateAdded { get; set; }

        public EntityBase()
        {
            DateAdded = DateTime.Now;
        }
    }
}