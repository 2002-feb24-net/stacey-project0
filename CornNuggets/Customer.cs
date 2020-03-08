using System.Collections.Generic;
using System;


namespace CornNuggets
{
    class Customer
    {
        public int customerID;
        static List<string> cust = new List<string>() {"First Customer"};
        public Customer()
        {
            customerID++;
        }

        public void AddCustomer(string next) => cust.Add(next);
        public void SearchCustomer(string name)
        {
            if (cust.Contains(name))
            {
                Console.WriteLine("Customer Found");
            }
            else
            {
                Console.WriteLine("No Match Found");
            }
            
        }
        public void DisplayCustomers()
        {
            foreach (string name in cust)
            {
                Console.WriteLine($"{customerID++} {name}");
            }
        }
    }
}
