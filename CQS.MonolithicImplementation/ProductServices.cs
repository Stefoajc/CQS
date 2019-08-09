using System;
using System.Collections.Generic;
using System.Linq;
using CQS.Models;
using CQS.MonolithicImplementation.RepositoryInterfaces;

namespace CQS.MonolithicImplementation
{
    public class ProductServices : IProductServices
    {
        private IProductRepository productRepository;

        public ProductServices(IProductRepository productRepository)
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

        public void Delete(Guid id)
        {
            productRepository.Delete(id);
        }

        public void Edit(ProductEditDTO productEditDTO)
        {
            productRepository.Edit(new DB.DbModels.Product());
        }

        public ProductDetailsDTO Get(Guid Id)
        {
            var product = productRepository.Get(Id);

            return new ProductDetailsDTO();
        }

        public List<ProductListDTO> List()
        {
            return productRepository.List()
                .Select(p => new ProductListDTO())
                .ToList();
        }
    }
}
