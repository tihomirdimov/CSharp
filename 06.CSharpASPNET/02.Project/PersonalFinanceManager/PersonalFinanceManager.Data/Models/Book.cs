using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PersonalFinanceManager.Data.Models
{
    public class Book
    {
        public Book()
        {
            this.IsDeleted = false;
            this.MoneyStreams = new List<MoneyStream>();
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public bool IsDeleted { get; set; }
        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; }      
        public virtual ApplicationUser Owner { get; set; }
        public virtual ICollection<MoneyStream> MoneyStreams { get; set; }
    }
}