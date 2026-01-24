using ProductManagement.Application.DTOs;
using ProductManagement.Application.Interfaces;
using ProductManagement.Application.Interfaces.Services;
using ProductManagement.Domain.Entities;

namespace ProductManagement.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllProductsAsync()
        {
            var products = await _productRepository.GetAllAsync();
            return products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Price = p.Price,
                Stock = p.Stock
            });
        }

        public async Task<ProductDTO?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return null;

            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock
            };
        }

        public async Task<ProductDTO> CreateProductAsync(CreateProductDTO createProductDTO)
        {
            var product = new Product
            {
                Name = createProductDTO.Name,
                Description = createProductDTO.Description,
                Price = createProductDTO.Price,
                Stock = createProductDTO.Stock
            };

            product.ValidateBusinessRules();
            var createdProduct = await _productRepository.AddAsync(product);

            return new ProductDTO
            {
                Id = createdProduct.Id,
                Name = createdProduct.Name,
                Description = createdProduct.Description,
                Price = createdProduct.Price,
                Stock = createdProduct.Stock
            };
        }

        public async Task<ProductDTO?> UpdateProductAsync(int id, UpdateProductDTO updateProductDTO)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return null;

            product.Name = updateProductDTO.Name;
            product.Description = updateProductDTO.Description;
            product.Price = updateProductDTO.Price;
            product.Stock = updateProductDTO.Stock;

            product.ValidateBusinessRules();
            await _productRepository.UpdateAsync(product);

            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Stock = product.Stock
            };
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return false;

            await _productRepository.DeleteAsync(id);
            return true;
        }
    }
}
