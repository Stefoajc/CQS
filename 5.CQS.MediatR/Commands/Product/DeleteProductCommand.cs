using CQS.MediatR.Persistence;
using MediatR;

namespace CQS.MediatR.Commands.Product;

public record DeleteProductCommand(
    Guid Id
) : IRequest;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IProductRepository productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public Task<Unit> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
    {
        productRepository.Delete(command.Id);

        return Unit.Task;
    }
}
