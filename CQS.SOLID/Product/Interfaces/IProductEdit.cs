using CQS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQS.SOLID.Product.Interfaces
{
    public interface IProductEdit
    {
        void Edit(ProductEditDTO productEditDTO);
    }
}
