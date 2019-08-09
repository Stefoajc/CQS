using System;
using System.Collections.Generic;
using CQS.DB.DbModels;

namespace CQS.Repositories
{
    public class ProductRepository : MonolithicImplementation.RepositoryInterfaces.IProductRepository,
        SOLID.RepositoryInterfaces.IProductRepository,
        FinalWithCasting.RepositoryInterfaces.IProductRepository,
        FinalGeneric.RepositoryInterfaces.IProductRepository
    {
        private static List<Product> products = new List<Product>
        {
            new Product{ Id = Guid.NewGuid(), BrandName = "Nike", Name="Nike Air Max", Count = 10, Price = 100 },
            new Product{ Id = Guid.NewGuid(), BrandName = "Adidas", Name="Cloudfoam Racer TR", Count = 10, Price = 100 },
            new Product{ Id = Guid.NewGuid(), BrandName = "Reebok", Name="Trainflex", Count = 10, Price = 100 },
            new Product{ Id = Guid.NewGuid(), BrandName = "Puma", Name="Slider", Count = 10, Price = 100 },
        };

        private static System.Collections.Concurrent.ConcurrentDictionary<Guid, Product> dbTableMock;

        public ProductRepository()
        {
            dbTableMock = new System.Collections.Concurrent.ConcurrentDictionary<Guid, Product>();
            foreach(var product in products)
            {
                dbTableMock.TryAdd(product.Id, product);
            }
        }


        public Product Create(Product product)
        {
            dbTableMock.TryAdd(product.Id, product);
            return product;
        }

        public void Delete(Guid Id)
        {
            dbTableMock.TryRemove(Id, out _);
        }

        public Product Edit(Product product)
        {
            dbTableMock.AddOrUpdate(product.Id, product, (Guid id, Product oldProduct) => product);
            return product;
        }

        public bool Exists(Guid id)
        {
            return dbTableMock.ContainsKey(id);
        }

        public Product Get(Guid Id)
        {
            return dbTableMock[Id];
        }

        public IEnumerable<Product> List()
        {
            var products = new List<Product>();
            foreach(var product in dbTableMock)
            {
                products.Add(product.Value);
            }

            return products;
        }
    }
}
