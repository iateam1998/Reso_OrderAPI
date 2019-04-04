using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        //[HttpGet]
        //[Route("{storeId}")]
        //public IActionResult GetOrders(int storeId, [FromQuery] OrderRequestModel orderRequest)
        //{
        //    var orderService = ServiceFactory.CreateService<IOrderService>(_serviceProvider);
        //    var result = orderService.GetOrders(storeId, orderRequest);
        //    var check = result.Count();
        //    if (check != 0)
        //    {
        //        return Ok(result);
        //    }
        //    return NotFound(); 
        //}

        [HttpGet]
        [Route("GetAllOrders")]
        public IActionResult GetOrders([FromQuery] OrderRequestModel orderRequest)
        {
            var orderService = ServiceFactory.CreateService<IOrderService>(_serviceProvider);
            var result = orderService.GetOrders(orderRequest);
            var check = result.Count();
            if (check != 0)
            {
                return Ok(result);
            }
            return NotFound();
        }

        //[HttpGet]
        //[Route("{storeId}/{rentID}")]
        //public IActionResult GetOrderByRentID(int storeId, int rentID)
        //{
        //    var orderService = ServiceFactory.CreateService<IOrderService>(_serviceProvider);
        //    var result = orderService.GetOrderByRentID(storeId, rentID);
        //    if (result != null)
        //    {
        //        return Ok(result);
        //    }
        //    return NotFound(); 
        //}

        //[HttpGet]
        //[Route("GetOrder")]
        //public IActionResult GetOrderByRentID([FromQuery] OrderRequestModel orderRequest)
        //{
        //    var orderService = ServiceFactory.CreateService<IOrderService>(_serviceProvider);
        //    var result = orderService.GetOrderByRentID(orderRequest);
        //    if (result != null)
        //    {
        //        return Ok(result);
        //    }
        //    return NotFound();
        //}

        [HttpPost]
        [Route("CreateOrder/{storeId}")]
        public IActionResult CreateOrder(int storeId, OrderApiViewModel order)
        {
            var orderService = ServiceFactory.CreateService<IOrderService>(_serviceProvider);
            var result = orderService.CreateOrder(storeId, order);
            if (result == true)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPut]
        [Route("UpdateOrder/{storeId}")]
        public IActionResult UpdateOrder(int storeId, OrderApiViewModelForUpdate order)
        {
            var orderService = ServiceFactory.CreateService<IOrderService>(_serviceProvider);
            var result = orderService.UpdateOrder(storeId, order);
            if (result == true)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}