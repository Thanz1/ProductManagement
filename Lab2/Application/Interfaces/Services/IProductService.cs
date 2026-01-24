using ProductManagement.Application.DTOs;

namespace ProductManagement.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO?> GetProductByIdAsync(int id);
        Task<ProductDTO> CreateProductAsync(CreateProductDTO createProductDTO);
        Task<ProductDTO?> UpdateProductAsync(int id, UpdateProductDTO updateProductDTO);
        Task<bool> DeleteProductAsync(int id);
    }
}
