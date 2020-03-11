using System.Collections.Generic;
using System;

namespace CornNuggets
{
    class Product
    {
            public string name = "Demo";
            public int prodID = 110;
            public double price = 0.0;


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
        public void AddProduct(int id,double cost)
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
