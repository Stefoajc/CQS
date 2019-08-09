using CQS.DB.Models;
using CQS.Models;
using CQS.SOLID.Product.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CQS.SOLID.Common
{
    public class AuditedProductCreate : IProductCreate
    {
        private readonly IProductCreate productCreate;

        public AuditedProductCreate(IProductCreate productCreate)
        {
            this.productCreate = productCreate;
        }

        public void Create(ProductCreateDTO productCreateDTO)
        {
            productCreate.Create(productCreateDTO);

            var entry = new Activity
            {
                Id = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                Operation = "CreateProduct",
                Data = JsonConvert.SerializeObject(productCreateDTO)
            };

            //Persist the Activity
        }
    }
}
