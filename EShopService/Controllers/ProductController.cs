using EShop.Application.Services;
using EShop.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace EShopService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController(IProductService productService) : ControllerBase
    {
        private readonly IProductService _productService = productService;

        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productService.GetAllProducts();
        }

        // GET api/Product/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        // POST api/Product
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            _productService.AddProduct(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        // PUT api/Product/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _productService.UpdateProduct(product);
            return NoContent();
        }

        // DELETE api/Product/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
