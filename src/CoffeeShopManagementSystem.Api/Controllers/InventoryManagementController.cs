using CoffeeShopManagementSystem.Domain.IService;
using CoffeeShopManagementSystem.Domain.Model;
using CoffeeShopManagementSystem.Domain.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryManagementController : ControllerBase
    {
        private readonly IProductService _service;
        public InventoryManagementController (IProductService service)
        {
            _service = service;
        }
        [HttpGet("/Product")]
        public async Task<List<ProductDto>> GetProduct()
        {
            return await _service.GetProduct();
        }
        [HttpPost("/AccValidate")]

        public async Task<User> GetUserByEmail([FromForm] string name, [FromForm] string password)
        {
            return await  _service.GetUserByEmail(name, password);
        }
    }
}
