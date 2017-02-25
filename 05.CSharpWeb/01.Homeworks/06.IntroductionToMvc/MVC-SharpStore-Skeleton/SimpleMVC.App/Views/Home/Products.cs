using System.Collections.Generic;
using System.IO;
using System.Text;
using SharpStore.ViewModels;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace SharpStore.Views.Home
{
    class Products : IRenderable<IEnumerable<ProductViewModel>>
    {
        string template = File.ReadAllText("../../content/products.html");
        public string Render()
        {
            StringBuilder builder = new StringBuilder();
            foreach (var viewModel in Model)
            {
                builder.Append(viewModel);
            }
            return string.Format(template, builder.ToString());
        }
        public IEnumerable<ProductViewModel> Model { get; set; }
    }
}
