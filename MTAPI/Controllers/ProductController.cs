using Azure;
using BusinessLayer.Abstrack;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MTAPI.Extansions;
using MTAPI.Models;

namespace MTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices productServices;

        public ProductController(IProductServices productServices)
        {
            this.productServices = productServices;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var result = productServices.GetAllProducts();
            return Ok(result);
        }

        [HttpGet("getById/{id}")]
        public IActionResult Get(int id)
        {
            var result = productServices.GetProductsById(id);
            if (result == null)
                throw new GlobalNotFoundException(id);


            return Ok(result);
        }

        [HttpGet("getByCategory/{category}")]
        public IActionResult GetByCategory(string category)
        {
            var result = productServices.getProductsByCategory(category);
            if (result == null)
               throw new GlobalNotFoundException(category);

            return Ok(new { success = true, data = result });
        }

        [HttpPost("add")]
        public IActionResult AddProduct([FromBody] Products newProduct)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var result = productServices.AddProducts(newProduct);
            if (result == null)
                throw new GlobalNotFoundException("product is null");
 
            return Ok(result);
           
        }

        [HttpPut("update")]
        public IActionResult UpdateProduct([FromBody] Products updatedProduct)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

       
            var result = productServices.UpdateProducts(updatedProduct);
            if (result == null)      
               throw new GlobalNotFoundException("product is null");

            return Ok(result);
      
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteProduct(int id)
        {

            productServices.DeleteProducts(id);
            return NoContent();

            
        }
    }
}
