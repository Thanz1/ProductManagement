using System.ComponentModel.DataAnnotations;

namespace ProductManagement.Application.DTOs
{
    public class UpdateProductDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [StringLength(500)]
        public string? Description { get; set; }

        [Range(0.01, 1000000, ErrorMessage = "Price must be between 0.01 and 1000000.")]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Stock cannot be negative.")]
        public int Stock { get; set; }
    }
}
