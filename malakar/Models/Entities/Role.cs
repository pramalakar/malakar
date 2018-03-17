using malakar.Data.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace malakar.Models.Entities
{
    public class Role
    {
        public int Id { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}