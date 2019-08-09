using System;
using System.Collections.Generic;
using System.Text;

namespace CQS.SOLID.Product.Interfaces
{
    public interface IProductDelete
    {
        void Delete(Guid id);
    }
}
