using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NegotiationApp.Data.Entities.Configuration;
using NegotiationApp.Entities.DTOs;
using NegotiationApp.Entities.Products;
using NegotiationApp.Services.ProductService;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet(Name = "GetAll")]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var products = await _productService.GetAllProductsAsync();
            bool productsExist = products != null;

            if (productsExist)
            {
                return Ok(products);
            }
            else return BadRequest();
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<Product>> Get(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            bool productExist = product != null;

            if (productExist)
            {
                return Ok(product);
            }
            else return BadRequest();
        }

        [HttpPost(Name = "AddProduct")]
        public async Task<ActionResult> Post([FromBody] ProductCreateDto productToCreate)
        {
            var createdProduct = await _productService.CreateProductAsync(productToCreate);
            bool productExist = createdProduct != null;

            if (productExist)
            {
                return Ok(createdProduct);
            }
            else return BadRequest();
        }

        [HttpPut("{id}", Name = "UpdateProduct")]
        public async Task<ActionResult> Update(int id, [FromBody] ProductUpdateDto productToUpdate)
        {
            var updatedProduct = await _productService.UpdateProductAsync(id, productToUpdate);
            bool productExist = updatedProduct != null;

            if (productExist)
            {
                return Ok(updatedProduct);
            }

            else return BadRequest();
        }


        [HttpDelete("{id}", Name = "DeleteProduct")]
        public async Task<IActionResult> Delete(int id)
        {
            bool successfullyDeleted = await _productService.DeleteProductAsync(id);

            if (successfullyDeleted)
            {
                return Ok();
            }
            else return BadRequest();
        }
    }
}
