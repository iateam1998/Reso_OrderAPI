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
    public class CategoryExtraMappingController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        IUtils _utils;
        public CategoryExtraMappingController(IUtils utils, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _utils = utils;
        }

        [HttpGet]
        [Route("all")]
        public IActionResult GetAllCategoryExtraMappings()
        {
            var CategoryExtraMappingService = ServiceFactory.CreateService<ICategoryExtraMappingService>(_serviceProvider);
            var result = CategoryExtraMappingService.GetAllCategoryExtraMappings();
            return Ok(result);
        }

        [HttpGet]
        [Route("{ExtraCategoryId}")]
        public IActionResult GetCategoryExtraMappingsByExtraCategoryId(int extraCategoryId)
        {
            var CategoryExtraMappingService = ServiceFactory.CreateService<ICategoryExtraMappingService>(_serviceProvider);
            var result = CategoryExtraMappingService.GetCategoryExtraMappingsByExtraCategoryId(extraCategoryId);
            if (result == null)
            {
                return NotFound();
            }
            else return Ok(result);
        }
    }
}