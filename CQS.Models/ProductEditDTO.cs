using System;

namespace CQS.Models
{
    public class ProductEditDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
