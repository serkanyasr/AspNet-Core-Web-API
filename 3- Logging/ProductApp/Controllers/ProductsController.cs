using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    // This attribute defines the route for this controller's actions.
    [Route("api/products")]
    // This attribute marks the class as a Web API controller.
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // The logger instance for logging information.
        private readonly ILogger<ProductsController> _logger;

        // Constructor that initializes the logger instance through dependency injection.
        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        // This attribute indicates that the following method will handle HTTP GET requests.
        [HttpGet]
        // This method handles GET requests to retrieve all products.
        public IActionResult GetAllProducts()
        {
            // Creating a list of products with sample data.
            var products = new List<Product>()
            {
                new Product(){ID=1 , ProductNanme="PC"},
                new Product(){ID=2 , ProductNanme="Monitor"},
            };

            // Logging information that the GetAllProducts action has been called.
            _logger.LogInformation("GetAllProducts action has been called");

            // Returning an OK response with the list of products.
            return Ok(products);
        }
    }
}
