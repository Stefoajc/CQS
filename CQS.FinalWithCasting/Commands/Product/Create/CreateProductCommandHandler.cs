using CQS.FinalWithCasting.Commands.Base;
using CQS.FinalWithCasting.RepositoryInterfaces;
using System;

namespace CQS.FinalWithCasting.Commands.Product.Create
{
    public class CreateProductCommandHandler : ICommandHandler
    {
        private readonly IProductRepository productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void Handle(object command)
        {
            CreateProductCommand commandToExecute = (CreateProductCommand)command;
            var productToCreate = new DB.Models.Product
            {
                Id = commandToExecute.Id,
                BrandName = commandToExecute.BrandName,
                Name = commandToExecute.Name,
                Count = commandToExecute.Count,
                Price = commandToExecute.Price
            };

            productRepository.Create(productToCreate);
        }
    }
}
