using DataAcessLayerss.Context;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcessLayerss
{
    public class ProductsRepository : IProdutsRepository
    {
        private readonly AppDbContext dbContexts;

        public ProductsRepository(AppDbContext dbContexts)
        {
            this.dbContexts = dbContexts;
        }

        public Products AddProducts(Products products)
        {
            dbContexts.Products.Add(products);
            dbContexts.SaveChanges();
            return products;
        }

        public void DeleteProducts(int id)
        {
            var product = GetProductsById(id);
            if (product != null)
            {
                dbContexts.Products.Remove(product);
                dbContexts.SaveChanges();
            }
        }

        public List<Products> GetAllProducts()
        {
            return dbContexts.Products.ToList();
        }

        public async Task<List<Products>> getProductsByCategory(string category)
        {
            return await dbContexts.Products.Where(p => p.Category == category).ToListAsync();
        }

        public Products GetProductsById(int id)
        {
            return dbContexts.Products.Find(id);
        }

        public Products UpdateProducts(Products products)
        {
            dbContexts.Products.Update(products);
            dbContexts.SaveChanges();
            return products;
        }
    }
}
