using SimpleMVC.App.MVC.Interfaces;
using System.IO;

namespace SimpleMVC.App.Views.About
{
    public class About : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/about.html");
        }
    }
}
