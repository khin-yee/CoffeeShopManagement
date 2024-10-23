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

        [HttpPost("/AddProduct")]

        public bool AddProduct(ProductDto product)
        {
            return _service.AddProduct(product);
        }

        [HttpPost("/DeleteProduct")]
        public Task<Response> DeleteProduct([FromForm] string name)
        {
            return _service.DeleteProductByEmail(name);
        }
        [HttpPost("/AddOrder")]
        public Response AddOrder(OrderDto order)
        {
            return _service.CreateOrder(order);
        }
        [HttpGet("/Order")]
        public async Task<List<OrderDto>> GetOrder()
        {
            return await _service.GetOrder();
        }
        [HttpGet("/Ingredient")]
        public async Task<List<IngredientDTO>> GetIngredient()
        {
            return await _service.GetIngredient();
        }
        [HttpPost("/AddIngredient")]
        public Response AddIngredient(IngredientDTO ingredient)
        {
            return _service.CreateIngredient(ingredient);
        }
        [HttpPost("/DeleteOrder")]
        public Task<Response> DeleteOrder([FromForm] string customername, [FromForm] string productname)
        {
            return _service.DeleteOrderByName(customername,productname);
        }
        [HttpPost("/DeleteIngredient")]
        public Task<Response> DeleteIngredient([FromForm] string name)
        {
            return _service.DeleteIngredientByName(name);
        }
    }
}
