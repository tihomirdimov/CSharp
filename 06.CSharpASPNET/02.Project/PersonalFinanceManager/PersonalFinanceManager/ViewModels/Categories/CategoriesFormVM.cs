using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceManager.ViewModels.Categories
{
    public class CategoriesFormVM
    {
        public int Id { get; set; }
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 3)]
        public string Name { get; set; }
    }
}