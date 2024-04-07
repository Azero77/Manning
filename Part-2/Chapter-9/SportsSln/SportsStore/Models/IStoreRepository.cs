namespace SportsStore.Models
{
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get;}
        void AddProduct(Product p);
        void RemoveProduct(Product p);
        void SaveProduct(Product p);
    }
}
