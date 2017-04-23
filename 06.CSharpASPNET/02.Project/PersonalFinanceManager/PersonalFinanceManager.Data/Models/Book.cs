using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceManager.Data.Models
{
    public class Book
    {
        public Book()
        {
            this.isDeleted = false;
            this.MoneyStreams = new List<MoneyStream>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public bool isDeleted { get; set; }
        public ICollection<MoneyStream> MoneyStreams { get; set; }
        public virtual ApplicationUser Owner { get; set; }
    }
}