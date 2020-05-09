using Application.Command;
using Application.Dto;
using Domain;
using infrastructure;
using System;
using System.Threading.Tasks;

namespace Application
{
    public class OrderCommandService
    {
        OrderRepository orederRepo;

        public OrderCommandService () 
        {
            orederRepo = new OrderRepository();
        }

        public async Task Handle(object command)
        {
            if (command is CreateOrderCommand)
            {
                var order = await HandleCreate((CreateOrderCommand)command);
            }

            if (command is AddCoffeToDrinkCommand)
            {
               HandleCommand((AddCoffeToDrinkCommand)command);
            }

            if (command is AddCoffeAtHomeCommand)
            {
               HandleCommand((AddCoffeAtHomeCommand)command);
            }

            if (command is StockReceiveCoffeAtHomeCommand)
            {
                HandleCommand((StockReceiveCoffeAtHomeCommand)command);
            }

            if (command is KichenReceiveDrinkOrderCommand)
            {
                HandleCommand((KichenReceiveDrinkOrderCommand)command);
            }

            if (command is OrderToDrinkDoneCommand)
            {
                HandleCommand((OrderToDrinkDoneCommand)command);
            }

            if (command is CoffeAtHomeOrderDoneCommand)
            {
                HandleCommand((CoffeAtHomeOrderDoneCommand)command);
            }
        }

        private async Task HandleCommand(CoffeAtHomeOrderDoneCommand command)
        {
            var oreder = orederRepo.LoadAsync(command.OrderId.ToString());
            oreder.CoffeAtHomeDone(command.Id);
            await orederRepo.SaveAsync(oreder);
        }

        private async Task HandleCommand(OrderToDrinkDoneCommand command)
        {
            var oreder = orederRepo.LoadAsync(command.OrderId.ToString());
            oreder.OrderToDrinkDone(command.Id);
            await orederRepo.SaveAsync(oreder);
        }

        private async Task HandleCommand(KichenReceiveDrinkOrderCommand command)
        {
            var oreder = orederRepo.LoadAsync(command.OrderId.ToString());
            oreder.KichenReceiveDrinkOrder(command.Id);
            await orederRepo.SaveAsync(oreder);
        }

        private async Task HandleCommand(StockReceiveCoffeAtHomeCommand command)
        {
            var oreder = orederRepo.LoadAsync(command.OrderId.ToString());
            oreder.SetStockReceivedCoffeAtHome(command.Id);
            await orederRepo.SaveAsync(oreder);
        }

        private async Task HandleCommand(AddCoffeAtHomeCommand command)
        {
            var oreder = orederRepo.LoadAsync(command.Id.ToString());
            oreder.AddCoffeAtHomeOrder(command.CoffeToGo);
            await orederRepo.SaveAsync(oreder);
        }

        private async Task HandleCommand(AddCoffeToDrinkCommand command)
        {
            var oreder = orederRepo.LoadAsync(command.Id.ToString());
            oreder.AddCoffeToDrinkOrder(command.CoffeToDrink);
            await orederRepo.SaveAsync(oreder);
        }

        private async Task<Order> HandleCreate(CreateOrderCommand cmd)
        {
            var oreder = new Order(
                cmd.Id,
                cmd.IsOpen
            );
            await orederRepo.SaveAsync(oreder);
            return oreder;
        }
    }
}
