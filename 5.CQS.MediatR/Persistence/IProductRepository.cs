using CQS.DB.Models;
using System;
using System.Collections.Generic;


namespace CQS.MediatR.Persistence;

public interface IProductRepository
{
    Product Get(Guid id);
    IEnumerable<Product> List();
    Product Create(Product product);
    Product Edit(Product product);
    void Delete(Guid id);
    bool Exists(Guid id);
}
