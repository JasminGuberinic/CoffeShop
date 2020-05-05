using Domain.Events;
using Framework;
using System;
using System.Collections.Generic;

namespace Domain
{
    public class Order : AggregateRoot<OrderId>
    {
        List<CoffeToDrink> CoffeToDrink { get; set; }

        List<CoffeAtHome> CoffeAtHome { get; set; }

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

        public void AddCoffeToGoOrder(CoffeAtHome coffeToGo)
        {
            Apply(new CoffeAtHomeOrdered(coffeToGo));
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
                case CoffeAtHomeOrdered e:
                    CoffeAtHome.Add(e.CoffeAtHome);
                    break;
                case KichenReceivedDrinkOrder e:
                    break;
                case ReceivedCoffeAtHomeOrder e:

                    break;
                case KichenDrinkOrderDone e:
                    break;
                case CoffeAtHomeDone e:

                    break;
            }
        }
    }
}
