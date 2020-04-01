using Domain.Events;
using Framework;
using System;
using System.Collections.Generic;

namespace Domain
{
    public class Order : AggregateRoot<OrderId>
    {
        List<CoffeToDrink> CoffeToDrink { get; set; }

        List<CoffeToGo> CoffeToGo { get; set; }

        bool IsOpen { get; set; }

        public Order(Guid id, bool isOpen)
        {
            Apply(
                new OrderCreated
                {
                    OrderId = id,
                    IsOpen = isOpen
                }
            );
        }

        public void AddCoffeToGoOrder(CoffeToGo coffeToGo)
        {
            Apply(new CoffeToGoOrdered(coffeToGo));
        }

        protected override void EnsureValidState()
        {
            throw new NotImplementedException();
        }

        protected override void When(object @event)
        {
            switch (@event)
            {
                case OrderCreated e:
                    Id = new OrderId(e.OrderId);
                    IsOpen = e.IsOpen;
                    break;
                case CoffeToDrinkOrdered e:
                    break;
                case CoffeToGoOrdered e:
                    CoffeToGo.Add(e.CoffeToGo);
                    break;
                case KichenReceivedDrinkOrder e:
                    break;
                case KichenReceivedToGoOrder e:

                    break;
                case KichenDrinkOrderDone e:
                    break;
                case KichenToGoOrderDone e:

                    break;
            }
        }
    }
}
