// https://www.codewars.com/kata/57961d4e4be9121ec90001bd/train/csharp

namespace Constructing_a_car__3___On_Board_Computer
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
        public IDrivingInformationDisplay drivingInformationDisplay; // car #2

        public IFuelTankDisplay fuelTankDisplay;

        public IOnBoardComputerDisplay onBoardComputerDisplay; // car #3

        private IDrivingProcessor drivingProcessor; // car #2

        private IEngine engine;

        private IFuelTank fuelTank;

        private IOnBoardComputer onBoardComputer; // car #3

        private int _maxAcceleration = 10;

        public Car()
        {
            fuelTank = new FuelTank();
            fuelTank.Refuel(20d);

            engine = new Engine(fuelTank);

            fuelTankDisplay = new FuelTankDisplay(fuelTank);

            drivingProcessor = new DrivingProcessor();

            drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);

            onBoardComputer = new OnBoardComputer();

            onBoardComputerDisplay = new OnBoardComputerDisplay();
        }

        public Car(double fuelLevel)
        {
            fuelTank = new FuelTank();
            fuelTank.Refuel(fuelLevel);

            engine = new Engine(fuelTank);

            fuelTankDisplay = new FuelTankDisplay(fuelTank);

            drivingProcessor = new DrivingProcessor();

            drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);

            onBoardComputer = new OnBoardComputer();

            onBoardComputerDisplay = new OnBoardComputerDisplay();
        }

        public Car(double fuelLevel, int maxAcceleration) // car #2
        {
            fuelTank = new FuelTank();
            fuelTank.Refuel(fuelLevel);

            engine = new Engine(fuelTank);

            fuelTankDisplay = new FuelTankDisplay(fuelTank);

            _maxAcceleration = maxAcceleration;
            if (_maxAcceleration > 20)
            {
                _maxAcceleration = 20;
            }

            if (_maxAcceleration < 5)
            {
                _maxAcceleration = 5;
            }

            drivingProcessor = new DrivingProcessor();

            drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);

            onBoardComputer = new OnBoardComputer();

            onBoardComputerDisplay = new OnBoardComputerDisplay();
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
            engine.Consume(0.0003d);
        }

        public void Accelerate(int targetSpeed)
        {
            if (!EngineIsRunning)
            {
                return;
            }

            if (targetSpeed < drivingProcessor.ActualSpeed)
            {
                FreeWheel();
            }
            else  // targetSpeed > drivingProcessor.ActualSpeed
            {
                int newSpeed = drivingProcessor.ActualSpeed + _maxAcceleration;

                if (newSpeed > targetSpeed)
                {
                    newSpeed = targetSpeed;
                }

                drivingProcessor.IncreaseSpeedTo(newSpeed);

                int speed = drivingProcessor.ActualSpeed;

                if (speed >= 1 && speed <= 60)
                {
                    engine.Consume(0.0020d);
                }
                else if (speed <= 100)
                {
                    engine.Consume(0.0014d);
                }
                else if (speed <= 140)
                {
                    engine.Consume(0.0020d);
                }
                else if (speed <= 200)
                {
                    engine.Consume(0.0025d);
                }
                else  // speed <= 250)
                {
                    engine.Consume(0.0030d);
                }
                if (fuelTank.FillLevel == 0)
                {
                    EngineStop();
                }

            }
        }

        public void FreeWheel() // When the car brakes or freewheels with getting slower, there is no fuel consumption
        {
            if (drivingProcessor.ActualSpeed == 0)
            {
                RunningIdle();
            }
            else
            {
                drivingProcessor.ReduceSpeed(1);
            }
        }

        public void BrakeBy(int targetAmount) // When the car brakes or freewheels with getting slower, there is no fuel consumption
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
        // The methods "EngineStart" and "EngineStop" of the DrivingProcessor do NOT start the engine, but give the event into the DrivingProcessor, that the engine has started or stopped
        private bool _engineIsRunning;  // used by what?

        private double _actualConsumption;
        public double ActualConsumption
        {
            get { return _actualConsumption; }
        }

        private int _actualSpeed;
        public int ActualSpeed
        {
            get { return _actualSpeed; }
        }

        public void EngineStart()
        {
            _engineIsRunning = true;
        }

        public void EngineStop()
        {
            _engineIsRunning = false;
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

    public class OnBoardComputer : IOnBoardComputer // car #3
    {
        public int TripRealTime { get; }

        public int TripDrivingTime { get; }

        public int TripDrivenDistance { get; }

        public int TotalRealTime { get; }

        public int TotalDrivingTime { get; }

        public int TotalDrivenDistance { get; }

        public double TripAverageSpeed { get; }

        public double TotalAverageSpeed { get; }

        public int ActualSpeed { get; }

        public double ActualConsumptionByTime { get; }

        public double ActualConsumptionByDistance { get; }

        public double TripAverageConsumptionByTime { get; }

        public double TotalAverageConsumptionByTime { get; }

        public double TripAverageConsumptionByDistance { get; }

        public double TotalAverageConsumptionByDistance { get; }

        public int EstimatedRange { get; }


        public void ElapseSecond()
        {
            throw new NotImplementedException();
        }

        public void TripReset()
        {
            throw new NotImplementedException();
        }

        public void TotalReset()
        {
            throw new NotImplementedException();
        }
    }

    public class OnBoardComputerDisplay : IOnBoardComputerDisplay // car #3
    {

        private int _tripRealTime;
        public int TripRealTime
        {
            get { return _tripRealTime; }
        }

        private int _tripDrivingTime;
        public int TripDrivingTime
        {
            get { return _tripDrivingTime; }
        }

        private double _tripDrivenDistance;
        public double TripDrivenDistance
        {
            get { return _tripDrivenDistance; }
        }

        private int _totalRealTime;
        public int TotalRealTime
        {
            get { return _totalRealTime; }
        }

        private int _totalDrivingTime;
        public int TotalDrivingTime
        {
            get { return _totalDrivingTime; }
        }

        private int _totalDrivenDistance;
        public double TotalDrivenDistance
        {
            get { return _totalDrivenDistance; }
        }

        private int _actualSpeed;
        public int ActualSpeed
        {
            get { return _actualSpeed; }
        }

        private double _tripAverageSpeed;
        public double TripAverageSpeed
        {
            get { return _tripAverageSpeed; }
        }

        private double _totalAverageSpeed;
        public double TotalAverageSpeed
        {
            get { return _totalAverageSpeed; }
        }

        private double _actualConsumptionByTime;
        public double ActualConsumptionByTime
        {
            get { return _actualConsumptionByTime; }
        }

        private double _actualConsumptionByDistance;
        public double ActualConsumptionByDistance
        {
            get { return _actualConsumptionByDistance; }
        }

        private double _tripAverageConsumptionByTime;
        public double TripAverageConsumptionByTime
        {
            get { return _tripAverageConsumptionByTime; }
        }

        private double _totalAverageConsumptionByTime;
        public double TotalAverageConsumptionByTime
        {
            get { return _totalAverageConsumptionByTime; }
        }

        private double _tripAverageConsumptionByDistance;
        public double TripAverageConsumptionByDistance
        {
            get { return _tripAverageConsumptionByDistance; }
        }

        private double _totalAverageConsumptionByDistance;
        public double TotalAverageConsumptionByDistance
        {
            get { return _totalAverageConsumptionByDistance; }
        }

        private int _estimatedRange;
        public int EstimatedRange
        {
            get { return _estimatedRange; }
        }


        public void TripReset()
        {
            throw new NotImplementedException();
        }

        public void TotalReset()
        {
            throw new NotImplementedException();
        }
    }
}
