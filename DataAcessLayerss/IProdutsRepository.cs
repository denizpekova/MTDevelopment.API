using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAcessLayerss
{
    public interface IProdutsRepository
    {
        List<Products> GetAllProducts();

        Products GetProductsById(int id);

        Products AddProducts(Products products);

        Products UpdateProducts(Products products);

        Task<List<Products>> getProductsByCategory(string category);

        void DeleteProducts(int id);
    }
}
