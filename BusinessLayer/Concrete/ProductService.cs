using BusinessLayer.Abstrack;
using DataAcessLayerss;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class ProductService : IProductServices
    {
        private readonly IProdutsRepository produtsRepository;

        public ProductService(IProdutsRepository produtsRepository)
        {
            this.produtsRepository = produtsRepository;
        }

        public Products AddProducts(Products products)
        {
            return produtsRepository.AddProducts(products);
        }

        public void DeleteProducts(int id)
        {
            produtsRepository.DeleteProducts(id);
        }

        public List<Products> GetAllProducts()
        {
            return produtsRepository.GetAllProducts();
        }

        public async Task<List<Products>> getProductsByCategory(string category)
        {
            return await produtsRepository.getProductsByCategory(category);
        }

        public Products GetProductsById(int id)
        {
            return produtsRepository.GetProductsById(id);
        }

        public Products UpdateProducts(Products products)
        {
           return produtsRepository.UpdateProducts(products);
        }
    }
}
