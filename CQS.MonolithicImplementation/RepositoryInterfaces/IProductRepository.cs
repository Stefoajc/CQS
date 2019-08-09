using CQS.DB.DbModels;
using CQS.Models;
using System;
using System.Collections.Generic;

namespace CQS.MonolithicImplementation.RepositoryInterfaces
{
    public interface IProductRepository
    {
        Product Get(Guid Id);
        IEnumerable<Product> List();
        Product Create(Product product);
        Product Edit(Product product);
        void Delete(Guid Id);
        bool Exists(Guid id);
    }
}
