namespace SportsStore.Models.ViewModels
{
    public class PageModel
    {
        public int TotalItems { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages { get=> (int)Math.Ceiling((decimal)TotalItems / PageSize); set { TotalPages = value; }}
    }
}
