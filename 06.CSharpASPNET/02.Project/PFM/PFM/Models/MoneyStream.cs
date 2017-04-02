using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalFinanceManager.Models
{
    public class MoneyStream
    {
        public MoneyStream()
        {
            
        }

        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Category Category { get; set; }
        public Account Account { get; set; }
        public bool IsIncome { get; set; }
        public decimal Amount;
    }
}