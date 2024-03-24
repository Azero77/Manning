namespace LanguageFeatures.Models
{
    public class Product
    {
        public required string Name { get; set; }
        public decimal? Price { get; set; }

        public static Product?[] GetProducts()
        {
            return new Product?[] 
            {
                new(){Name = "Kayak" , Price = 275m },
                new(){
                    Name = "Lifejacket" ,
                    Price = 48.95m },
                null
            };
        }
    }
}
