using System;
using System.Collections;

//Определяет зависимость типа «один ко многим» между объектами таким образом, 
//что при изменении состояния одного объекта все зависящие от него оповещаются об этом событии.

namespace DP_Behavioral_Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            //create new display and stock instances
            StockDisplay stockDisplay = new StockDisplay(); // IObserver
            Stock stock = new Stock(); //ObservableImpl

            //register the grid
            stock.Register(stockDisplay);

            //loop 100 times and modify the ask price
            for (int looper = 0; looper < 100; looper++)
            {
                if (looper == 34)
                {
                    stock.UnRegister(stockDisplay);
                }
                stock.AskPrice = looper;
            }

            //unregister the display
            //stock.UnRegister(stockDisplay);
        }
    }

    //interface the all observer classes should implement
    public interface IObserver // слушает 
    {
        void Notify(object anObject);
    }//IObserver

    //interface that all observable classes should implement
    public interface IObservable // посылает сообщения 
    {
        void Register(IObserver anObserver);
        void UnRegister(IObserver anObserver);
    }//IObservable

    //helper class that implements observable interface
    public class ObservableImpl : IObservable
    {
        //container to store the observer instance (is not synchronized for this example)
        protected Hashtable _observerContainer = new Hashtable();

        //add the observer
        public void Register(IObserver anObserver)
        {
            _observerContainer.Add(anObserver, anObserver);
        }//Register

        //remove the observer
        public void UnRegister(IObserver anObserver)
        {
            _observerContainer.Remove(anObserver);
        }//UnRegister

        //common method to notify all the observers
        public void NotifyObservers(object anObject)
        {
            //enumeration the observers and invoke their notify method
            foreach (IObserver anObserver in _observerContainer.Keys)
            {
                anObserver.Notify(anObject);
            }//foreach

        }//NotifyObservers
    }//ObservableImpl



    //represents a stock in an application
    public class Stock : ObservableImpl
    {
        //instance variable for ask price
        object _askPrice;

        //property for ask price
        public object AskPrice
        {
            set
            {
                _askPrice = value;
                base.NotifyObservers(_askPrice);
            }//set
        }//AskPrice property
    }//Stock

    //represents the user interface in the application
    public class StockDisplay : IObserver
    {
        public void Notify(object anObject)
        {
            Console.WriteLine("The new ask price is:" + anObject);
        }//Notify
    }//StockDisplay



}
