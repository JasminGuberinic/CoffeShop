using Application.Command;
using Application.Dto;
using Domain;
using System;
using System.Threading.Tasks;

namespace Application
{
    public class OrderCommandService
    {
        MoqRepo moqRepo = new MoqRepo();
        public async Task Handle(object command)
        {
            if (command is CreateOrderCommand)
            {
                _ = HandleCreate((CreateOrderCommand)command);
            }

            if (command is AddCoffeToDrinkCommand)
            {
                _ = HandleCommand((AddCoffeToDrinkCommand)command);
            }

            if (command is AddCoffeToGoCommand)
            {
               HandleCommand((AddCoffeToGoCommand)command);
            }

            if (command is KichenReceiveToGoOrderCommand)
            {
                _ = HandleCommand((KichenReceiveToGoOrderCommand)command);
            }

            if (command is KichenReceiveDrinkOrderCommand)
            {
                _ = HandleCommand((KichenReceiveDrinkOrderCommand)command);
            }

            if (command is OrderToDrinkDoneCommand)
            {
                _ = HandleCommand((OrderToDrinkDoneCommand)command);
            }

            if (command is ToGoOrderDoneCommand)
            {
                _ = HandleCommand((ToGoOrderDoneCommand)command);
            }
        }

        private object HandleCommand(ToGoOrderDoneCommand command)
        {
            throw new NotImplementedException();
        }

        private object HandleCommand(OrderToDrinkDoneCommand command)
        {
            throw new NotImplementedException();
        }

        private object HandleCommand(KichenReceiveDrinkOrderCommand command)
        {
            throw new NotImplementedException();
        }

        private object HandleCommand(KichenReceiveToGoOrderCommand command)
        {
            throw new NotImplementedException();
        }

        private void HandleCommand(AddCoffeToGoCommand command)
        {
            var oreder = moqRepo.getOrder(command.Id);
            oreder.AddCoffeToGoOrder(command.CoffeToGo);
        }

        private object HandleCommand(AddCoffeToDrinkCommand command)
        {
            throw new NotImplementedException();
        }

        private async Task HandleCreate(CreateOrderCommand cmd)
        {
            var classifiedAd = new Order(
                cmd.Id,
                cmd.IsOpen
            );
        }
    }
}
