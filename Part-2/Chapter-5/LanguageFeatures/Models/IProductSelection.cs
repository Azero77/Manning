namespace LanguageFeatures.Models
{
    public interface IProductSelection
    {
        IEnumerable<Product?> Products { get; }

        public IEnumerable<string> Names => Products.Select(p => p?.Name ?? "");

        public int GetLengthNames(IEnumerable<Product?> prods)
        {
            return 5;
        }
    }
}
