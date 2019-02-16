using System;
using System.Collections.Generic;

// IHandler , Handler , Manager

namespace DP_Behavioral_ChainofResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
         var manager = new OrderManager(new DefaultOrderHandler());

            manager.AddHandler(new FavCustomerOrderHandler());
            manager.AddHandler(new LargeOrderHandler());

            OrderData orderData = new OrderData() {
                Id = 0,
                Amount = 10,
                CustomerId = 15,
                ItemId = 8
            };

            manager.ProcessNewOrder(orderData);
        }
    }

    public class OrderData
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int Amount { get; set; }
        public int CustomerId { get; set; }
    }

    public interface IOrderHandler
    {
        bool Process(OrderData orderData);
    }

    public class OrderManager
    {
        private List<IOrderHandler> _handlers = new List<IOrderHandler>();
        private IOrderHandler _defaultHandler;

        public OrderManager(IOrderHandler defaultHandler)
        {
            if (defaultHandler == null) { throw new NullReferenceException(); }

            this._defaultHandler = defaultHandler;
        }

        public void AddHandler(IOrderHandler handler)
        {
            this._handlers.Add(handler);
        }

        public void ProcessNewOrder(OrderData orderData)
        {
            foreach (IOrderHandler handler in this._handlers)
            {
                if (handler.Process(orderData))
                {
                    return;
                }
            }

            if (!this._defaultHandler.Process(orderData))
            {
                throw new InvalidOperationException();
            }
        }
    }

    public class DefaultOrderHandler : IOrderHandler
    {
        public bool Process(OrderData orderData)
        {
            if (orderData.Id != 0) { return false; }

            Console.WriteLine("Default order handler");
            orderData.Id = 5;

            return true;
        }
    }

    public class LargeOrderHandler : IOrderHandler
    {
        public bool Process(OrderData orderData)
        {
            if ((orderData.Id != 0) || (orderData.Amount < 20))
            {
                return false;
            }

            Console.WriteLine("Large order handler.");
            orderData.Id = 42;

            return true;
        }
    }

    public class FavCustomerOrderHandler : IOrderHandler
    {
        public bool Process(OrderData orderData)
        {
            if ((orderData.Id != 0) || (orderData.CustomerId > 10))
            {
                return false;
            }

            Console.WriteLine("Favorite customer order handler.");
            orderData.Id = 77;

            return true;
        }
    }
}
