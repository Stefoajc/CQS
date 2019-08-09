using CQS.Models;

namespace CQS.SOLID.Product.Interfaces
{
    public interface IProductCreate
    {
        void Create(ProductCreateDTO productCreateDTO);
    }
}
