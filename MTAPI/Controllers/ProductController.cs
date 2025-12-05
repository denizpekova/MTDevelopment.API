using BusinessLayer.Abstrack;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            {
                return NotFound(new { success = false, message = "Product not found." });
            }
            return Ok(new { success = true, data = result });
        }

        [HttpGet("getByCategory/{category}")]
        public IActionResult GetByCategory(string category)
        {
            var result = productServices.getProductsByCategory(category);
            return Ok(new { success = true, data = result });
        }

        [HttpPost("add")]
        public IActionResult AddProduct([FromBody] Products newProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = productServices.AddProducts(newProduct);
                return Ok(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Error adding product: {ex.Message}" });
            }
        }

        [HttpPut("update")]
        public IActionResult UpdateProduct([FromBody] Products updatedProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = productServices.UpdateProducts(updatedProduct);
                return Ok(new { success = true, data = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Error updating product: {ex.Message}" });
            }
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteProduct(int id)
        {
            try
            {
                productServices.DeleteProducts(id);
                return Ok(new { success = true, message = "Product deleted successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = $"Error deleting product: {ex.Message}" });
            }
        }
    }
}
