using System;

namespace DP_DependencyInjection
{
    /// <summary>
    /// http://en.wikipedia.org/wiki/Dependency_injection
    /// http://ru.wikipedia.org/wiki/Dependency_Injection
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            #region Using Higly coupled implementation

            Car bmw = new Car();
            bmw.SetAcceleration(20);
            Console.WriteLine(bmw.ToString());

            #endregion

            #region Using Manualy Injected

            DefaultCar BmwCar = new DefaultCar(new BmwEngine());
            DefaultCar AudiCar = new DefaultCar(new AudiEngine());

            BmwCar.SetAcceleration(10);
            AudiCar.SetAcceleration(10);

            Console.WriteLine(BmwCar.ToString());
            Console.WriteLine(AudiCar.ToString());

            #endregion

            Console.ReadLine();

        }
    }

    public interface IEngine
    {
        int GetEngineRPM();

        void SetFuelConsumption(int flow);
    }

    public interface ICar
    {
        int GetSpeed();

        void SetAcceleration(int value);
    }

    #region Highly coupled

    public class Engine : IEngine
    {
        private int rpm;

        public int GetEngineRPM()
        {
            return rpm;
        }

        public void SetFuelConsumption(int flow)
        {
            rpm = flow * 10;
        }
    }

    public class Car : ICar
    {

        private Engine engine = new Engine();

        public int GetSpeed()
        {
            return engine.GetEngineRPM() * 10;
        }

        public void SetAcceleration(int value)
        {
            engine.SetFuelConsumption(value + 10);
        }

        public override string ToString()
        {
            return "Car speed:" + GetSpeed();
        }
    }

    #endregion

    #region Manually Injected

    public class DefaultCar : ICar
    {
        private IEngine engine;

        public DefaultCar(IEngine concreteEngine)
        {
            engine = concreteEngine;
        }

        public int GetSpeed()
        {
            return engine.GetEngineRPM() * 10;
        }

        public void SetAcceleration(int value)
        {
            engine.SetFuelConsumption(value + 10);
        }

        public override string ToString()
        {
            return "Car speed:" + GetSpeed();
        }
    }

    public class BmwEngine : IEngine
    {
        private int rpm;

        public int GetEngineRPM()
        {
            return rpm;
        }

        public void SetFuelConsumption(int flow)
        {
            rpm = flow * 10;
        }
    }

    public class AudiEngine : IEngine
    {
        private int rpm;

        public int GetEngineRPM()
        {
            return rpm;
        }

        public void SetFuelConsumption(int flow)
        {
            rpm = flow * 5;
        }
    }

    public class CarFactory
    {
        public static DefaultCar BuildCar(IEngine concreteEngine)
        {
            return new DefaultCar(concreteEngine);
        }
    }

    #endregion


}
