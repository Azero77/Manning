namespace SportsStore.Models.ViewModels
{
    public class ListViewProducts
    {
        public IEnumerable<Product>? Products { get; set; }

        public PageModel pageModel { get; set; }
        
        public string? Category { get; set; }
    }
}
