using System.Collections.Generic;
using PersonalFinanceManager.Data.Models;

namespace PersonalFinanceManager.ViewModels.MoneyStreams
{
    public class MoneyStreamsListVM
    {
        public MoneyStreamsListVM()
        {
            this.MoneyStreams = new List<MoneyStream>();
        }
        public ICollection<MoneyStream> MoneyStreams{ get; set; }
        public int BookId { get; set; }        
    }
}