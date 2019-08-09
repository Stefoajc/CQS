using System;
using System.Collections.Generic;


namespace CQS.SOLID.RepositoryInterfaces
{
    public interface IProductRepository
    {
        DB.Models.Product Get(Guid id);
        IEnumerable<DB.Models.Product> List();
        DB.Models.Product Create(DB.Models.Product product);
        DB.Models.Product Edit(DB.Models.Product product);
        void Delete(Guid id);
        bool Exists(Guid id);
    }
}
