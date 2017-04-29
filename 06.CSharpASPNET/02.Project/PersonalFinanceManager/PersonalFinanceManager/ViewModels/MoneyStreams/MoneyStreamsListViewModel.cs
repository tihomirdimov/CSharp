using System.Collections.Generic;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.ViewModels.MoneyStreams
{
    public class MoneyStreamsListViewModel
    {
        public MoneyStreamsListViewModel()
        {
            this.MoneyStreams = new List<MoneyStream>();
            this.Book = new Book();
        }
        public ICollection<MoneyStream> MoneyStreams{ get; set; }
        public Book Book { get; set; }        
    }
}