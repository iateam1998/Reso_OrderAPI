using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService;
using DataService.ServiceAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Reso_OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailMappingController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        IUtils _utils;
        public ProductDetailMappingController(IUtils utils, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _utils = utils;
        }

        [HttpGet]
        [Route("discount/{storeId}/{productId}")]
        public IActionResult GetDiscountByStore(int storeId, int productId)
        {
            var productDetailMappingService = ServiceFactory.CreateService<IProductDetailMappingService>(_serviceProvider);
            var result = productDetailMappingService.GetDiscountByStore(storeId, productId);
            return Ok(result);
        }
        
        [HttpGet]
        [Route("price/{storeId}/{productId}")]
        public IActionResult GetPriceByStore(int storeId, int productId)
        {
            var productDetailMappingService = ServiceFactory.CreateService<IProductDetailMappingService>(_serviceProvider);
            var result = productDetailMappingService.GetPriceByStore(storeId, productId);
            return Ok(result);
        }

        [HttpGet]
        [Route("product/{storeId}/{brandId}")]
        public IActionResult GetProductByStoreID(int storeId, int brandId)
        {
            var productDetailMappingService = ServiceFactory.CreateService<IProductDetailMappingService>(_serviceProvider);
            var result = productDetailMappingService.GetProductByStoreID(storeId, brandId);
            return Ok(result);
        }
    }
}