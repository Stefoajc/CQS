using CQS.FinalWithCasting.Commands.Base;
using CQS.FinalWithCasting.Commands.Product.Create;
using CQS.FinalWithCasting.Commands.Product.Delete;
using CQS.FinalWithCasting.Commands.Product.Edit;
using CQS.FinalWithCasting.Queries.Base;
using CQS.FinalWithCasting.Queries.Product.Get;
using CQS.FinalWithCasting.Queries.Product.List;
using CQS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CQS.FinalWithCasting.Facades
{
    public class ProductServices : IProductServices
    {
        private readonly ICommandHandler productCreate;
        private readonly ICommandHandler productEdit;
        private readonly ICommandHandler productDelete;
        private readonly IQueryHandler productGet;
        private readonly IQueryHandler productList;

        public ProductServices(ICommandHandler productCreate,
            ICommandHandler productEdit,
            ICommandHandler productDelete,
            IQueryHandler productGet,
            IQueryHandler productList)
        {
            this.productCreate = productCreate;
            this.productEdit = productEdit;
            this.productDelete = productDelete;
            this.productGet = productGet;
            this.productList = productList;
        }

        public void Create(ProductCreateDTO productCreateDTO)
        {
            CreateProductCommand command = new CreateProductCommand
            {
                Name = productCreateDTO.Name,
                BrandName = productCreateDTO.BrandName,
                Count = productCreateDTO.Count,
                Price = productCreateDTO.Price
            };

            productCreate.Handle(command);
        }

        public void Delete(Guid id)
        {
            productDelete.Handle(new DeleteProductCommand { Id = id });
        }

        public void Edit(ProductEditDTO productEditDTO)
        {
            EditProductCommand command = new EditProductCommand
            {
                Id = productEditDTO.Id,
                Name = productEditDTO.Name,
                Price = productEditDTO.Price
            };
            productEdit.Handle(command);
        }


        public ProductDetailsDTO Get(Guid Id)
        {
            var result = (GetProductResult)productGet.Handle(Id);

            return new ProductDetailsDTO
            {
                Id = result.Id,
                Name = result.Name,
                BrandName = result.BrandName,
                Price = result.Price,
                Count = result.Count
            };
        }

        public List<ProductListDTO> List()
        {
            var result = (List<ListProductResult>)productList.Handle(new ListProductQuery());

            return result
                .Select(p => new ProductListDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    BrandName = p.BrandName,
                    Price = p.Price,
                    Count = p.Count
                })
                .ToList();
        }
    }
}
