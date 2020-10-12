using Domain.Events;
using Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Order : AggregateRoot<OrderId>
    {
        List<CoffeToDrinkOrder> CoffeToDrinkOrder { get; set; }

        List<CoffeCupcakeOrder> CoffeCupcakeOrder { get; set; }

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

        public Order(IEnumerable<object> domainevents)
        {
            Mutate(domainevents);
        }

        private void Mutate(IEnumerable<object> domainevents)
        {
            foreach (var devent in domainevents)
            {
                When(devent);
            }
        }

        public void AddCoffeCupcakeOrderOrder(CoffeCupcakeOrder coffeToGo)
        {
            Apply(new CoffeCupcakeOrderOrdered(coffeToGo));
        }

        public void AddCoffeToDrinkOrder(CoffeToDrinkOrder CoffeToDrinkOrder)
        {
            Apply(new CoffeToDrinkOrdered(CoffeToDrinkOrder));
        }

        public void SetStockReceivedCoffeCupcakeOrder(Guid id)
        {
            if(id == null)
                throw new Exception();
            Apply(new StockReceivedCoffeCupcakeOrderOrder(id));
        }

        public void KichenReceiveDrinkOrder(Guid id)
        {
            if (id == null)
                throw new Exception();
            Apply(new KichenReceivedDrinkOrder(id));
        }

        public void OrderToDrinkDone(Guid id)
        {
            if (id == null)
                throw new Exception();
            Apply(new DrinkOrderDone(id));
        }

        public void CoffeCupcakeOrderDone(Guid id)
        {
            if (id == null)
                throw new Exception();
            Apply(new CoffeCupcakeOrderDone(id));
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
                    CoffeToDrinkOrder.Add(e.CoffeToDrinkOrder);
                    break;
                case CoffeCupcakeOrderOrdered e:
                    CoffeCupcakeOrder.Add(e.CoffeCupcakeOrder);
                    break;
                case KichenReceivedDrinkOrder e:
                    CoffeToDrinkOrder.Where(cof => cof.Id.Value == e.Id).FirstOrDefault().AcquiringToDrinkCoffe = Entitys.AcquiringToDrinkCoffe.InKichen; ;
                    break;
                case StockReceivedCoffeCupcakeOrderOrder e:
                    CoffeCupcakeOrder.Where(cof => cof.Id.Value == e.Id).FirstOrDefault().AcquiringStateAtHomeCoffe = Entitys.AcquiringStateCoffeCupcake.OrderedFromStock;
                    break;
                case DrinkOrderDone e:
                    CoffeToDrinkOrder.Where(cof => cof.Id.Value == e.Id).FirstOrDefault().AcquiringToDrinkCoffe = Entitys.AcquiringToDrinkCoffe.Finished;
                    break;
                case CoffeCupcakeOrderDone e:
                    CoffeCupcakeOrder.Where(cof => cof.Id.Value == e.Id).FirstOrDefault().AcquiringStateAtHomeCoffe = Entitys.AcquiringStateCoffeCupcake.InStock;
                    break;
            }
        }

        protected override void EnsureValidState()
        {
            throw new NotImplementedException();
        }
    }
}
