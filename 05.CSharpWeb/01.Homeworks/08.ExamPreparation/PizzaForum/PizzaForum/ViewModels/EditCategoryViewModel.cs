namespace PizzaForum.ViewModels
{
    public class EditCategoryViewModel
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public override string ToString()
        {
            string representation = "<form method = \"POST\" >\r\n\r\n" +
                             "<label > Name </ label >\r\n\r\n" +
                             "<div class=\"form-group\">\r\n" +
                             $"<input type = \"hidden\" class=\"form-control\" value=\"{this.Id}\" name=\"categoryId\" />\r\n\t" +
                             $" <input type = \"text\" class=\"form-control\" value=\"{this.CategoryName}\" name=\"categoryName\"/>\r\n\t" +
                             "</div>\r\n\t\t" +
                             "<input type = \"submit\" class=\"btn btn-primary\" value=\"Edit Category\"/>\r\n\t" +
                             "</form>";
            return representation;
        }
    }
}


