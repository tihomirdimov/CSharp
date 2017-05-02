using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceManager.Data.Models
{
    public class MoneyStream
    {
        public MoneyStream()
        {
            IsDeleted = false;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public bool IsIncome { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Book Book { get; set; }
        public virtual Category Category { get; set; }
        public virtual ApplicationUser Owner { get; set; }
    }
}