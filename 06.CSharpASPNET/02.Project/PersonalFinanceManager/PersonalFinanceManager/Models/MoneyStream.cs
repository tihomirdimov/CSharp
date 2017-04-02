using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonalFinanceManager.Models
{
    public class MoneyStream
    {
        public MoneyStream(DateTime date, MoneyStreamCategory category, Account account, bool isIncome, decimal amount)
        {
            this.Date = date;
            this.Category = category;
            this.Account = account;
            this.IsIncome = isIncome;
            this.Amount = amount;
        }
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public MoneyStreamCategory Category { get; set; }
        public Account Account { get; set; }
        public bool IsIncome { get; set; }
        public decimal Amount;
    }
}