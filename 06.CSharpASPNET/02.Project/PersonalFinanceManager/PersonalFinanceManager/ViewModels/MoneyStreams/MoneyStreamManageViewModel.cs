using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.ViewModels.MoneyStreams
{
    public class MoneyStreamManageViewModel
    {
        public MoneyStreamManageViewModel()
        {
            this.MoneyStream = new MoneyStream();
            this.Categories = new List<Category>();
        }

        public MoneyStream MoneyStream { get; set; }
        public ICollection<Category> Categories { get; set; }
        public int BookId { get; set; }
    }
}