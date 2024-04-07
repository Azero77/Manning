namespace SportsStore.Models
{
    public class EFStoreRepository : IStoreRepository
    {
        private StoreDbContext _context;

        public EFStoreRepository(StoreDbContext context)
        {
            _context = context;

        }

        public IQueryable<Product> Products { get => _context.Products; }

        public void AddProduct(Product p)
        {
            _context.Add(p);
            _context.SaveChanges();
        }
        public void RemoveProduct(Product p) 
        {
            _context.Remove(p);
            _context.SaveChanges();
        }

        public void SaveProduct(Product p) 
        {
            _context.SaveChanges();
        }
    }
}
