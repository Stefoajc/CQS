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
            var productToEdit = productRepository.Get(productEditDTO.Id)
                ?? throw new ArgumentNullException(nameof(productEditDTO.Id));

            productToEdit.Name = productEditDTO.Name;
            productToEdit.Price = productEditDTO.Price;

            productRepository.Edit(productToEdit);
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

        public List<ProductListDTO> List()
        {
            return productRepository.List()
                .Select(p => new ProductListDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    BrandName = p.BrandName,
                    Price = p.Price,
                    Count = p.Count
                })
                .ToList();
        }
    }
}
