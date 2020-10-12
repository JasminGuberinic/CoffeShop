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

        [Route("cupcake")]
        [HttpPost]
        public Task<IActionResult> Post(AddCoffeCupcakeOrderCommand request)
            => RequestHandler.HandleCommand(request, _orderCommandService.Handle, _logger);

        [Route("coffe")]
        [HttpPost]
        public Task<IActionResult> Post(AddCoffeToDrinkOrderCommand request)
            => RequestHandler.HandleCommand(request, _orderCommandService.Handle, _logger);

        [Route("done/cupcake")]
        [HttpPost]
        public Task<IActionResult> Post(CoffeCupcakeOrderDoneCommand request)
            => RequestHandler.HandleCommand(request, _orderCommandService.Handle, _logger);

        [Route("done/coffe")]
        [HttpPost]
        public Task<IActionResult> Post(OrderForDrinkDoneCommand request)
            => RequestHandler.HandleCommand(request, _orderCommandService.Handle, _logger);

        [Route("kichen")]
        [HttpPost]
        public Task<IActionResult> Post(KichenReceivedDrinkOrderCommand request)
            => RequestHandler.HandleCommand(request, _orderCommandService.Handle, _logger);

        [Route("stock")]
        [HttpPost]
        public Task<IActionResult> Post(StockReceivedCoffeCupcakeOrderCommand request)
            => RequestHandler.HandleCommand(request, _orderCommandService.Handle, _logger);
    }
}
