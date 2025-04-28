using Constructing_a_car__3___On_Board_Computer;

namespace Constructing_a_car__3___On_Board_Computer___tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void TestRealAndDrivingTimeBeforeStarting()
        {
            var car = new Car();

            Assert.That(car.onBoardComputerDisplay.TripRealTime, Is.EqualTo(0), "Wrong Trip-Real-Time!");
            Assert.That(car.onBoardComputerDisplay.TripDrivingTime, Is.EqualTo(0), "Wrong Trip-Driving-Time!");
            Assert.That(car.onBoardComputerDisplay.TotalRealTime, Is.EqualTo(0), "Wrong Total-Real-Time!");
            Assert.That(car.onBoardComputerDisplay.TotalDrivingTime, Is.EqualTo(0), "Wrong Total-Driving-Time!");
        }

        [Test]
        public void TestRealAndDrivingTimeAfterDriving()
        {
            var car = new Car();

            car.EngineStart();

            car.RunningIdle();
            car.RunningIdle();

            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);

            car.BrakeBy(10);
            car.BrakeBy(10);

            car.Accelerate(30);

            Assert.That(car.onBoardComputerDisplay.TripRealTime, Is.EqualTo(11), "Wrong Trip-Real-Time!");
            Assert.That(car.onBoardComputerDisplay.TripDrivingTime, Is.EqualTo(8), "Wrong Trip-Driving-Time!");
            Assert.That(car.onBoardComputerDisplay.TotalRealTime, Is.EqualTo(11), "Wrong Total-Real-Time!");
            Assert.That(car.onBoardComputerDisplay.TotalDrivingTime, Is.EqualTo(8), "Wrong Total-Driving-Time!");
        }

        [Test]
        public void TestActualSpeedBeforeDriving()
        {
            var car = new Car();

            car.EngineStart();

            car.RunningIdle();
            car.RunningIdle();

            Assert.That(car.onBoardComputerDisplay.ActualSpeed, Is.EqualTo(0), "Wrong actual speed.");
        }

        [Test]
        public void TestAverageSpeed1()
        {
            var car = new Car();

            car.EngineStart();

            car.RunningIdle();
            car.RunningIdle();

            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);

            car.BrakeBy(10);
            car.BrakeBy(10);
            car.BrakeBy(10);

            Assert.That(car.onBoardComputerDisplay.TripAverageSpeed, Is.EqualTo(18), "Wrong Trip-Average-Speed.");
            Assert.That(car.onBoardComputerDisplay.TotalAverageSpeed, Is.EqualTo(18), "Wrong Total-Average-Speed.");
        }

        [Test]
        public void TestAverageSpeedAfterTripReset()
        {
            var car = new Car();

            car.EngineStart();

            car.RunningIdle();
            car.RunningIdle();

            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);

            car.BrakeBy(10);
            car.BrakeBy(10);
            car.BrakeBy(10);

            car.onBoardComputerDisplay.TripReset();

            car.Accelerate(20);

            car.Accelerate(20);

            Assert.That(car.onBoardComputerDisplay.TripAverageSpeed, Is.EqualTo(15), "Wrong Trip-Average-Speed.");
            Assert.That(car.onBoardComputerDisplay.TotalAverageSpeed, Is.EqualTo(20), "Wrong Total-Average-Speed.");
        }

        [Test]
        public void TestActualConsumptionEngineStart()
        {
            var car = new Car();

            car.EngineStart();

            Assert.That(car.onBoardComputerDisplay.ActualConsumptionByTime, Is.EqualTo(0), "Wrong Actual-Consumption-By-Time");
            Assert.That(car.onBoardComputerDisplay.ActualConsumptionByDistance, Is.EqualTo(double.NaN), "Wrong Actual-Consumption-By-Distance");
        }

        [Test]
        public void TestActualConsumptionRunningIdle()
        {
            var car = new Car();

            car.EngineStart();

            car.RunningIdle();

            Assert.That(car.onBoardComputerDisplay.ActualConsumptionByTime, Is.EqualTo(0.0003), "Wrong Actual-Consumption-By-Time");
            Assert.That(car.onBoardComputerDisplay.ActualConsumptionByDistance, Is.EqualTo(double.NaN), "Wrong Actual-Consumption-By-Distance");
        }

        [Test]
        public void TestActualConsumptionAccelerateTo100()
        {
            var car = new Car(40, 20);

            car.EngineStart();

            car.Accelerate(100);
            car.Accelerate(100);
            car.Accelerate(100);
            car.Accelerate(100);
            car.Accelerate(100);

            Assert.That(car.onBoardComputerDisplay.ActualConsumptionByTime, Is.EqualTo(0.0014), "Wrong Actual-Consumption-By-Time");
            Assert.That(car.onBoardComputerDisplay.ActualConsumptionByDistance, Is.EqualTo(5), "Wrong Actual-Consumption-By-Distance");
        }

        [Test]
        public void TestActualConsumptionFreeWheel()
        {
            var car = new Car(40, 20);

            car.EngineStart();

            car.Accelerate(100);
            car.Accelerate(100);
            car.Accelerate(100);
            car.Accelerate(100);
            car.Accelerate(100);

            car.FreeWheel();

            Assert.That(car.onBoardComputerDisplay.ActualConsumptionByTime, Is.EqualTo(0), "Wrong Actual-Consumption-By-Time");
            Assert.That(car.onBoardComputerDisplay.ActualConsumptionByDistance, Is.EqualTo(0), "Wrong Actual-Consumption-By-Distance");
        }

        [Test]
        public void TestAverageConsumptionsAfterEngineStart()
        {
            var car = new Car();

            car.EngineStart();

            Assert.That(car.onBoardComputerDisplay.TripAverageConsumptionByTime, Is.EqualTo(0), "Wrong Trip-Average-Consumption-By-Time");
            Assert.That(car.onBoardComputerDisplay.TotalAverageConsumptionByTime, Is.EqualTo(0), "Wrong Total-Average-Consumption-By-Time");
            Assert.That(car.onBoardComputerDisplay.TripAverageConsumptionByDistance, Is.EqualTo(0), "Wrong Trip-Average-Consumption-By-Distance");
            Assert.That(car.onBoardComputerDisplay.TotalAverageConsumptionByDistance, Is.EqualTo(0), "Wrong Total-Average-Consumption-By-Distance");
        }

        [Test]
        public void TestAverageConsumptionsAfterAccelerating()
        {
            var car = new Car();

            car.EngineStart();

            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);

            Assert.That(car.onBoardComputerDisplay.TripAverageConsumptionByTime, Is.EqualTo(0.0015), "Wrong Trip-Average-Consumption-By-Time");
            Assert.That(car.onBoardComputerDisplay.TotalAverageConsumptionByTime, Is.EqualTo(0.0015), "Wrong Total-Average-Consumption-By-Time");
            Assert.That(car.onBoardComputerDisplay.TripAverageConsumptionByDistance, Is.EqualTo(44), "Wrong Trip-Average-Consumption-By-Distance");
            Assert.That(car.onBoardComputerDisplay.TotalAverageConsumptionByDistance, Is.EqualTo(44), "Wrong Total-Average-Consumption-By-Distance");
        }

        [Test]
        public void TestAverageConsumptionsAfterBraking()
        {
            var car = new Car();

            car.EngineStart();

            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);

            car.BrakeBy(10);
            car.BrakeBy(10);
            car.BrakeBy(10);

            Assert.That(car.onBoardComputerDisplay.TripAverageConsumptionByTime, Is.EqualTo(0.0009), "Wrong Trip-Average-Consumption-By-Time");
            Assert.That(car.onBoardComputerDisplay.TotalAverageConsumptionByTime, Is.EqualTo(0.0009), "Wrong Total-Average-Consumption-By-Time");
            Assert.That(car.onBoardComputerDisplay.TripAverageConsumptionByDistance, Is.EqualTo(26.4), "Wrong Trip-Average-Consumption-By-Distance");
            Assert.That(car.onBoardComputerDisplay.TotalAverageConsumptionByDistance, Is.EqualTo(26.4), "Wrong Total-Average-Consumption-By-Distance");
        }

        [Test]
        public void TestDrivenDistancesAfterEngineStart()
        {
            var car = new Car();

            car.EngineStart();

            Assert.That(car.onBoardComputerDisplay.TripDrivenDistance, Is.EqualTo(0), "Wrong Trip-Driven-Distance.");
            Assert.That(car.onBoardComputerDisplay.TotalDrivenDistance, Is.EqualTo(0), "Wrong Total-Driven-Distance.");
        }

        [Test]
        public void TestDrivenDistancesAfterAccelerating()
        {
            var car = new Car();

            car.EngineStart();

            Enumerable.Range(0, 30).ToList().ForEach(c => car.Accelerate(30));

            Assert.That(car.onBoardComputerDisplay.TripDrivenDistance, Is.EqualTo(0.24), "Wrong Trip-Driven-Distance.");
            Assert.That(car.onBoardComputerDisplay.TotalDrivenDistance, Is.EqualTo(0.24), "Wrong Total-Driven-Distance.");
        }

        [Test]
        public void TestEstimatedRangeAfterDrivingOptimumSpeedForMoreThan100Seconds()
        {
            var car = new Car();

            car.EngineStart();

            Enumerable.Range(0, 150).ToList().ForEach(c => car.Accelerate(100));

            Assert.That(car.onBoardComputerDisplay.EstimatedRange, Is.EqualTo(393), "Wrong Estimated-Range.");
        }

    }
}