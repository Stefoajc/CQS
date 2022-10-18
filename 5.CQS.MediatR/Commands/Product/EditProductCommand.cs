using CQS.MediatR.Persistence;
using MediatR;

namespace CQS.MediatR.Commands.Product;

public record EditProductCommand(
    Guid Id,
    string Name,
    decimal Price
) : IRequest;

public class EditProductCommandHandler : IRequestHandler<EditProductCommand>
{
    private readonly IProductRepository productRepository;

    public EditProductCommandHandler(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public Task<Unit> Handle(EditProductCommand command, CancellationToken cancellationToken)
    {
        var productToCreate = new DB.Models.Product
        {
            Id = command.Id,
            Name = command.Name,
            Price = command.Price
        };

        productRepository.Edit(productToCreate);

        return Unit.Task;
    }
}
