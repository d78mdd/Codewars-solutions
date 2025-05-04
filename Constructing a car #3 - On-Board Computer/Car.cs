using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructing_a_car__3___On_Board_Computer
{
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

            onBoardComputer = new OnBoardComputer(drivingProcessor, engine);

            onBoardComputerDisplay = new OnBoardComputerDisplay(onBoardComputer);
        }

        public Car(double fuelLevel)
        {
            fuelTank = new FuelTank();
            fuelTank.Refuel(fuelLevel);

            engine = new Engine(fuelTank);

            fuelTankDisplay = new FuelTankDisplay(fuelTank);

            drivingProcessor = new DrivingProcessor();

            drivingInformationDisplay = new DrivingInformationDisplay(drivingProcessor);

            onBoardComputer = new OnBoardComputer(drivingProcessor, engine);

            onBoardComputerDisplay = new OnBoardComputerDisplay(onBoardComputer);
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

            onBoardComputer = new OnBoardComputer(drivingProcessor, engine);

            onBoardComputerDisplay = new OnBoardComputerDisplay(onBoardComputer);
        }

        public bool EngineIsRunning
        {
            get { return engine.IsRunning; }
        }

        // Every call of a method (except Refuel) from the car correlates to 1 second

        public void EngineStart()
        {
            engine.Start();

            onBoardComputer.ElapseSecond();
        }

        public void EngineStop()
        {
            engine.Stop();

            onBoardComputer.ElapseSecond();
        }

        public void Refuel(double liters)
        {
            fuelTank.Refuel(liters);
        }

        public void RunningIdle()
        {
            engine.Consume(0.0003d);
            drivingProcessor.IncreaseSpeedTo(0);
            onBoardComputer.ElapseSecond();
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

            onBoardComputer.ElapseSecond();

        }

        public void FreeWheel() // "When the car brakes or freewheels with getting slower, there is no fuel consumption"
        {
            if (drivingProcessor.ActualSpeed == 0)
            {
                RunningIdle();
            }
            else
            {
                drivingProcessor.ReduceSpeed(1);
                onBoardComputer.ElapseSecond();
                onBoardComputer.SetActualConsumptionByTime0();
                onBoardComputer.SetActualConsumptionByDistance0();
            }
        }

        public void BrakeBy(int targetAmount) // "When the car brakes or freewheels with getting slower, there is no fuel consumption"
        {  // unless it comes down to 0 and does RunningIdle
            int newAmount = 10;

            if (newAmount > targetAmount)
            {
                newAmount = targetAmount;
            }

            drivingProcessor.ReduceSpeed(newAmount);

            if (drivingProcessor.ActualSpeed == 0)
            {
                RunningIdle();
            }
            else
            {
                onBoardComputer.ElapseSecond();
            }
        }
    }
}
