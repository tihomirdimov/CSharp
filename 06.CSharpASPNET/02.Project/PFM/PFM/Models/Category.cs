using System.ComponentModel.DataAnnotations;

namespace PFM.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ApplicationUser Owner { get; set; }
    }
}