using CQS.DB.Models;
using CQS.Models;
using CQS.SOLID.Product.Interfaces;
using Newtonsoft.Json;
using System;

namespace CQS.SOLID.Common
{
    public class AuditedProductEdit : IProductEdit
    {
        private readonly IProductEdit productEdit;

        public AuditedProductEdit(IProductEdit productEdit)
        {
            this.productEdit = productEdit;
        }
        public void Edit(ProductEditDTO productEditDTO)
        {
            productEdit.Edit(productEditDTO);

            var entry = new Activity
            {
                Id = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                Operation = "CreateProduct",
                Data = JsonConvert.SerializeObject(productEditDTO)
            };

            //Persist the Activity
        }
    }
}
