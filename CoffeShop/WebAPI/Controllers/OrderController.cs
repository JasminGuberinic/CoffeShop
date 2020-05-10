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

        [Route("order")]
        [HttpPost]
        public Task<IActionResult> Post(CreateOrderCommand request)
            => RequestHandler.HandleCommand(request, _orderCommandService.Handle, _logger);

        [Route("athome")]
        [HttpPost]
        public Task<IActionResult> Post(AddCoffeAtHomeCommand request)
            => RequestHandler.HandleCommand(request, _orderCommandService.Handle, _logger);

        [Route("todrink")]
        [HttpPost]
        public Task<IActionResult> Post(AddCoffeToDrinkCommand request)
            => RequestHandler.HandleCommand(request, _orderCommandService.Handle, _logger);

        [Route("done/home")]
        [HttpPost]
        public Task<IActionResult> Post(CoffeAtHomeOrderDoneCommand request)
            => RequestHandler.HandleCommand(request, _orderCommandService.Handle, _logger);

        [Route("done/drink")]
        [HttpPost]
        public Task<IActionResult> Post(OrderToDrinkDoneCommand request)
            => RequestHandler.HandleCommand(request, _orderCommandService.Handle, _logger);

        [Route("kichen")]
        [HttpPost]
        public Task<IActionResult> Post(KichenReceiveDrinkOrderCommand request)
            => RequestHandler.HandleCommand(request, _orderCommandService.Handle, _logger);

        [Route("stock")]
        [HttpPost]
        public Task<IActionResult> Post(StockReceiveCoffeAtHomeCommand request)
            => RequestHandler.HandleCommand(request, _orderCommandService.Handle, _logger);
    }
}
