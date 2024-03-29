﻿using CQS.FinalGeneric.Commands.Base;
using CQS.FinalGeneric.Commands.Product.Create;
using CQS.FinalGeneric.Commands.Product.Delete;
using CQS.FinalGeneric.Commands.Product.Edit;
using CQS.FinalGeneric.Mediator;
using CQS.FinalGeneric.Queries.Base;
using CQS.FinalGeneric.Queries.Product.List;
using CQS.FinalGeneric.RepositoryInterfaces;
using CQS.Repositories;
using SimpleInjector;
using System;
using System.Collections.Generic;
using CQS.FinalGeneric.Common.CommandAspects;
using CQS.FinalGeneric.Queries.Product.Get;

namespace CQS.UI
{
    class Program
    {
        static void Main()
        {
            //------------------------  MONOLITHIC SERVICE  ------------------------
            var monilithicProductService = new MonolithicImplementation.Common.AuditedProductService(
                new MonolithicImplementation.ProductServices(
                    new ProductRepository()));

            //------------------------  SOLID (SRP and ISP applied) SERVICE  ------------------------
            var solidRepo = new ProductRepository();
            var solidProductService = new SOLID.Facades.ProductServices(
                new SOLID.Common.AuditedProductCreate(new SOLID.Product.ProductCreate(solidRepo)),
                new SOLID.Common.AuditedProductEdit(new SOLID.Product.ProductEdit(solidRepo)),
                new SOLID.Common.AuditedProductDelete(new SOLID.Product.ProductDelete(solidRepo)),
                new SOLID.Product.ProductGet(solidRepo),
                new SOLID.Product.ProductList(solidRepo));


            //------------------------  CQS Basic (OCP applied) SERVICE  ------------------------
            var commandQueryRepo = new ProductRepository();
            var cqsProductService = new FinalWithCasting.Facades.ProductServices(
                new FinalWithCasting.Common.CommandAspects.AuditedCommandHandler(new FinalWithCasting.Commands.Product.Create.CreateProductCommandHandler(commandQueryRepo)),
                new FinalWithCasting.Common.CommandAspects.AuditedCommandHandler(new FinalWithCasting.Commands.Product.Edit.EditProductCommandHandler(commandQueryRepo)),
                new FinalWithCasting.Common.CommandAspects.AuditedCommandHandler(new FinalWithCasting.Commands.Product.Delete.DeleteProductCommandHandler(commandQueryRepo)),
                new FinalWithCasting.Queries.Product.Get.GetProductQueryHandler(commandQueryRepo),
                new FinalWithCasting.Queries.Product.List.ListProductQueryHandler(commandQueryRepo)
                );


            //------------------------  CQS Generic (OCP applied) SERVICE  ------------------------
            var commandQueryGenericRepo = new ProductRepository();
            var cqsGenericProductService = new FinalGeneric.Facades.ProductServices(
                // Apply audit CCC
                new AuditedCommandHandler<CreateProductCommand>(new CreateProductCommandHandler(commandQueryGenericRepo)),
                new AuditedCommandHandler<EditProductCommand>(new EditProductCommandHandler(commandQueryGenericRepo)),
                new AuditedCommandHandler<DeleteProductCommand>(new DeleteProductCommandHandler(commandQueryGenericRepo)),

                // Plain query handlers
                new GetProductQueryHandler(commandQueryGenericRepo),
                new ListProductQueryHandler(commandQueryGenericRepo));



            //------------------------  CQS Generic SERVICE With IoC  ------------------------
            Container container = new Container();
            container.Register<IProductRepository, ProductRepository>(Lifestyle.Singleton);
            container.Register(
                typeof(IQueryHandler<,>),
                typeof(IQueryHandler<,>).Assembly);
            container.Register(
                typeof(ICommandHandler<>),
                typeof(ICommandHandler<>).Assembly);
            container.RegisterDecorator(
                typeof(ICommandHandler<>),
                typeof(AuditedCommandHandler<>));

            var queryMediator = new QueryMediator(container);
            var commandMediator = new CommandMediator(container);

            commandMediator.Process(new CreateProductCommand { Name = "Gel Runner", BrandName = "Asics", Price = 100, Count = 20 });

            var products = queryMediator.Process<ListProductQuery, IEnumerable<ListProductResult>> (new ListProductQuery());

            foreach(var product in products)
            {
                Console.WriteLine($"{product.Name} - {product.BrandName} / {product.Price:c}");
            }
        }
    }
}
