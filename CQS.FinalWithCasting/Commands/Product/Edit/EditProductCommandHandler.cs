using CQS.FinalWithCasting.Commands.Base;
using CQS.FinalWithCasting.RepositoryInterfaces;
using System;

namespace CQS.FinalWithCasting.Commands.Product.Edit
{
    public class EditProductCommandHandler : ICommandHandler
    {
        private readonly IProductRepository productRepository;

        public EditProductCommandHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void Handle(object command)
        {
            EditProductCommand commandToExecute = (EditProductCommand)command;

            var productToEdit = productRepository.Get(commandToExecute.Id)
                ?? throw new ArgumentNullException(nameof(commandToExecute.Id));

            productToEdit.Name = commandToExecute.Name;
            productToEdit.Price = commandToExecute.Price;

            productRepository.Edit(productToEdit);
        }
    }
}
