﻿using System.Collections;
using System.Collections.Generic;

namespace PizzaMore.Data.Models
{
    public class User
    {
        private ICollection<Pizza> pizzaSuggestions;

        public User()
        {
            this.PizzaSuggestions = new HashSet<Pizza>();
        }

        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Pizza> PizzaSuggestions
        {
            get { return pizzaSuggestions; }
            set { pizzaSuggestions = value; }
        }
    }
}
