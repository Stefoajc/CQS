using System;
using System.Collections.Generic;
using CQS.DB.Models;


namespace CQS.FinalGeneric.RepositoryInterfaces
{
    public interface IProductRepository
    {
        Product Get(Guid id);
        IEnumerable<Product> List();
        Product Create(Product product);
        Product Edit(Product product);
        void Delete(Guid id);
        bool Exists(Guid id);
    }
}
