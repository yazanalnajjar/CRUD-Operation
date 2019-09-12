using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace CRUD_V2.Models
{
    public class User : DbContext
    {

        public int UserID { get; set; }

        [Required(ErrorMessage = "This Field is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string Email { get; set; }

        public int Age { get; set; }

        public int CountryID { get; set; }
    }
}