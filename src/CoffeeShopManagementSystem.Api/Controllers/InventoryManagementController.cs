using CoffeeShopManagementSystem.Domain.IService;
using CoffeeShopManagementSystem.Domain.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeShopManagementSystem.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryManagementController : ControllerBase
    {
        private readonly IInventoryManagementService _service;
        public InventoryManagementController (IInventoryManagementService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<List<ProductDto>> GetProduct()
        {
            return await _service.GetProduct();
        }
    }
}
