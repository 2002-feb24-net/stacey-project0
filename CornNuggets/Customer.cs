using System.Collections.Generic;
using System;


namespace CornNuggets
{
    class Customer
    {
        public int customerID;
        public string CustName { get; set; }
        static List<string> cust = new List<string>() {"First Customer"};
        public Customer()
        {
            customerID++;
        }

        public void AddCustomer(string next)
        {
            if (isCustomer(next))
            {
                System.Console.WriteLine("Already exist!");
            }
            else
            {
                cust.Add(next);
                System.Console.WriteLine("Added customer.");
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
                Console.WriteLine($"{customerID++} {name}");
            }
        }
    }
}
