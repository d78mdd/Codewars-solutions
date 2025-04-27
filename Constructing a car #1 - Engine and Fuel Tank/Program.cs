namespace Constructing_a_car__1___Engine_and_Fuel_Tank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class Car : ICar
    {
        public IFuelTankDisplay fuelTankDisplay;

        private IEngine engine;

        private IFuelTank fuelTank;

        public Car()
        {

        }

        public Car(double fuelLevel)
        {

        }

        public bool EngineIsRunning { get; }

        public void EngineStart()
        {
            throw new NotImplementedException();
        }

        public void EngineStop()
        {
            throw new NotImplementedException();
        }

        public void Refuel(double liters)
        {
            throw new NotImplementedException();
        }

        public void RunningIdle()
        {
            throw new NotImplementedException();
        }
    }

    public class Engine : IEngine
    {
        public bool IsRunning { get; }

        public void Consume(double liters)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }

    public class FuelTank : IFuelTank
    {
        public double FillLevel { get; }

        public bool IsOnReserve { get; }

        public bool IsComplete { get; }

        public void Consume(double liters)
        {
            throw new NotImplementedException();
        }

        public void Refuel(double liters)
        {
            throw new NotImplementedException();
        }
    }

    public class FuelTankDisplay : IFuelTankDisplay
    {
        public double FillLevel { get; }

        public bool IsOnReserve { get; }

        public bool IsComplete { get; }
    }

}
