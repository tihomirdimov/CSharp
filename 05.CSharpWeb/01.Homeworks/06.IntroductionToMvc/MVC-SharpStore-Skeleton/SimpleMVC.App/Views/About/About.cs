using System.IO;
using SimpleMVC.Interfaces;

namespace SharpStore.Views.About
{
    public class About : IRenderable
    {
        public string Render()
        {
            return File.ReadAllText("../../content/about.html");
        }
    }
}
