using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.ViewModels.MoneyStreams
{
    public class MoneyStreamsFormVM
    {
        public MoneyStreamsFormVM()
        {
            this.Categories = new List<Category>();
        }
        public int Id { get; set; }        
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"[0-9]*\.?[0-9]+", ErrorMessage = "{0} must be a Number.")]
        public decimal Amount { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [Required]
        [Display(Name = "Expenses Categories")]
        public ICollection<Category> Categories { get; set; }     
        [Display(Name = "Income")]
        public bool IsIncome { get; set; }
        public int BookId { get; set; }
        public int CategoryId { get; set; }
    }
}