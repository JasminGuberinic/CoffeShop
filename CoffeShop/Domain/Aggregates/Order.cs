using Domain.Events;
using Framework;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public Order(IEnumerable<DomainEvent> domainevents)
        {
            Mutate(domainevents);
        }

        private void Mutate(IEnumerable<DomainEvent> domainevents)
        {
            foreach (var devent in domainevents)
            {
                When(devent);
            }
        }

        public void AddCoffeAtHomeOrder(CoffeAtHome coffeToGo)
        {
            Apply(new CoffeAtHomeOrdered(coffeToGo));
        }

        public void AddCoffeToDrinkOrder(CoffeToDrink coffeToDrink)
        {
            Apply(new CoffeToDrinkOrdered(coffeToDrink));
        }

        public void SetStockReceivedCoffeAtHome(Guid id)
        {
            if(id == null)
                throw new Exception();
            Apply(new StockReceivedCoffeAtHomeOrder(id));
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

        public void CoffeAtHomeDone(Guid id)
        {
            if (id == null)
                throw new Exception();
            Apply(new CoffeAtHomeDone(id));
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
                    CoffeToDrink.Add(e.coffeToDrink);
                    break;
                case CoffeAtHomeOrdered e:
                    CoffeAtHome.Add(e.CoffeAtHome);
                    break;
                case KichenReceivedDrinkOrder e:
                    CoffeToDrink.Where(cof => cof.Id.Value == e.Id).FirstOrDefault().AcquiringToDrinkCoffe = Entitys.AcquiringToDrinkCoffe.InKichen; ;
                    break;
                case StockReceivedCoffeAtHomeOrder e:
                    CoffeAtHome.Where(cof => cof.Id.Value == e.Id).FirstOrDefault().AcquiringStateAtHomeCoffe = Entitys.AcquiringStateAtHomeCoffe.OrderedFromStock;
                    break;
                case DrinkOrderDone e:
                    CoffeToDrink.Where(cof => cof.Id.Value == e.Id).FirstOrDefault().AcquiringToDrinkCoffe = Entitys.AcquiringToDrinkCoffe.Finished;
                    break;
                case CoffeAtHomeDone e:
                    CoffeAtHome.Where(cof => cof.Id.Value == e.Id).FirstOrDefault().AcquiringStateAtHomeCoffe = Entitys.AcquiringStateAtHomeCoffe.InStock;
                    break;
            }
        }

        protected override void EnsureValidState()
        {
            throw new NotImplementedException();
        }
    }
}
