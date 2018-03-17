using malakar.Data.Abstract;
using malakar.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace malakar.Models
{
    public class User : EntityBase
    {
        [Display(Name = "First Name")]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(100)]
        public string LastName { get; set; }

        [MaxLength(255)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }

        [Display(Name = "Role")]
        public int RoleId { get; set; } // Superadmin, Admin, User

        public virtual Role Role { get; set; }
    }
}