using Infrastructure.DTOs;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using System.Diagnostics;

namespace Infrastructure.Services
{
    public class ProductService(CategoryService categoryService, ProductRepository productRepository)
    {
        private readonly ProductRepository _productRepository = productRepository;
        private readonly CategoryService _categoryService = categoryService;

        public ProductEntity CreateProduct(ProductDTO product)
        {
            try
            {
                var categoryEntity = _categoryService.CreateCategory(product.CategoryName);
                if (categoryEntity != null)
                {
                    var productEntity = new ProductEntity
                    {
                        Title = product.Title,
                        Description = product.Description,
                        Price = product.Price,
                        CategoryId = categoryEntity!.Id,
                    };

                    productEntity = _productRepository.Create(productEntity);
                    return productEntity;
                }
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
            }
            return null!;
        }

        public ProductEntity GetProductById(int id)
        {
            var productEntity = _productRepository.GetSingle(x => x.Id == id);
            return productEntity;
        }

        public IEnumerable<ProductEntity> GetProducts()
        {
            var products = _productRepository.GetAll();
            return products;
        }

        public ProductEntity UpdateProduct(ProductEntity productEntity)
        {
            var updatedProductEntity = _productRepository.Update(x => x.Id == productEntity.Id, productEntity);
            return updatedProductEntity;
        }

        public bool DeleteProduct(int id)
        {
            _productRepository.Delete(x => x.Id == id);
            return true;
        }
    }

    
}
