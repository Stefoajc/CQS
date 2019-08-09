using CQS.FinalGeneric.Commands.Base;
using CQS.FinalGeneric.Commands.Product.Create;
using CQS.FinalGeneric.Commands.Product.Delete;
using CQS.FinalGeneric.Commands.Product.Edit;
using CQS.FinalGeneric.Queries.Base;
using CQS.FinalGeneric.Queries.Product.Get;
using CQS.FinalGeneric.Queries.Product.List;
using CQS.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CQS.FinalGeneric.Facades
{
    public class ProductServices : IProductServices
    {
        private readonly ICommandHandler<CreateProductCommand> productCreate;
        private readonly ICommandHandler<EditProductCommand> productEdit;
        private readonly ICommandHandler<DeleteProductCommand> productDelete;
        private readonly IQueryHandler<GetProductQuery, GetProductResult> productGet;
        private readonly IQueryHandler<ListProductQuery, IEnumerable<ListProductResult>> productList;

        public ProductServices(ICommandHandler<CreateProductCommand> productCreate,
            ICommandHandler<EditProductCommand> productEdit,
            ICommandHandler<DeleteProductCommand> productDelete,
            IQueryHandler<GetProductQuery, GetProductResult> productGet,
            IQueryHandler<ListProductQuery, IEnumerable<ListProductResult>> productList)
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
            var result = productGet.Handle(new GetProductQuery { Id = Id });

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
            var result = productList.Handle(new ListProductQuery());

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
