using System.ComponentModel.DataAnnotations;

namespace CarModels
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public string Brand { get; set; }
        public string Color { get; set; }
        public string Condition { get; set; }
        public string OwnerLastName { get; set; }
        public string Address { get; set; }
    }
}
