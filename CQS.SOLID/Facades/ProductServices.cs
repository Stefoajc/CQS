using System;
using System.Collections.Generic;
using CQS.Models;
using CQS.SOLID.Product.Interfaces;

namespace CQS.SOLID.Facades
{
    public class ProductServices : IProductServices
    {
        private readonly IProductCreate productCreate;
        private readonly IProductEdit productEdit;
        private readonly IProductDelete productDelete;
        private readonly IProductGet productGet;
        private readonly IProductList productList;

        public ProductServices(IProductCreate productCreate,
            IProductEdit productEdit,
            IProductDelete productDelete,
            IProductGet productGet,
            IProductList productList)
        {
            this.productCreate = productCreate;
            this.productEdit = productEdit;
            this.productDelete = productDelete;
            this.productGet = productGet;
            this.productList = productList;
        }

        public void Create(ProductCreateDTO productCreateDTO)
        {
            productCreate.Create(productCreateDTO);
        }

        public void Delete(Guid id)
        {
            productDelete.Delete(id);
        }

        public void Edit(ProductEditDTO productEditDTO)
        {
            productEdit.Edit(productEditDTO);
        }

        public ProductDetailsDTO Get(Guid Id)
        {
            return productGet.Get(Id);
        }

        public List<ProductListDTO> List()
        {
            return productList.List();
        }
    }
}
