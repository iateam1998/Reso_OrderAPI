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
    public class OrderDetailController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;
        IUtils _utils;
        public OrderDetailController(IUtils utils, IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _utils = utils;
        }

        [HttpGet]
        [Route("{storeId}")]
        public IActionResult GetAllOrderDetailByRentID(int storeId, [FromQuery] OrderDetailRequestModel model)
        {
            var orderDetailService = ServiceFactory.CreateService<IOrderDetailService>(_serviceProvider);
            var result = orderDetailService.GetAllOrderDetailByRentID(storeId, model);
            var check = result.Count();
            if (check != 0)
            {
                return Ok(result);
            }
            return NotFound(); 
        }

        [HttpGet]
        [Route("{storeId}/{orderDetailID}")]
        public IActionResult GetOrderDetailByIDSync(int storeId, int orderDetailID)
        {
            var orderDetailService = ServiceFactory.CreateService<IOrderDetailService>(_serviceProvider);
            var result = orderDetailService.GetOrderDetailByIDSync(storeId, orderDetailID);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(); 
        }
    }
}