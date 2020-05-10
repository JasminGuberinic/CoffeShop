using Domain.Events;
using Framework;
using infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure
{
    class OrderProjecor : ISubscriber
    {
        OrderReadModelRepository orderRepository;
        OrderProjecor()
        {
            orderRepository = new OrderReadModelRepository();
        }

        public Task Project(object @event)
        {
            switch (@event)
            {
                case OrderCreated e:
                    break;
                case CoffeToDrinkOrdered e:
                    break;
                case CoffeAtHomeOrdered e:
                    break;
                case KichenReceivedDrinkOrder e:
                    break;
                case StockReceivedCoffeAtHomeOrder e:
                    break;
                case DrinkOrderDone e:
                    break;
                case CoffeAtHomeDone e:
                    break;
                default: return null;
            }
            return null;
        }
    }
}
