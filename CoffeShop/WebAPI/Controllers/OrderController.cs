using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application;
using Application.Command;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private OrderCommandService _orderCommandService;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
            _orderCommandService = new OrderCommandService();
        }

        [HttpPost]
        public Task<IActionResult> Post(CreateOrderCommand request)
                    => RequestHandler.HandleCommand(request, _orderCommandService.Handle, _logger);
    }
}
