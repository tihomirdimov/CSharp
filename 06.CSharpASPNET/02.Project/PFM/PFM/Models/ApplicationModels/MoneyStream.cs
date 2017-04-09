﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PFM.Models.ApplicationModels
{
    public class MoneyStream
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public bool isIncome { get; set; }
        public virtual Book Book { get; set; }
        public virtual Category Category { get; set; }
        public virtual ApplicationUser Owner { get; set; }
    }
}