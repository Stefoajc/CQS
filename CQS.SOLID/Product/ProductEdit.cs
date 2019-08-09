using CQS.Models;
using CQS.SOLID.Product.Interfaces;
using CQS.SOLID.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQS.SOLID.Product
{
    public class ProductEdit : IProductEdit
    {
        private readonly IProductRepository productRepository;

        public ProductEdit(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void Edit(ProductEditDTO productEditDTO)
        {
            var productToEdit = productRepository.Get(productEditDTO.Id)
                ?? throw new ArgumentNullException(nameof(productEditDTO.Id));

            productToEdit.Name = productEditDTO.Name;
            productToEdit.Price = productEditDTO.Price;

            productRepository.Edit(productToEdit);
        }
    }
}
