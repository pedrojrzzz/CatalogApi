using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CatalogAPI.Domain.Entities
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [StringLength(80, ErrorMessage = "Only 80 characters are allowed")]
        public string? Name { get; set; }
        [Required]
        [StringLength(300, ErrorMessage = "Only 300 characters are allowed")]
        public string? Description { get; set; }
        [Required]
        [Column(TypeName = "decimal(10,2)")] // Defining that this column will now have the decimal type (10,2)
        public decimal Price { get; set; }
        [Required]
        [StringLength(300, ErrorMessage = "Only 300 characters are allowed")]
        public string? ImageUrl { get; set; }
        public float Stock { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int CategoryId { get; set; } // Stores the category ID (foreign key)

        [JsonIgnore]
        public Category? Category { get; set; }  // Navigation to the Category entity (object) - to access the category props
    }
}
