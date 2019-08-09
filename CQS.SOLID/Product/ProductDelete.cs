using CQS.SOLID.Product.Interfaces;
using CQS.SOLID.RepositoryInterfaces;
using System;

namespace CQS.SOLID.Product
{
    public class ProductDelete : IProductDelete
    {
        private readonly IProductRepository productRepository;

        public ProductDelete(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }


        public void Delete(Guid id)
        {
            productRepository.Delete(id);
        }
    }
}
