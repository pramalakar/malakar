using malakar.Data.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace malakar.Models
{
    public class User : EntityBase
    {
        public int ID { get; set; }

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

        [Display(Name = "Contact Number")]
        [MaxLength(20)]
        public string ContactNo { get; set; }

        [Display(Name = "Role")]
        public int RoleID { get; set; } //superadmin, admin, user
    }
}