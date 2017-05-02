using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceManager.ViewModels.Books
{
    public class BooksFormVM
    {
        public int Id { get; set; }
        [Required]
        [StringLength(int.MaxValue, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [MaxLength(3)]
        public string Currency { get; set; }
    }
}