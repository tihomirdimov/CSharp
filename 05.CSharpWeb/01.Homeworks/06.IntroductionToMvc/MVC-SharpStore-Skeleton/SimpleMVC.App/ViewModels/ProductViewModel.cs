namespace SharpStore.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public override string ToString()
        {
            string template = "<div class=\"col-sm-4\">\r\n" +
                              "<div class=\"thumbnail\">\r\n" +
                              $"<img src=\"{this.ImageUrl}\">\r\n" +
                              "<div class=\"caption\">\r\n" +
                              $"<h3>{this.Name}</h3>\r\n" +
                              $"<p>{this.Price:f2}</p>\r\n<p>" +
                              "<a href=\"#\" class=\"btn btn-primary\" role=\"button\">Buy Now</a>" +
                              "</p>\r\n\t\t\t\t" +
                              "</div>\r\n\t\t\t\t" +
                              "</div>\r\n\t\t\t\t\r\n\t\t\t" +
                              "</div>";
            return template;
        }
    }
}
