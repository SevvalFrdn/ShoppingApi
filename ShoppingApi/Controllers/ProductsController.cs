using Microsoft.AspNetCore.Mvc;
using ShoppingApi.Entities;
using ShoppingApi.Services;
using ShoppingRedis.Redis;
using System.Collections.Generic;

namespace ShoppingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller
    {
        private readonly ProductServices _ProductService;
        private readonly ICacheServices _cacheService;
        public ProductsController(ProductServices productService)
        {
            _ProductService = productService;
        }

        [HttpGet]
        public ActionResult<List<Product>> Get() =>
            _ProductService.Get();

        [HttpGet("{id)}")]
        public ActionResult<Product> Get(string id)
        {
            var product = _ProductService.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        [HttpPost]
        public ActionResult<Product> Create(Product product)
        {
            _ProductService.Create(product);

            return CreatedAtRoute("GetProduct", new { id = product.Id.ToString() }, product);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Product products)
        {
            var product = _ProductService.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            _ProductService.Update(id, products);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var product = _ProductService.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            _ProductService.Remove(id);

            return NoContent();
        }

    
    }
}
