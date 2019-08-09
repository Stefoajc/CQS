using System;

namespace CQS.FinalWithCasting.Queries.Product.Get
{
    public class GetProductResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string BrandName { get; set; }
    }
}
