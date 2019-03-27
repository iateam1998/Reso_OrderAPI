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
        [Route("{rentId}")]
        public IActionResult GetAllOrderDetailByRentID(int rentId, [FromQuery] OrderDetailRequestModel model)
        {
            var orderDetailService = ServiceFactory.CreateService<IOrderDetailService>(_serviceProvider);
            var result = orderDetailService.GetAllOrderDetailByRentID(rentId, model);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("orderdetail/{orderDetailID}")]
        public IActionResult GetOrderDetailByIDSync(int orderDetailID)
        {
            var orderDetailService = ServiceFactory.CreateService<IOrderDetailService>(_serviceProvider);
            var result = orderDetailService.GetOrderDetailByIDSync(orderDetailID);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}