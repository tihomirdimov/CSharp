using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceManager.Areas.Administration.ViewModels
{
    public class LockUserVM
    {
        public string Id { get; set; }
        public string Email { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Display(Name = "Locked")]
        public bool LockoutEnabled { get; set; }
    }
}