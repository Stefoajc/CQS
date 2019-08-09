using System;
using System.Collections.Generic;
using System.Text;

namespace CQS.Models
{
    public class ProductEditDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
