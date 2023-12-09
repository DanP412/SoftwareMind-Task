using Microsoft.AspNetCore.Mvc;
using NegotiationApp.Data.Entities.Configuration;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly NegotiaionAppDbContext _negotiaionAppDbContext;

        public ProductController(ILogger<ProductController> logger, NegotiaionAppDbContext negotiaionAppDbContext)
        {
            _logger = logger;
            _negotiaionAppDbContext = negotiaionAppDbContext;
        }
        [HttpGet(Name = "GetAllProducts")]
        public IEnumerable<string> GetAll()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPut(Name = "GetProduct")]
        public ActionResult Update()
        {
            return Ok();
        }

        [HttpDelete(Name ="DeleteProduct")]
        public ActionResult Delete(int id)
        {
            return Ok();
        }
    }
}
