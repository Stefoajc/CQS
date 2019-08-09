using CQS.Models;
using CQS.SOLID.Product.Interfaces;
using CQS.SOLID.RepositoryInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace CQS.SOLID.Product
{
    public class ProductList : IProductList
    {
        private readonly IProductRepository productRepository;

        public ProductList(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
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
