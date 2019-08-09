using CQS.FinalWithCasting.Commands.Base;
using CQS.FinalWithCasting.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

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
            DeleteProductCommand commandToExecute = command as DeleteProductCommand;
            productRepository.Delete(commandToExecute.Id);
        }
    }
}
