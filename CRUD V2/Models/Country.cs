using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace CRUD_V2.Models
{
    public class Country : DbContext
    {

        public int CountryID { get; set; }

        public string CountryName { get; set; }
    }
}