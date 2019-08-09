using CQS.FinalGeneric.Commands.Base;
using CQS.FinalGeneric.RepositoryInterfaces;
using System;

namespace CQS.FinalGeneric.Commands.Product.Create
{
    public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand>
    {
        private readonly IProductRepository productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void Handle(CreateProductCommand command)
        {
            var productId = Guid.NewGuid();
            var productToCreate = new DB.DbModels.Product
            {
                Id = productId,
                BrandName = command.BrandName,
                Name = command.Name,
                Count = command.Count,
                Price = command.Price
            };

            productRepository.Create(productToCreate);
        }
    }
}
