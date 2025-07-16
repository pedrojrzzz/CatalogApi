using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogAPI.Domain.Entities
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CategoryId { get; private set; }
        [Required]
        [StringLength(300, ErrorMessage = "Only 300 characters are allowed")]
        public string? imageUrl { get; private set; }
        [Required]
        [StringLength(80, ErrorMessage = "Only 80 characters are allowed")]
        public string? name { get; private set; }
        public ICollection<Product>? Products { get; private set; } // Collection of products that belong to a certain category

        public Category() // Construtor
        {
            Products = new Collection<Product>(); // Instantiating an empty collection
        }
    }
}
