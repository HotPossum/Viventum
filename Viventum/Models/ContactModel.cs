using System.ComponentModel.DataAnnotations;

namespace Viventum.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[A-Za-z0-9 ]+$", ErrorMessage = "Charactres and numbers allowed only")]
        [MinLength(3, ErrorMessage = "min is 3")]
        [MaxLength(30, ErrorMessage ="max is 30")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [RegularExpression(@"^[A-Za-z0-9 ]+$", ErrorMessage = "Charactres and numbers allowed only")]
        [MinLength(2, ErrorMessage = "min is 2")]
        [MaxLength(50, ErrorMessage = "max is 50")]
        public string Company { get; set; }

        [RegularExpression(@"^[A-Za-z0-9 ]+$", ErrorMessage = "Charactres and numbers allowed only")]
        [MinLength(3, ErrorMessage = "min is 3")]
        [MaxLength(50, ErrorMessage = "max is 50")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Message is required")]
        [RegularExpression(@"[a-zA-Z]*[^!@%~?%^&*()]*")]
        [MinLength(10, ErrorMessage = "min is 10")]
        [MaxLength(1000, ErrorMessage = "max is 1000")]
        public string Message { get; set; }

    }
}
