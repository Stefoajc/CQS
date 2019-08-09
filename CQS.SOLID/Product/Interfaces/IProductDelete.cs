using System;

namespace CQS.SOLID.Product.Interfaces
{
    public interface IProductDelete
    {
        void Delete(Guid id);
    }
}
