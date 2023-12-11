using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NegotiationApp.Entities.DTOs.Product;
using NegotiationApp.Entities.Products;
using NegotiationApp.Services.ProductService;
using NegotiationApp.Services.Validation.Product;
using System.Data;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;
        private readonly IProductValidationService _validationService;

        public ProductController(
            ILogger<ProductController> logger, 
            IProductService productService, 
            IProductValidationService validationService
            )
        {
            _validationService = validationService;
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
            string errorMessage = _validationService.ValidateProduct(productToCreate);

            var createdProduct = await _productService.CreateProductAsync(productToCreate);
            bool productExist = createdProduct != null;

            if (productExist && errorMessage == string.Empty)
            {
                return Ok(createdProduct);
            }

            else if (errorMessage != string.Empty)
            {
                return BadRequest(errorMessage);
            }

            else return BadRequest();
        }

        [HttpPut("{id}", Name = "UpdateProduct")]
        public async Task<ActionResult> Update(int id, [FromBody] ProductUpdateDto productToUpdate)
        {
            string errorMessage = _validationService.ValidateProduct(new ProductCreateDto 
            {
                Name = productToUpdate.Name, 
                Price = productToUpdate.Price
            });

            var updatedProduct = await _productService.UpdateProductAsync(id, productToUpdate);
            bool productExist = updatedProduct != null;

            if (productExist)
            {
                return Ok(updatedProduct);
            }

            else if (errorMessage != string.Empty)
            {
                return BadRequest(errorMessage);
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
