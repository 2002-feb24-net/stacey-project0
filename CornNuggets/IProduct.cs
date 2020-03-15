namespace CornNuggets
{
    interface IProduct
    {
        string Name { get; set; }
        double Price { get; set; }
        int ProdID { get; set; }

        void AddProduct(string name, int id, double price);
        double BuyProduct(int next);
        void DisplayProducts();
        bool isProduct(int next);
    }
}