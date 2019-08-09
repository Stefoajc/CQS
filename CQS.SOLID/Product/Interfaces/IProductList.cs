using CQS.Models;
using System.Collections.Generic;

namespace CQS.SOLID.Product.Interfaces
{
    public interface IProductList
    {
        List<ProductListDTO> List();
    }
}
