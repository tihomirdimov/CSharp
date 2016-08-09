using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace _01InterfacesAndAbstractionProblem04
{
    public class Smartphone : ICaller, IBrowser
    {
        public string CallPhoneNumber(string phoneNumber)
        {
            foreach (var character in phoneNumber)
            {
                if (!char.IsDigit(character))
                {
                    return "Invalid number!";
                }
            }
            return $"Calling... {phoneNumber}";
        }

        public string BrowseWebsite(string website)
        {
            foreach (var character in website)
            {
                if (char.IsDigit(character))
                {
                    return "Invalid URL!";
                }
            }
            return $"Browsing: {website}!";
        }
    }

    public interface ICaller
    {
        string CallPhoneNumber(string phoneNumber);
    }

    public interface IBrowser
    {
        string BrowseWebsite(string website);
    }

    class Startup
    {
        static void Main()
        {
            var phoneNumbers = Console.ReadLine().Split(new[] { ' ' }); ;
            var websites = Console.ReadLine().Split(new[] { ' ' }); ;
            var smartphone = new Smartphone();
            foreach (var phoneNumber in phoneNumbers)
            {
                Console.WriteLine(smartphone.CallPhoneNumber(phoneNumber));
                
            }
            foreach (var website in websites)
            {
                Console.WriteLine(smartphone.BrowseWebsite(website));
                
            }
        }
    }
}
