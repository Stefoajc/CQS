using CQS.FinalWithCasting.Queries.Base;
using CQS.FinalWithCasting.RepositoryInterfaces;

namespace CQS.FinalWithCasting.Queries.Product.Get
{
    public class GetProductQueryHandler : IQueryHandler
    {
        private readonly IProductRepository productRepository;

        public GetProductQueryHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public object Handle(object query)
        {
            GetProductQuery getProductQuery = (GetProductQuery)query;
            var product = productRepository.Get(getProductQuery.Id);

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
