using CQS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQS.SOLID.Product.Interfaces
{
    public interface IProductCreate
    {
        void Create(ProductCreateDTO productCreateDTO);
    }
}
