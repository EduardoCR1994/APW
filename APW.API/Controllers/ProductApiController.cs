using APW.Business;
using APW.Models;
using Microsoft.AspNetCore.Mvc;

namespace APW.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductApiController(ILogger<ProductApiController> logger, IProductBusiness business) : ApiControllerBase
    {

        private readonly ILogger<ProductApiController> _logger = logger; //el readonly es para que no se pueda modificar despues de la inicializacion, solo que puede ser modificado en el constructor

        [HttpGet]
        public async Task<ComplexObject> Get()
        {
            _logger.LogInformation("Getting all products");
            var results = await business.GetProductsAsync();
            return CreateComplexObject<Product>(results);
        }
    }
}
