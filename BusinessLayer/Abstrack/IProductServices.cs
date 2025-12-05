using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Abstrack
{
    public interface IProductServices
    {
        List<Products> GetAllProducts();

        Products GetProductsById(int id);

        Products AddProducts(Products products);

        Products UpdateProducts(Products products);

        Task<List<Products>> getProductsByCategory(string category);


        void DeleteProducts(int id);
    }
}
