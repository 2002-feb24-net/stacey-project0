using System.Collections.Generic;
using System;

namespace CornNuggets
{
    class Product
    {
        /* Product Line
        "Nuggets $4 ea: 111 - Habenero, 112 - Nacho, 113 - Blue, 114 - Tomato ");
        "Sauces $1 ea: 222 - Salsa, 223 - Avocado, 224 - Onion, 225 - Cheese ");
        "Drinks $2 ea: 333 - Fizzy, 334 - Tea, 335 - Juice, 336 - Smoothie ");*/
            public string name = "Demo";
            public int prodID = 110;
            public double price = 0.0;
            public enum itemCodes
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
            
            }

            //product id and associated price defined
            Dictionary<int,double> prods = new Dictionary<int,double> ();
       
        public Product(string prodName)
        {
            name = prodName;
            prodID = 999;
            price = 0.0;
        }
        public double BuyProduct(int next)
        {
            Console.WriteLine($"Product {next} Purchased. Thank You!");
            prods.Add(next, 3.0 );
            return prods[next];

        }
        public void AddProduct(int id)
        {
            //add product to the inventory
            /*if (item[next])
            {
                Console.WriteLine($"Product {next} costs {item.products[next]}");
            }
            else
            {
                Console.WriteLine("No Match Found!");
            }*/
        }
        
        public void DisplayProducts()
        {
            //show information about product
            Console.WriteLine($"Name: {name}, ID: {prodID}, Price: {price}");
        }
    }
}
