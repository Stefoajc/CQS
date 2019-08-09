using CQS.MonolithicImplementation;
using CQS.Repositories;
using System;

namespace CQS.UI
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello World!");

            var productService = new ProductServices(new ProductRepository());

            productService.Create(new Models.ProductCreateDTO { BrandName = "Asics", Name = "Gel", Price = 80, Count = 12 });

        }
    }
}
