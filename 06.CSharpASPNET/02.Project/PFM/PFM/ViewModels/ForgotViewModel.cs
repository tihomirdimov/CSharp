using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PFM.Models;

namespace PFM.ViewModels
{
    public class ForgotViewModel
    {
        [Required]
        public List<Category> Books { get; set; }
    }
}