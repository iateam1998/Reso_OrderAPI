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
    public class ProductCategoryController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        IUtils _utils;
        public ProductCategoryController(IUtils utils, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _utils = utils;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllProductCategories()
        {
            var productCategoryService = ServiceFactory.CreateService<IProductCategoryService>(_serviceProvider);
            var result = productCategoryService.GetAllProductCategories();
            return Ok(result);
        }

        [HttpGet]
        [Route("{brandId}")]
        public IActionResult GetProductCategoriesByBrandId(int brandId)
        {
            var productCategoryService = ServiceFactory.CreateService<IProductCategoryService>(_serviceProvider);
            var result = productCategoryService.GetProductCategoriesByBrandId(brandId);
            if (result == null)
            {
                return NotFound();
            }
            else return Ok(result);
        }
    }
}