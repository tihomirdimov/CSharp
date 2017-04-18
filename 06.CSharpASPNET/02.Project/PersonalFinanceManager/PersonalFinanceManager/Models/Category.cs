using System.ComponentModel.DataAnnotations;
using PersonalFinanceManager.Models;

namespace PFM.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isDeleted { get; set; }
        public virtual ApplicationUser Owner { get; set; }
    }
}