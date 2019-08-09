using System;

namespace CQS.FinalGeneric.Queries.Product.List
{
    public class ListProductResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string BrandName { get; set; }
    }
}
