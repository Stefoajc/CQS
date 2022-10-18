using CQS.FinalGeneric.Commands.Base;
using CQS.FinalGeneric.RepositoryInterfaces;

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
            var productToCreate = new DB.Models.Product
            {
                Id = command.Id,
                BrandName = command.BrandName,
                Name = command.Name,
                Count = command.Count,
                Price = command.Price
            };

            productRepository.Create(productToCreate);
        }
    }
}
