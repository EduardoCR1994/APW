using APW.Data.Repositories;
using APW.Models;
using Microsoft.AspNetCore.Mvc;

namespace APW.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductApiController : ControllerBase
    {
       
        private readonly ILogger<ProductApiController> _logger; //el readonly es para que no se pueda modificar despues de la inicializacion, solo que puede ser modificado en el constructor
        private readonly IProductRepository _productRepository;
        //el ILogger es una interfaz generica que permite registrar mensajes de log, y se inyecta en el constructor del controlador

        public ProductApiController(ILogger<ProductApiController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [HttpGet(Name = "GetProducts")]
        public IEnumerable<Product> Get()
        {
            var products = _productRepository.GetProducts();
            return [.. products.Select(p => new Product
            {
                Id = p.ProductId,
                Name = p.ProductName ?? "Name not found",
                Price = p.Inventory?.UnitPrice ?? -1
            })];
        }
    }
}
