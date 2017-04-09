using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PFM.Models.ApplicationModels
{
    public class Book
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public virtual ICollection<MoneyStream> MoneyStreams { get; set; }
        public virtual ApplicationUser Owner { get; set; }
    }
}