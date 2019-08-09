using System;

namespace CQS.Models
{
    public class ProductListDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string BrandName { get; set; }
    }
}
