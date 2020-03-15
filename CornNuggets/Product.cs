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
        /*public enum itemCodes
        {
            Habenero = 111,
            Nacho =112,
            Blue = 113,
            Tomato = 114,
            Salsa = 222,
            Avocado = 223, 
            Onion = 224,
            Cheese  = 25,
            Fizzy = 333,
            Tea = 334,
            Juice = 335,
            Smoothie = 336

        }*/
        List<int> prods = new List<int>();
        List<string> prodNames = new List<string>();
        List<double> prices = new List<double>();

        public Product()
        {
            //
            prods.Add(112);
            prods.Add(113);
            prods.Add(114);
            prods.Add(115);
            prods.Add(222);
            prods.Add(223);
            prods.Add(224);
            prods.Add(225);
            prods.Add(333);
            prods.Add(334);
            prods.Add(335);
            prods.Add(336);
            //product name list
            prodNames.Add("Habenero");
            prodNames.Add("Nacho");
            prodNames.Add("Blue");
            prodNames.Add("Tomato");
            prodNames.Add("Salsa");
            prodNames.Add("Avocado");
            prodNames.Add("Onion");
            prodNames.Add("Cheese");
            prodNames.Add("Fizzy");
            prodNames.Add("Tea");
            prodNames.Add("Juice");
            prodNames.Add("Smoothie");
            //price list
            prices.Add(4.0);
            prices.Add(4.0);
            prices.Add(4.0);
            prices.Add(4.0);
            prices.Add(1.0);
            prices.Add(1.0);
            prices.Add(1.0);
            prices.Add(1.0);
            prices.Add(2.0);
            prices.Add(2.0);
            prices.Add(2.0);
            prices.Add(2.0);


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
            Console.WriteLine($"Name: {Name}, ID: {ProdID}, Price: {Price}");
        }
    }
}
