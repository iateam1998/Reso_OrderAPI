using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService;
using DataService.Model.ViewModel;
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
        public IActionResult GetOrders(int storeId, [FromQuery] OrderRequestModel orderRequest)
        {
            var orderService = ServiceFactory.CreateService<IOrderService>(_serviceProvider);
            var result = orderService.GetOrders(storeId, orderRequest);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("order/{rentID}")]
        public IActionResult GetOrderByRentID(int rentID)
        {
            var orderService = ServiceFactory.CreateService<IOrderService>(_serviceProvider);
            var result = orderService.GetOrderByRentID(rentID);
            if (result == null)
            {
                return NotFound();
            }
            else return Ok(result);
        }
    }
}