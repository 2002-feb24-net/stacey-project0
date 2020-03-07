using System;
using System.Collections.Generic;


namespace CornNuggets
{
    class Program
    {
        static void Main(string[] args)
        {
            string cust = GetInput("Please enter the customer's full name: ");
            Customer patron = new Customer();
            patron.AddCustomer(cust);
            patron.SearchCustomer(cust);
            patron.DisplayCust(cust);

        }
        static string GetInput(string message)
        {
            
            Console.WriteLine(message);
            string input = Console.ReadLine();
            return input;

        }
    }
}
