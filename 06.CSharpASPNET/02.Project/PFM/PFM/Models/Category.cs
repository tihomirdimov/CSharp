using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PFM.Models;

namespace PersonalFinanceManager.Models
{
    public class Category
    {
        public Category()
        {
            
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ApplicationUser User{ get; set; }
    }
}