using CQS.FinalGeneric.Commands.Base;
using CQS.FinalGeneric.RepositoryInterfaces;

namespace CQS.FinalGeneric.Commands.Product.Delete
{
    public class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand>
    {
        private readonly IProductRepository productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void Handle(DeleteProductCommand command)
        {
            productRepository.Delete(command.Id);
        }
    }
}
