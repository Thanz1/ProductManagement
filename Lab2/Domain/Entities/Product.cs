using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductManagement.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [Required, StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [StringLength(500)]
        public string? Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Range(0.01, 1000000, ErrorMessage = "Price must be positive.")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative.")]
        public int Stock { get; set; }

        // Business rule validation
        public void ValidateBusinessRules()
        {
            if (Price <= 0) throw new InvalidOperationException("Price must be positive.");
            if (Stock < 0) throw new InvalidOperationException("Stock cannot be negative.");
        }
    }
}