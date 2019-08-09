using System;

namespace CQS.Models
{
    public class ProductCreateDTO
    {
        private Guid Id { get; set; }
        public string Name { get; set; }
        public string BrandName { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}
