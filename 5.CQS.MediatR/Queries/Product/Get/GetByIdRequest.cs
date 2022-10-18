using CQS.MediatR.Persistence;
using MediatR;

namespace CQS.MediatR.Queries.Product.Get;

public record GetByIdResponse(Guid Id, string Name, decimal Price, int Count, string BrandName);

public record GetByIdRequest(Guid Id) : IRequest<GetByIdResponse>;

public class GetByIdRequestHandler : IRequestHandler<GetByIdRequest, GetByIdResponse>
{
    private readonly IProductRepository productRepository;

    public GetByIdRequestHandler(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public async Task<GetByIdResponse> Handle(GetByIdRequest request, CancellationToken cancellationToken)
    {
        var product = productRepository.Get(request.Id);

        return new GetByIdResponse
        (
            Id: product.Id,
            Name: product.Name,
            BrandName: product.BrandName,
            Price: product.Price,
            Count: product.Count
        );
    }
}
