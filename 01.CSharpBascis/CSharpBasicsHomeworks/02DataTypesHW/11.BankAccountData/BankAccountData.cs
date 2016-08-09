using System;
class BankAccountData
{
    static void Main()
    {
        string firstName = "Tihomir";
        string middleName = "Dimov";
        string lastName = "Dimov";
        decimal balance = 8000.15m;
        string bankName = "Postbank";
        string iban = "BG80BPBI99201001010177";
        ulong creditCard1 = 5467896054904545;
        ulong creditCard2 = 5467896054904547;
        ulong creditCard3 = 5467896054904548;
        Console.WriteLine("Dear {0} {1} {2},", firstName, middleName, lastName);
        Console.WriteLine("Your current balance is: {0} EUR", balance);
        Console.WriteLine("{0}, Iban: {1}", bankName, iban);
        Console.WriteLine("Your credit cards: {0}, {1}, {2}", creditCard1, creditCard2, creditCard3);
    }
}