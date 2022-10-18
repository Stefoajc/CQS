using CQS.MediatR.Commands.Aspects;
using CQS.MediatR.Persistence;
using MediatR;

namespace CQS.MediatR.Commands.Product;

public record CreateProductCommand(
    Guid Id,
    string Name,
    string BrandName,
    decimal Price,
    int Count
) : IAuditableEntity;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
{
    private readonly IProductRepository productRepository;

    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public Task<Unit> Handle(CreateProductCommand command, CancellationToken cancellationToken)
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

        return Unit.Task;
    }
}
