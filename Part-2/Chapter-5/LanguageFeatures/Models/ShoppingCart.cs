using System.Collections;

namespace LanguageFeatures.Models
{
    public class ShoppingCart : IEnumerable<Product?> , IProductSelection
    {
        private List<Product?> products { get; set; } = new();

        public IEnumerable<Product?> Products => products;

        public ShoppingCart(params Product?[] pds)
        {
            products.AddRange(pds);
        }

        public IEnumerator<Product?> GetEnumerator()
        {

            return products?.GetEnumerator() ?? Enumerable.Empty<Product?>().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();


        
    }
}
