using CQS.FinalGeneric.Queries.Base;
using CQS.FinalGeneric.RepositoryInterfaces;
using System.Collections.Generic;
using System.Linq;

namespace CQS.FinalGeneric.Queries.Product.List
{
    public class ListProductQueryHandler : IQueryHandler<ListProductQuery, IEnumerable<ListProductResult>>
    {
        private readonly IProductRepository productRepository;

        public ListProductQueryHandler(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<ListProductResult> Handle(ListProductQuery query)
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
