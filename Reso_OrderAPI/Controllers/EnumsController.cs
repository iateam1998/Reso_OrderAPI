using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataService.Model.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Reso_OrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnumsController : ControllerBase
    {
        [HttpGet("account_type")]
        public IActionResult GetOrderTypeEnum()
        {
            return Ok(Enums.Get<OrderTypeEnum>());
        }

        [HttpGet("payment_type")]
        public IActionResult GetPaymentTypeEnum()
        {
            return Ok(Enums.Get<PaymentTypeEnum>());
        }

    }

    
}