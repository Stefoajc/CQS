using CQS.DB.Models;
using CQS.SOLID.Product.Interfaces;
using Newtonsoft.Json;
using System;

namespace CQS.SOLID.Common
{
    public class AuditedProductDelete : IProductDelete
    {
        private readonly IProductDelete productDelete;

        public AuditedProductDelete(IProductDelete productDelete)
        {
            this.productDelete = productDelete;
        }

        public void Delete(Guid id)
        {
            productDelete.Delete(id);

            var entry = new Activity
            {
                Id = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                Operation = "CreateProduct",
                Data = JsonConvert.SerializeObject(id.ToString())
            };

            //Persist the Activity
        }
    }
}
