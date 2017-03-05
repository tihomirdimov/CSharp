namespace SoftUniStore.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Game
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Trailer { get; set; }
        public string Image { get; set; }
        public decimal Size { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}