using System;

namespace CQS.FinalWithCasting.Commands.Product.Create
{
    public class CreateProductCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}
