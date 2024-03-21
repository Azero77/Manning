using System.ComponentModel.DataAnnotations;

namespace PartInvite.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage =$"{nameof(Name)} Field is Required")]
        public string?  Name { get; set; }

        [Required(ErrorMessage = $"{nameof(Email)} Field is Required")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = $"{nameof(Phone)} Field is Required")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = $"You should specify if you are coming or not")]
        public bool? WillAttend { get; set; }

        public override string ToString()
        {
            return $"{Name} : {Phone} :  {WillAttend}";
        }
    }
}
