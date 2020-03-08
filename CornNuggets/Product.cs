using System.Collections.Generic;
using System;

namespace CornNuggets
{
    class Product
    {
        int productID;

        List<string> nuggets = new List<string> {"Blue", "Habenaro", "Nacho", "Tomato"};
        List<string> sauces = new List<string> {"Salsa", "Cheese", "Avocado", "Onion"};
        List<string> drinks = new List<string> {"Fizzy", "Tea","Juice", "Smoothie"};
        
        public void BuyProduct(int item)
        {
            Console.WriteLine($"Product {item} Purchased. Thank You!");
        }
        static void SearchProduct(string name)
        {
            Console.WriteLine("Hello World!");
        }
        static void DisplayOrder(string[] args)
        {
            Console.WriteLine("Here's your orderd!");
        }
    }
}
