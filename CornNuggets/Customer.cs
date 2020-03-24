using System.Collections.Generic;
using System;


namespace CornNuggets
{
    class Customer
    {
        public string CustName { get => custName; set => custName = value; }
        public int CustomerID { get; set; }

        static List<string> cust = new List<string>() { "First Customer" };
        private string custName;

        public Customer()
        {
            CustomerID++;
        }

        public void AddCustomer(string next)
        {
            if (isCustomer(next))
            {
                System.Console.WriteLine("Customer already exist!");
            }
            else
            {
                cust.Add(next);
                System.Console.WriteLine($"Added customer: {next}");
            }
        }
        public bool isCustomer(string name)
        {
            if (cust.Contains(name))
            {
                //Console.WriteLine("Customer Found");
                return true;
            }
            else
            {
                //Console.WriteLine("No Match Found");
                return false;
            }

        }
        public void DisplayCustomers()
        {
            foreach (string name in cust)
            {
                Console.WriteLine($"{CustomerID++} {name}");
            }
        }
    }
}
