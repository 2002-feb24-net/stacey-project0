namespace CornNuggets
{
    interface IProduct
    {
        /*Stacey Joseph, Revature, Project 0
         * Store Implementation
         * C:\Revature\stacey-project0\CornNuggets\IProduct.cs
        */
        string Name { get; set; }
        double Price { get; set; }
        int ProdID { get; set; }

        void AddProduct(string name, int id, double price);
        double BuyProduct(int next);
        void DisplayProducts();
        bool isProduct(int next);
    }
}