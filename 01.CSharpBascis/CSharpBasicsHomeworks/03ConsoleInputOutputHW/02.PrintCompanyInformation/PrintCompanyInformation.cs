using System;
class PrintCompanyInformation
{
    static void Main()
    {
        Console.Write("Please enter company name:");
        string name = Console.ReadLine();
        Console.Write("Please enter company address:");
        string address = Console.ReadLine();
        Console.Write("Please enter company phone:");
        string phone = Console.ReadLine();
        Console.Write("Please enter company fax:");
        string fax = Console.ReadLine();
        Console.Write("Please enter company web address:");
        string web = Console.ReadLine();
        Console.Write("Please enter company manager's first name:");
        string FirstName = Console.ReadLine();
        Console.Write("Please enter company manager's last name:");
        string LastName = Console.ReadLine();
        Console.Write("Please enter company manager's age:");
        string age = Console.ReadLine();
        Console.Write("Please enter company manager's phone number:");
        string PersonalPhone = Console.ReadLine();
        if (string.IsNullOrEmpty(name) == true)
        {
            name = "(no name)";
        }
        if (string.IsNullOrEmpty(address) == true)
        {
            address = "(no address)";
        }
        if (string.IsNullOrEmpty(phone) == true)
        {
            phone = "(no phone)";
        }
        if (string.IsNullOrEmpty(fax) == true)
        {
            fax = "(no fax)";
        }
        if (string.IsNullOrEmpty(web) == true)
        {
            web = "(no web)";
        }
        if (string.IsNullOrEmpty(FirstName) == true)
        {
            FirstName = "(no first name)";
        }
        if (string.IsNullOrEmpty(LastName) == true)
        {
            LastName = "(no last name)";
        }
        if (string.IsNullOrEmpty(age) == true)
        {
            age = "(no age)";
        }
        if (string.IsNullOrEmpty(PersonalPhone) == true)
        {
            PersonalPhone = "(no personal phone)";
        }
        Console.WriteLine("{0}\nAddress: {1}\nTel. {2}\nFax: {3}\nWeb site: {4}\nManager: {5} {6} (age: {7}, tel. {8})", name, address, phone, fax, web, FirstName, LastName, age, PersonalPhone );
    }
}
