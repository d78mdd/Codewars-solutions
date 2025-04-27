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
            Console.WriteLine("Car()");

            fuelTank = new FuelTank();
            fuelTank.Refuel(20d);

            engine = new Engine(fuelTank);

            fuelTankDisplay = new FuelTankDisplay(fuelTank);
        }

        public Car(double fuelLevel)
        {
            Console.WriteLine("Car(double fuelLevel)");

            fuelTank = new FuelTank();
            fuelTank.Refuel(fuelLevel);

            engine = new Engine(fuelTank);

            fuelTankDisplay = new FuelTankDisplay(fuelTank);
        }

        public bool EngineIsRunning
        {
            get
            {
                Console.WriteLine("EngineIsRunning");

                return engine.IsRunning;
            }
        }

        public void EngineStart()
        {
            Console.WriteLine("EngineStart");

            engine.Start();
        }

        public void EngineStop()
        {
            Console.WriteLine("EngineStop");

            engine.Stop();
        }

        public void Refuel(double liters)
        {
            Console.WriteLine("Refuel");

            fuelTank.Refuel(liters);
        }

        public void RunningIdle()
        {
            Console.WriteLine("RunningIdle");

            if (engine.IsRunning)
            {
                fuelTank.Consume(0.0003d);
            }
        }
    }

    public class Engine : IEngine
    {
        private bool _isRunning;
        public bool IsRunning
        {
            get { return _isRunning; }
        }

        private IFuelTank _fuelTank;

        public Engine(IFuelTank fuelTank)
        {
            Console.WriteLine("Engine(IFuelTank fuelTank)");

            _fuelTank = fuelTank;
        }

        public void Consume(double liters)
        {
            Console.WriteLine("consume");
            if (_isRunning)
            {
                _fuelTank.Consume(liters);

                if (_fuelTank.FillLevel == 0)
                {
                    Stop();
                }
            }

        }

        public void Start()
        {
            Console.WriteLine("start");

            if (_fuelTank.FillLevel > 0)
            {
                _isRunning = true;
            }
        }

        public void Stop()
        {
            Console.WriteLine("stop");

            _isRunning = false;
        }
    }

    public class FuelTank : IFuelTank
    {
        public const double TankMaximumSize = 60d;
        public const double TankReserveLevel = 5d;

        private double _fillLevel;
        public double FillLevel
        {
            get { return _fillLevel; }
        }

        public bool IsOnReserve
        {

            get
            {
                Console.WriteLine("IsOnReserve");

                return _fillLevel <= TankReserveLevel;
            }
        }

        public bool IsComplete
        {
            get
            {
                Console.WriteLine("IsComplete");

                return _fillLevel == TankMaximumSize;
            }
        }

        public void Consume(double liters)
        {
            Console.WriteLine("Consume");

            _fillLevel -= liters;
            if (_fillLevel < 0d)
            {
                Console.WriteLine(" going down to zero");
                _fillLevel = 0d;
            }
        }

        public void Refuel(double liters)
        {
            Console.WriteLine("Refuel");

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
            get
            {
                Console.WriteLine("FillLevel");
                return _fuelTank.FillLevel;
            }
        }

        public bool IsOnReserve
        {
            get
            {
                Console.WriteLine("IsOnReserve");

                return _fuelTank.IsOnReserve;
            }
        }

        public bool IsComplete
        {
            get
            {
                Console.WriteLine("IsComplete");

                return _fuelTank.IsComplete;
            }
        }

        public FuelTankDisplay(IFuelTank fuelTank)
        {
            Console.WriteLine("FuelTankDisplay(IFuelTank fuelTank)");

            _fuelTank = fuelTank;
        }

    }

}
