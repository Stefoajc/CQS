using CQS.Models;
using CQS.SOLID.Product.Interfaces;
using CQS.SOLID.RepositoryInterfaces;
using System;

namespace CQS.SOLID.Product
{
    public class ProductCreate : IProductCreate
    {
        private readonly IProductRepository productRepository;

        public ProductCreate(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void Create(ProductCreateDTO productCreateDTO)
        {
            var productId = Guid.NewGuid();
            var productToCreate = new DB.DbModels.Product
            {
                Id = productId,
                BrandName = productCreateDTO.BrandName,
                Name = productCreateDTO.Name,
                Count = productCreateDTO.Count,
                Price = productCreateDTO.Price
            };

            productRepository.Create(productToCreate);
        }
    }
}
