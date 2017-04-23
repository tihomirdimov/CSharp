using System.Collections.Generic;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.ViewModels.MoneyStreams
{
    public class MoneyStreamIndexViewModel
    {
        public MoneyStreamIndexViewModel()
        {
            this.MoneyStream = new MoneyStream();
            this.MoneyStreams = new List<MoneyStream>();
        }

        public MoneyStream MoneyStream { get; set; }

        public ICollection<MoneyStream> MoneyStreams { get; set; }

        public int BookId { get; set; }
    }
}