// https://www.codewars.com/kata/578df8f3deaed98fcf0001e9

namespace Constructing_a_car__2___Driving
{
    //internal class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("Hello, World!");
    //    }
    //}


    public class Car : ICar
    {
        public IDrivingInformationDisplay drivingInformationDisplay; // car #2

        public IFuelTankDisplay fuelTankDisplay;

        private IDrivingProcessor drivingProcessor; // car #2

        private IEngine engine;

        private IFuelTank fuelTank;

        private int _maxAcceleration = 10;

        public Car()
        {
            fuelTank = new FuelTank();
            fuelTank.Refuel(20d);

            engine = new Engine(fuelTank);

            fuelTankDisplay = new FuelTankDisplay(fuelTank);

            drivingProcessor = new DrivingProcessor();

            drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);
        }

        public Car(double fuelLevel)
        {
            fuelTank = new FuelTank();
            fuelTank.Refuel(fuelLevel);

            engine = new Engine(fuelTank);

            fuelTankDisplay = new FuelTankDisplay(fuelTank);

            drivingProcessor = new DrivingProcessor();

            drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);
        }

        public Car(double fuelLevel, int maxAcceleration) // car #2
        {
            fuelTank = new FuelTank();
            fuelTank.Refuel(fuelLevel);

            engine = new Engine(fuelTank);

            fuelTankDisplay = new FuelTankDisplay(fuelTank);

            _maxAcceleration = maxAcceleration;

            drivingProcessor = new DrivingProcessor();

            drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);
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
            if (engine.IsRunning)
            {
                fuelTank.Consume(0.0003d);

                if (fuelTank.FillLevel == 0)
                {
                    EngineStop();
                }
            }
        }

        public void Accelerate(int targetSpeed)
        {
            int newSpeed = drivingProcessor.ActualSpeed + _maxAcceleration;

            if (newSpeed > targetSpeed)
            {
                newSpeed = targetSpeed;
            }

            drivingProcessor.IncreaseSpeedTo(newSpeed);

            fuelTank.Consume(0.0020);
        }

        public void FreeWheel()
        {
            drivingProcessor.ReduceSpeed(1);
        }

        public void BrakeBy(int targetAmount)
        {
            int newAmount = 10;

            if (newAmount > targetAmount)
            {
                newAmount = targetAmount;
            }

            drivingProcessor.ReduceSpeed(newAmount);
        }
    }

    public class DrivingInformationDisplay : IDrivingInformationDisplay // car #2
    {
        private IDrivingProcessor _drivingProcessor;

        public int ActualSpeed
        {
            get { return _drivingProcessor.ActualSpeed; }
        }

        public DrivingInformationDisplay(IDrivingProcessor drivingProcessor)
        {
            _drivingProcessor = drivingProcessor;
        }
    }

    public class DrivingProcessor : IDrivingProcessor // car #2
    {
        private int _actualSpeed;
        public int ActualSpeed {
            get { return _actualSpeed; }
        }

        public void IncreaseSpeedTo(int speed)
        {
            _actualSpeed = speed;
            if (_actualSpeed > 250)
            {
                _actualSpeed = 250;
            }
        }

        public void ReduceSpeed(int speed)
        {
            _actualSpeed -= speed;
            if (_actualSpeed < 0)
            {
                _actualSpeed = 0;
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
            _fuelTank = fuelTank;
        }

        public void Consume(double liters)
        {
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
            if (_fuelTank.FillLevel > 0)
            {
                _isRunning = true;
            }
        }

        public void Stop()
        {
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
            // Internally an accuracy up to 10 decimal places should be more than enough
            get { return Math.Round(_fillLevel, 10); }
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
                _fillLevel = 0d;
            }
        }

        public void Refuel(double liters)
        {
            _fillLevel += liters;
            if (_fillLevel > TankMaximumSize)
            {
                _fillLevel = TankMaximumSize;
            }

            if (_fillLevel < 0)
            {
                _fillLevel = 0;
            }
        }
    }

    public class FuelTankDisplay : IFuelTankDisplay
    {
        private IFuelTank _fuelTank;

        public double FillLevel
        {
            // The fuel tank display shows the level as rounded for 2 decimal places
            get { return Math.Round(_fuelTank.FillLevel, 2); }
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
