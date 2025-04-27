// https://www.codewars.com/kata/578b4f9b7c77f535fc00002f/train/csharp

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
            fuelTank = new FuelTank();
            fuelTank.Refuel(20);

            engine = new Engine();

            fuelTankDisplay = new FuelTankDisplay(fuelTank);
        }

        public Car(double fuelLevel)
        {
            fuelTank = new FuelTank();
            fuelTank.Refuel(fuelLevel);

            engine = new Engine();

            fuelTankDisplay = new FuelTankDisplay(fuelTank);
        }

        public bool EngineIsRunning
        {
            get { return engine.IsRunning; }
        }

        public void EngineStart()
        {
            engine.Start();
        }

        public void EngineStop()
        {
            engine.Stop();
        }

        public void Refuel(double liters)
        {
            fuelTank.Refuel(liters);
        }

        public void RunningIdle()
        {
            throw new NotImplementedException();
        }
    }

    public class Engine : IEngine
    {
        private bool _isRunning;
        public bool IsRunning
        {
            get { return _isRunning; }
        }

        public void Consume(double liters)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            _isRunning = true;
        }

        public void Stop()
        {
            _isRunning = false;
        }
    }

    public class FuelTank : IFuelTank
    {
        public const double TankMaximumSize = 60;
        public const double TankReserveLevel = 5;

        private double _fillLevel;
        public double FillLevel
        {
            get { return _fillLevel; }
        }

        public bool IsOnReserve
        {
            get { return _fillLevel <= TankReserveLevel; }
        }

        public bool IsComplete
        {
            get { return _fillLevel == TankMaximumSize; }
        }

        public void Consume(double liters)
        {
            _fillLevel -= liters;
            if (_fillLevel < 0)
            {
                _fillLevel = 0;
            }
        }

        public void Refuel(double liters)
        {
            _fillLevel += liters;
            if (_fillLevel > TankMaximumSize)
            {
                _fillLevel = TankMaximumSize;
            }
        }
    }

    public class FuelTankDisplay : IFuelTankDisplay
    {
        private IFuelTank _fuelTank;

        public double FillLevel
        {
            get { return _fuelTank.FillLevel; }
        }

        public bool IsOnReserve
        {
            get { return _fuelTank.IsOnReserve; }
        }

        public bool IsComplete
        {
            get { return _fuelTank.IsComplete; }
        }

        public FuelTankDisplay(IFuelTank fuelTank)
        {
            _fuelTank = fuelTank;
        }

    }

}
