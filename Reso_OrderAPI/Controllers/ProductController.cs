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
    public class ProductController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        IUtils _utils;
        public ProductController(IUtils utils, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _utils = utils;
        }

        [HttpGet]
        [Route("allproduct/{brandId}")]
        public IActionResult GetAllProductsByBrand(int brandId)
        {
            var productService = ServiceFactory.CreateService<IProductService>(_serviceProvider);
            var result = productService.GetAllProductsByBrand(brandId);
            return Ok(result);
        }

        [HttpGet]
        [Route("allProductAvailable/{categoryId}")]
        public IActionResult GetAllProductAvailableByCategoryId(int categoryId)
        {
            var productService = ServiceFactory.CreateService<IProductService>(_serviceProvider);
            var result = productService.GetAllProductAvailableByCategoryId(categoryId);
            if (result == null)
            {
                return NotFound();
            }
            else return Ok(result);
        }
    }
}