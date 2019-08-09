using CQS.Models;
using System;

namespace CQS.SOLID.Product.Interfaces
{
    public interface IProductGet
    {
        ProductDetailsDTO Get(Guid Id);
    }
}
