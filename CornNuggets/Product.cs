using System.Collections.Generic;
using System;

namespace CornNuggets
{
    class Product : IProduct
    {
        /* Stacey Joseph, Revature, Project 0
         * Store Implementation
         * C:\Revature\stacey-project0\CornNuggets\Product.cs
         * Product Line
        "Nuggets $4 ea: 111 - Habenero, 112 - Nacho, 113 - Blue, 114 - Tomato ");
        "Sauces $1 ea: 222 - Salsa, 223 - Avocado, 224 - Onion, 225 - Cheese ");
        "Drinks $2 ea: 333 - Fizzy, 334 - Tea, 335 - Juice, 336 - Smoothie ");*/
        public string Name { get; set; }
        public int ProdID { get; set; }
        public double Price { get; set; }
        
        List<int> prods = new List<int>();
        List<string> prodNames = new List<string>();
        List<double> prices = new List<double>();

        public Product()
        {
            

        }
        public Product(string name, int id, double price)
        {
            Name = name;
            ProdID = id;
            Price = price;
        }

        public double BuyProduct(int next)
        {
            if (next != 999)
            {
                Console.WriteLine($"Product {next} Purchased. Thank You!");
                //returns the price charged

            }
            return Price;

        }
        public bool isProduct(int next)
        {
            if (prods.Contains(next))
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
        public void AddProduct(string name, int id, double price)
        {
            if (isProduct(id))
            {
                //announce item number exists and update info: name and price
                System.Console.WriteLine("Product Available!");
                Name = name;
                Price = price;

            }
            else
            {
                prods.Add(id);
                System.Console.WriteLine("Added product.");
                Name = name;
                Price = price;
            }

        }

        public void DisplayProducts()
        {
            //show information about product
            Console.WriteLine($"Name: {Name}, ID: {ProdID}, Price: $ {Price}");
        }
    }
}
