using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PFM.Models;

namespace PFM.ViewModels
{
    public class CreateMoneyStreamViewModel
    {
        public CreateMoneyStreamViewModel()
        {
            this.MoneyStream = new MoneyStream();
            this.Categories = new List<Category>();
        }
        public MoneyStream MoneyStream { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}