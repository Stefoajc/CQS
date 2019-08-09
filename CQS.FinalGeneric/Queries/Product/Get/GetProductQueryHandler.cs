using CQS.FinalGeneric.Queries.Base;
using CQS.FinalGeneric.RepositoryInterfaces;

namespace CQS.FinalGeneric.Queries.Product.Get
{
    public class GetProductQueryHandler : IQueryHandler<GetProductQuery, GetProductResult>
    {
        private readonly IProductRepository productRepository;

        public GetProductQueryHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public GetProductResult Handle(GetProductQuery query)
        {
            var product = productRepository.Get(query.Id);

            return new GetProductResult
            {
                Id = product.Id,
                Name = product.Name,
                BrandName = product.BrandName,
                Price = product.Price,
                Count = product.Count
            };
        }
    }
}
