using CQS.FinalWithCasting.Queries.Base;
using CQS.FinalWithCasting.RepositoryInterfaces;
using System.Linq;

namespace CQS.FinalWithCasting.Queries.Product.List
{
    public class ListProductQueryHandler : IQueryHandler
    {
        private readonly IProductRepository productRepository;

        public ListProductQueryHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public object Handle(object query)
        {
            return productRepository.List()
                .Select(p => new ListProductResult
                {
                    Id = p.Id,
                    Name = p.Name,
                    BrandName = p.BrandName,
                    Price = p.Price,
                    Count = p.Count
                })
                .ToList();
        }
    }
}
