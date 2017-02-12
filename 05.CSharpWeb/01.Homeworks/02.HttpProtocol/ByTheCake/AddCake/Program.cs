using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddCake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Content-type: text/html\r\n");
            Console.WriteLine("<form action=\"\" method=\"POST\">\r\n" +
                              "<label for=\"name\">Name: </label>\r\n" +
                              "<input type=\"text\" id=\"name\" name=\"name\">\r\n" +
                              "<label for=\"price\">Price: </label>\r\n" +
                              "<input type=\"text\" id=\"price\" name=\"price\">\r\n" +
                              "<input type=\"submit\" value=\"Add Cake\">\r\n" +
                              "</form>");
            string postedContent = Console.ReadLine();
            Console.WriteLine(postedContent);
        }
    }
}
