using System;
using System.Collections.Generic;


namespace CQS.SOLID.RepositoryInterfaces
{
    public interface IProductRepository
    {
        DB.DbModels.Product Get(Guid Id);
        IEnumerable<DB.DbModels.Product> List();
        DB.DbModels.Product Create(DB.DbModels.Product product);
        DB.DbModels.Product Edit(DB.DbModels.Product product);
        void Delete(Guid Id);
        bool Exists(Guid id);
    }
}
