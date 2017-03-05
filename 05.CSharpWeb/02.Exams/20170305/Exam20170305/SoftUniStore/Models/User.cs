

namespace SoftUniStore.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.GamesList = new HashSet<Game>();
        }

        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public  ICollection<Game> GamesList { get; set; }
        public bool IsAdmin { get; set; }
    }
}