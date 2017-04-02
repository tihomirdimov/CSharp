using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalFinanceManager.Models
{
    public class Account
    {
        public Account(User owner,string name)
        {
            this.Owner = owner;
            this.Name = name;
        }
        [Key]
        public int Id { get; set; }
        public User Owner { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
    }
}