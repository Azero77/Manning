using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportsStore.Models
{

    public class Product
    {
        public long? ProductID { get; set; }

        [Required(ErrorMessage =$"{nameof(Name)} is Required")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage =$"{nameof(Description)} is Required")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage =$"{nameof(Price)} is Required")]
        [Range(0.01 , double.MaxValue)]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal Price { get; set; }


        [Required(ErrorMessage = $"{nameof(Category)} is Required")]

        public string Category { get; set; } = string.Empty;

        
    }
}