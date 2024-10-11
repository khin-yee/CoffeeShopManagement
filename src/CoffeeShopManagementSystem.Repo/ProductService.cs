using AutoMapper;
using CoffeeShopManagementSystem.Domain.IRepo;
using CoffeeShopManagementSystem.Domain.IService;
using CoffeeShopManagementSystem.Domain.Model;
using CoffeeShopManagementSystem.Domain.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopManagementSystem.Service
{
    public class ProductService:IProductService
    {
        private readonly IRepo _productrepo;
        private readonly IMapper _mapper;

        public ProductService(IRepo productrepo, IMapper mapper)
        {
            _productrepo = productrepo;
            _mapper = mapper;
        }
        public async Task<List<ProductDto>> GetProduct()
        {
            var res = await  _productrepo.GetProduct();
            try
            {
               
                var response = _mapper.Map<List<ProductDto>>(res);
                return response;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool AddProduct(ProductDto product)
        {
            return  _productrepo.AddProduct(product);
        }
        public async Task<User> GetUserByEmail(string name,string password)
        {
            return await _productrepo.GetUserByEmail(name, password);
        }
        public Response DeleteProduct(ProductDto productDto)
        {
            return  _productrepo.DeleteProduct(productDto);
        }

        public Response CreateOrder(OrderDto order)
        {
            return _productrepo.CreateOrder(order);
        }
    }
}
