using APW.Architecture;
using APW.Web.Models;
using APW.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace APW.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IWrapperServiceProvider _serviceProvider;
        private readonly IRestProvider _restProvider;

        public ProductController(
            ILogger<ProductController> logger,
            IWrapperServiceProvider serviceProvider,
            IRestProvider restProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
            _restProvider = restProvider;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _serviceProvider
                .GetDataAsync<IEnumerable<ProductViewModel>>(
                    "http://localhost:5096/ProductApi"
                );
            
            return View(data);
        }
    }
}