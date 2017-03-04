namespace PizzaForum.Models
{
    public class Login
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string SessionId { get; set; }
        public bool isActive { get; set; }
    }
}
