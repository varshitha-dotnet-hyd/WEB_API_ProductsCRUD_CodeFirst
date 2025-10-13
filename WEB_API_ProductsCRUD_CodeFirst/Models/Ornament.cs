using System.ComponentModel.DataAnnotations;

namespace WEB_API_ProductsCRUD_CodeFirst.Models
{
    public class Ornament
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Ornament Name is Mandatory")]
        [StringLength(30,MinimumLength=3,ErrorMessage ="Ornament Name should be between 3 and 30 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Metal Name is Mandatory")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Metal Name should be between 3 and 15 characters")]
        public string Metal { get; set; }

        [Required(ErrorMessage = "Enter weight in gms")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Enter price per gram")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Making charges are mandatory to enter")]
        public double MakingCharges { get; set; }

        public double Amount { get; set; }
    }
}
