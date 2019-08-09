using System;
using System.Collections.Generic;
using System.Text;
using CQS.DB.Models;
using CQS.Models;
using Newtonsoft.Json;

namespace CQS.MonolithicImplementation.Common
{
    public class AuditedProductService : IProductServices
    {
        private readonly IProductServices productServices;

        public AuditedProductService(IProductServices productServices)
        {
            this.productServices = productServices;
        }

        public void Create(ProductCreateDTO productCreateDTO)
        {
            productServices.Create(productCreateDTO);

            var entry = new Activity
            {
                Id = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                Operation = "CreateProduct",
                Data = JsonConvert.SerializeObject(productCreateDTO)
            };

            //Persist the Activity
        }

        public void Delete(Guid id)
        {
            productServices.Delete(id);

            var entry = new Activity
            {
                Id = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                Operation = "CreateProduct",
                Data = JsonConvert.SerializeObject(id.ToString())
            };

            //Persist the Activity
        }

        public void Edit(ProductEditDTO productEditDTO)
        {
            productServices.Edit(productEditDTO);

            var entry = new Activity
            {
                Id = Guid.NewGuid(),
                CreatedOn = DateTime.Now,
                Operation = "CreateProduct",
                Data = JsonConvert.SerializeObject(productEditDTO)
            };

            //Persist the Activity
        }

        public ProductDetailsDTO Get(Guid id) => productServices.Get(id);
        public List<ProductListDTO> List() => productServices.List();
    }
}
