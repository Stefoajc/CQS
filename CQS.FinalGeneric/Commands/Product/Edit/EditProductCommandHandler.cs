using CQS.FinalGeneric.Commands.Base;
using CQS.FinalGeneric.RepositoryInterfaces;
using System;

namespace CQS.FinalGeneric.Commands.Product.Edit
{
    public class EditProductCommandHandler : ICommandHandler<EditProductCommand>
    {
        private readonly IProductRepository productRepository;

        public EditProductCommandHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void Handle(EditProductCommand command)
        {
            var productToEdit = productRepository.Get(command.Id)
                ?? throw new ArgumentNullException(nameof(command.Id));

            productToEdit.Name = command.Name;
            productToEdit.Price = command.Price;

            productRepository.Edit(productToEdit);
        }
    }
}
