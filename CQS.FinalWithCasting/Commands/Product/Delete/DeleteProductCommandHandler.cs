using CQS.FinalWithCasting.Commands.Base;
using CQS.FinalWithCasting.RepositoryInterfaces;

namespace CQS.FinalWithCasting.Commands.Product.Delete
{
    public class DeleteProductCommandHandler : ICommandHandler
    {
        private readonly IProductRepository productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void Handle(object command)
        {
            DeleteProductCommand commandToExecute = (DeleteProductCommand)command;
            productRepository.Delete(commandToExecute.Id);
        }
    }
}
