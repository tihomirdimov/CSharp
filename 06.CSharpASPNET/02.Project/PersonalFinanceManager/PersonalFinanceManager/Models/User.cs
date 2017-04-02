using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceManager.Models
{
    using System.Collections.Generic;

    public class User
    {
        public User(string email, string password, string firstName, string lastName)
        {
            this.Email = email;
            this.Password = password;
            this.FirstName = firstName;
            this.LastName= lastName;
        }
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Account> Accounts { get; set; }
        public virtual ICollection<MoneyStreamCategory> Categories { get; set; }
        public virtual ICollection<MoneyStream> MoneyStreams { get; set; }
    }
}