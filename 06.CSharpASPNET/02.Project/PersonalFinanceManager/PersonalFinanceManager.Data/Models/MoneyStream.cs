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
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Display(Name = "Income")]
        public bool IsIncome { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Book Book { get; set; }
        [Required]
        [Display(Name = "Category")]
        public virtual Category Category { get; set; }
        public virtual ApplicationUser Owner { get; set; }
    }
}