using APW.Business;
using APW.Models;
using APW.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APW.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductApiController : ApiControllerBase
    {
        private readonly ILogger<ProductApiController> _logger;
        private readonly IProductBusiness _business;
        private readonly IProductRepository _repository;

        public ProductApiController(
            ILogger<ProductApiController> logger,
            IProductBusiness business,
            IProductRepository repository)
        {
            _logger = logger;
            _business = business;
            _repository = repository;
        }

        //tira todos los productos de la bd
        [HttpGet]
        public async Task<ComplexObject> Get()
        {
            _logger.LogInformation("Getting all products");
            var results = await _business.GetProductsAsync();
            return CreateComplexObject<Product>(results);
        }

        // muestra un producto especifico por ID
        [HttpGet("{id:int}", Name = "GetProductById")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
           
            var product = await _repository.FindAsync(id);
            if (product == null)
            {
                return NotFound(new ComplexObject
                {
                    Entities = Enumerable.Empty<object>(),
                });
            }

            return Ok(CreateComplexObject<Product>(new[] { product }));
        }

        /*
         Para este insert pueden usar este body en el swagger
        {
                  "productName": "Test12312321",
                  "description": "Test123123",
                  "rating": 5.0,
                  "categoryId": 5,
                  "supplierId": 2,
                  "inventoryId": 7,
                  "createdBy": "Admin"
        }
         
         */
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest(new ComplexObject
                {
                    Entities = Enumerable.Empty<object>(),
                    Errors = new List<string> { "Product is null" }
                });
            }

            var created = await _business.CreateProductAsync(product);
            if (!created)
            {
                return BadRequest(new ComplexObject
                {
                    Entities = Enumerable.Empty<object>(),
                    Errors = new List<string> { "Create failed" }
                });
            }

            return CreatedAtRoute(
                routeName: "GetProductById",
                routeValues: new { id = product.ProductId },
                value: CreateComplexObject<Product>(new[] { product })
            );
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] Product product)
        {
            if (product == null || id != product.ProductId)
            {
                return BadRequest(new ComplexObject
                {
                    Entities = Enumerable.Empty<object>(),
                });
            }

            var existing = await _repository.FindAsync(id);
            if (existing == null)
            {
                return NotFound(new ComplexObject
                {
                    Entities = Enumerable.Empty<object>(),
                });
            }

            var updated = await _repository.UpdateAsync(product);
            if (!updated)
            {
                return BadRequest(new ComplexObject
                {
                    Entities = Enumerable.Empty<object>(),
                });
            }

            return Ok(CreateComplexObject<Product>(new[] { product }));
        }

        //aca pueden primero tirar el get en el swagger y de ahi sacar el ID para meterlo aca
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var product = await _repository.FindAsync(id);
            if (product == null)
            {
                return NotFound(new ComplexObject
                {
                    Entities = Enumerable.Empty<object>(),
                });
            }

            var deleted = await _repository.DeleteAsync(product);
            if (!deleted)
            {
                return BadRequest(new ComplexObject
                {
                    Entities = Enumerable.Empty<object>(),
                });
            }

            return NoContent();
        }
    }
}