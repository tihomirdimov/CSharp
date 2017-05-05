using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; }
        public virtual ApplicationUser Owner { get; set; }
    }
}