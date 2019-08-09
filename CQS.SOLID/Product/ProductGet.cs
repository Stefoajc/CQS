using CQS.Models;
using CQS.SOLID.Product.Interfaces;
using CQS.SOLID.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQS.SOLID.Product
{
    public class ProductGet : IProductGet
    {
        private readonly IProductRepository productRepository;

        public ProductGet(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public ProductDetailsDTO Get(Guid Id)
        {
            var product = productRepository.Get(Id);

            return new ProductDetailsDTO
            {
                Id = product.Id,
                Name = product.Name,
                BrandName = product.BrandName,
                Price = product.Price,
                Count = product.Count
            };
        }
    }
}
