using APW.Models;
using Microsoft.AspNetCore.Mvc;

namespace APW.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductApiController : ControllerBase
    {
       
        private readonly ILogger<ProductApiController> _logger; //el readonly es para que no se pueda modificar despues de la inicializacion, solo que puede ser modificado en el constructor

        //el ILogger es una interfaz generica que permite registrar mensajes de log, y se inyecta en el constructor del controlador

        public ProductApiController(ILogger<ProductApiController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetProducts")]
        public IEnumerable<Product> Get()
        {
            return [.. Enumerable.Range(1, 100).Select(index => new Product
            {
                Id = index +1,
                Name = $"Product {index+1}",
                Price = Math.Round((decimal)(new Random().NextDouble() + 100), 2)
            })];
        }
    }
}
