using Application.Dto;
using Domain;
using System;
using System.Threading.Tasks;

namespace Application
{
    public class OrderCommandService
    {
        public async Task Handle(object command)
        {
            if (command is CreateOrder)
            {
                _ = HandleCreate((CreateOrder)command);
            }
                
        }

        private async Task HandleCreate(CreateOrder cmd)
        {
            var classifiedAd = new Order(
                cmd.Id,
                cmd.IsOpen
            );
        }
    }
}
