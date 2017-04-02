using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PFM.Models;

namespace PersonalFinanceManager.Models
{
    public class Account
    {
        public Account()
        {
            
        }

        [Key]
        public int Id { get; set; }
        public ApplicationUser Owner { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
}