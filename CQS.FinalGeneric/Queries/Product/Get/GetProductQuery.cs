using CQS.FinalGeneric.Queries.Base;
using System;

namespace CQS.FinalGeneric.Queries.Product.Get
{
    public class GetProductQuery : IQuery<GetProductResult>
    {
        public Guid Id { get; set; }
    }
}
