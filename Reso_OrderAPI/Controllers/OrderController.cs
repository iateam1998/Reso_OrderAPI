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
    public class OrderController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        IUtils _utils;
        public OrderController(IUtils utils, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _utils = utils;
        }

        [HttpGet]
        [Route("{storeId}")]
        public IActionResult GetOrders(int storeId)
        {
            var orderService = ServiceFactory.CreateService<IOrderService>(_serviceProvider);
            var result = orderService.GetOrdersByStoreId(storeId);
            return Ok(result);
        }
    }
}