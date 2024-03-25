namespace SimpleApp.Models
{
    public class Product
    {
        public string Name { get; set; } = string.Empty;
        public decimal? Price { get; set; }

        /*public static Product[] GetProducts() 
        {
            return new Product[]
            {
                new(){Name = "Kayak" , Price = 275M },
                new(){Name = "LifeJacket" , Price = 48.95M }
            };
        }*/
    }

    public class ProductDataSource : IDataSource
    {
        public IEnumerable<Product> Products { get => new Product[] {
            new(){Name = "Kayak" , Price = 275M },
            new(){Name = "LifeJacket" , Price = 48.95M }
        }; }
    }
}
