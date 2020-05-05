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

            if (command is AddCoffeAtHomeCommand)
            {
               HandleCommand((AddCoffeAtHomeCommand)command);
            }

            if (command is ReceiveCoffeAtHomeCommand)
            {
                _ = HandleCommand((ReceiveCoffeAtHomeCommand)command);
            }

            if (command is KichenReceiveDrinkOrderCommand)
            {
                _ = HandleCommand((KichenReceiveDrinkOrderCommand)command);
            }

            if (command is OrderToDrinkDoneCommand)
            {
                _ = HandleCommand((OrderToDrinkDoneCommand)command);
            }

            if (command is CoffeAtHomeOrderDoneCommand)
            {
                _ = HandleCommand((CoffeAtHomeOrderDoneCommand)command);
            }
        }

        private object HandleCommand(CoffeAtHomeOrderDoneCommand command)
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

        private object HandleCommand(ReceiveCoffeAtHomeCommand command)
        {
            throw new NotImplementedException();
        }

        private void HandleCommand(AddCoffeAtHomeCommand command)
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
