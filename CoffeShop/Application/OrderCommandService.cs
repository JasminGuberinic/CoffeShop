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
            switch(command)
            {
                case CreateOrderCommand e:
                    await HandleCreate((CreateOrderCommand)command);
                    break;
                case AddCoffeToDrinkOrderCommand e:
                    await HandleCommand((AddCoffeToDrinkOrderCommand)command);
                    break;
                case AddCoffeCupcakeOrderCommand e:
                    await HandleCommand((AddCoffeCupcakeOrderCommand)command);
                    break;
                case StockReceivedCoffeCupcakeOrderCommand e:
                    await HandleCommand((StockReceivedCoffeCupcakeOrderCommand)command);
                    break;
                case KichenReceivedDrinkOrderCommand e:
                    await HandleCommand((KichenReceivedDrinkOrderCommand)command);
                    break;
                case OrderForDrinkDoneCommand e:
                    await HandleCommand((OrderForDrinkDoneCommand)command);
                    break;
                case CoffeCupcakeOrderDoneCommand e:
                    await HandleCommand((CoffeCupcakeOrderDoneCommand)command);
                    break;
            }
        }

        private async Task HandleCommand(CoffeCupcakeOrderDoneCommand command)
        {
            var oreder = orederRepo.LoadAsync(command.OrderId.ToString());
            oreder.CoffeCupcakeOrderDone(command.Id);
            await orederRepo.SaveAsync(oreder);
        }

        private async Task HandleCommand(OrderForDrinkDoneCommand command)
        {
            var oreder = orederRepo.LoadAsync(command.OrderId.ToString());
            oreder.OrderToDrinkDone(command.Id);
            await orederRepo.SaveAsync(oreder);
        }

        private async Task HandleCommand(KichenReceivedDrinkOrderCommand command)
        {
            var oreder = orederRepo.LoadAsync(command.OrderId.ToString());
            oreder.KichenReceiveDrinkOrder(command.Id);
            await orederRepo.SaveAsync(oreder);
        }

        private async Task HandleCommand(StockReceivedCoffeCupcakeOrderCommand command)
        {
            var oreder = orederRepo.LoadAsync(command.OrderId.ToString());
            oreder.SetStockReceivedCoffeCupcakeOrder(command.Id);
            await orederRepo.SaveAsync(oreder);
        }

        private async Task HandleCommand(AddCoffeCupcakeOrderCommand command)
        {
            var oreder = orederRepo.LoadAsync(command.Id.ToString());
            oreder.AddCoffeCupcakeOrderOrder(command.CoffeToGo);
            await orederRepo.SaveAsync(oreder);
        }

        private async Task HandleCommand(AddCoffeToDrinkOrderCommand command)
        {
            var oreder = orederRepo.LoadAsync(command.Id.ToString());
            oreder.AddCoffeToDrinkOrder(command.CoffeToDrinkOrder);
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
