using System.ComponentModel.DataAnnotations;

namespace ASPNetExapp.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Car number is required.")]
        [RegularExpression(@"^[A-Z]{2}\d{4}[A-Z]{2}$", ErrorMessage = "Car number format must be two letters, followed by four digits, and two letters.")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        [Range(1900, 2100, ErrorMessage = "Year must be between 1900 and 2100.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Brand is required.")]
        [StringLength(50, ErrorMessage = "Brand name cannot be longer than 50 characters.")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Color is required.")]
        [StringLength(30, ErrorMessage = "Color name cannot be longer than 30 characters.")]
        public string Color { get; set; }

        [Required(ErrorMessage = "Condition is required.")]
        [StringLength(20, ErrorMessage = "Condition name cannot be longer than 20 characters.")]
        public string Condition { get; set; }

        [Required(ErrorMessage = "Owner's last name is required.")]
        [StringLength(100, ErrorMessage = "Owner's last name cannot be longer than 100 characters.")]
        public string OwnerLastName { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [StringLength(200, ErrorMessage = "Address cannot be longer than 200 characters.")]
        public string Address { get; set; }
    }
}
