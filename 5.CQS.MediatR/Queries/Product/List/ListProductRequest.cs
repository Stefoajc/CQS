using CQS.MediatR.Persistence;
using MediatR;

namespace CQS.MediatR.Queries.Product.List;

public record ListProductResponseItem(Guid Id, string Name, decimal Price, int Count, string BrandName);

public record ListProductRequest(Guid Id) : IRequest<IEnumerable<ListProductResponseItem>>;

public class ListProductRequestHandler : IRequestHandler<ListProductRequest, IEnumerable<ListProductResponseItem>>
{
    private readonly IProductRepository productRepository;

    public ListProductRequestHandler(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public async Task<IEnumerable<ListProductResponseItem>> Handle(ListProductRequest request, CancellationToken cancellationToken)
    {
        var products = productRepository.List();

        return products.Select(product => new ListProductResponseItem
        (
            Id: product.Id,
            Name: product.Name,
            BrandName: product.BrandName,
            Price: product.Price,
            Count: product.Count
        ));
    }
}
