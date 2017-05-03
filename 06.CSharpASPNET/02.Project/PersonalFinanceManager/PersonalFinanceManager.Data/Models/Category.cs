using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceManager.Data.Models
{
    public class Category
    {
        public Category()
        {
            IsDeleted = false;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ApplicationUser Owner { get; set; }
    }
}