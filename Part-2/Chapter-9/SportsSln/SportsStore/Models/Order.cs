using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace SportsStore.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }

        [BindNever]
        public ICollection<CartLine> cartLines { get; set; } =
            new List<CartLine>();

        [Required(ErrorMessage="Name Field is Required")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Line1 Field is Required")]
        public string? Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? Line3 { get; set; }
        [Required(ErrorMessage = "City Field is Required")]
        public string? City { get; set; }

        [Required(ErrorMessage = "State Field is Required")]
        public string? State { get; set; }
        public string? Zip { get; set; }
        [Required(ErrorMessage="Name Country is Required")]
        public string? Country { get; set; }
        public bool GiftWrap { get; set; }
    }
}
