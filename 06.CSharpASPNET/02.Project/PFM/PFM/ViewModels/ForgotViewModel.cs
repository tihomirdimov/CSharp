using System.ComponentModel.DataAnnotations;

namespace PFM.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}