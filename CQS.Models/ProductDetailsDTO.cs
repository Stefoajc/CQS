using System;
using System.Collections.Generic;
using System.Text;

namespace CQS.Models
{
    public class ProductDetailsDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
        public string BrandName { get; set; }
    }
}
