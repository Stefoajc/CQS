using System;

namespace CQS.FinalWithCasting.Commands.Product.Edit
{
    public class EditProductCommand
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
