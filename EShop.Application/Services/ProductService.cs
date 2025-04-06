using EShop.Domain.Models;
using EShop.Domain.Repositories;
using System.Collections.Generic;

namespace EShop.Application.Services
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {
        private readonly IProductRepository _productRepository = productRepository;

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public Product? GetProductById(int id)
        {
            return _productRepository.GetById(id);
        }

        public void AddProduct(Product product)
        {
            _productRepository.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            _productRepository.Update(product);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.Delete(id);
        }
    }
}
