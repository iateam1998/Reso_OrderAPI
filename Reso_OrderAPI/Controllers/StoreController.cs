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
    public class StoreController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        IUtils _utils;
        public StoreController(IUtils utils, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _utils = utils;
        }

        [HttpGet]
        [Route("allStoreAvailable")]
        public IActionResult GetAllStoreAvailable()
        {
            var storeService = ServiceFactory.CreateService<IStoreService>(_serviceProvider);
            var result = storeService.GetAllStoreAvailable();
            return Ok(result);
        }

        [HttpGet]
        [Route("store/{id}")]
        public IActionResult GetAllProductAvailableByCategoryId(int id)
        {
            var storeService = ServiceFactory.CreateService<IStoreService>(_serviceProvider);
            var result = storeService.GetStoreByIdSync(id);
            if (result == null)
            {
                return NotFound();
            }
            else return Ok(result);
        }

        [HttpGet]
        [Route("allStore/{brandId}")]
        public IActionResult GetAllStoreByBrandId(int brandId)
        {
            var storeService = ServiceFactory.CreateService<IStoreService>(_serviceProvider);
            var result = storeService.GetAllStoreByBrandId(brandId);
            if (result == null)
            {
                return NotFound();
            }
            else return Ok(result);
        }
    }
}