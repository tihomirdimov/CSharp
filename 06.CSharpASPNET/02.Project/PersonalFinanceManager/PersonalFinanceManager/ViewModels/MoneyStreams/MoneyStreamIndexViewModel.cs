using System.Collections.Generic;
using PFM.Models;

namespace PFM.ViewModels
{
    public class MoneyStreamIndexViewModel
    {
        public MoneyStreamIndexViewModel()
        {
            this.MoneyStream = new List<MoneyStream>();
        }

        public ICollection<MoneyStream> MoneyStream { get; set; }

        public int? BookId { get; set; }
    }
}