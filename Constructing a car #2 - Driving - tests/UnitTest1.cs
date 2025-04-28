using Constructing_a_car__2___Driving;

namespace Constructing_a_car__2___Driving___tests
{
    public class Tests
    {
        //[Test, Order(1)]
        //public void TestMotorStartAndStop()
        //{
        //    var car = new Car();

        //    Assert.That(car.EngineIsRunning, Is.False, "Engine could not be running.");

        //    car.EngineStart();

        //    Assert.That(car.EngineIsRunning, Is.True, "Engine should be running.");

        //    car.EngineStop();

        //    Assert.That(car.EngineIsRunning, Is.False, "Engine could not be running.");
        //}

        //[Test, Order(2)]
        //public void TestFuelConsumptionOnIdle()
        //{
        //    var car = new Car(1);

        //    car.EngineStart();

        //    Enumerable.Range(0, 3000).ToList().ForEach(s => car.RunningIdle());

        //    Assert.That(car.fuelTankDisplay.FillLevel, Is.EqualTo(0.10), "Wrong fuel tank fill level!");
        //}

        //[Test, Order(3)]
        //public void TestFuelTankDisplayIsComplete()
        //{
        //    var car = new Car(60);

        //    Assert.That(car.fuelTankDisplay.IsComplete, Is.True, "Fuel tank must be complete!");
        //}

        //[Test, Order(4)]
        //public void TestFuelTankDisplayIsOnReserve()
        //{
        //    var car = new Car(4);

        //    Assert.That(car.fuelTankDisplay.IsOnReserve, Is.True, "Fuel tank must be on reserve!");
        //}

        //[Test, Order(5)]
        //public void TestRefuel()
        //{
        //    var car = new Car(5);

        //    car.Refuel(40);

        //    Assert.That(car.fuelTankDisplay.FillLevel, Is.EqualTo(45), "Wrong fuel tank fill level!");
        //}



        [Test, Order(6)]
        public void TestStartSpeed()
        {
            var car = new Car();

            car.EngineStart();

            Assert.That(car.drivingInformationDisplay.ActualSpeed, Is.EqualTo(0), "Wrong actual speed!");
        }

        [Test, Order(7)]
        public void TestFreeWheelSpeed()
        {
            var car = new Car();

            car.EngineStart();

            Enumerable.Range(0, 10).ToList().ForEach(s => car.Accelerate(100));

            Assert.That(car.drivingInformationDisplay.ActualSpeed, Is.EqualTo(100), "Wrong actual speed!");

            car.FreeWheel();
            car.FreeWheel();
            car.FreeWheel();

            Assert.That(car.drivingInformationDisplay.ActualSpeed, Is.EqualTo(97), "Wrong actual speed!");
        }

        [Test, Order(8)]
        public void TestAccelerateBy10()
        {
            var car = new Car();

            car.EngineStart();

            Enumerable.Range(0, 10).ToList().ForEach(s => car.Accelerate(100));

            car.Accelerate(160);
            Assert.That(car.drivingInformationDisplay.ActualSpeed, Is.EqualTo(110), "Wrong actual speed!");
            car.Accelerate(160);
            Assert.That(car.drivingInformationDisplay.ActualSpeed, Is.EqualTo(120), "Wrong actual speed!");
            car.Accelerate(160);
            Assert.That(car.drivingInformationDisplay.ActualSpeed, Is.EqualTo(130), "Wrong actual speed!");
            car.Accelerate(160);
            Assert.That(car.drivingInformationDisplay.ActualSpeed, Is.EqualTo(140), "Wrong actual speed!");
            car.Accelerate(145);
            Assert.That(car.drivingInformationDisplay.ActualSpeed, Is.EqualTo(145), "Wrong actual speed!");
        }

        [Test, Order(9)]
        public void TestBraking()
        {
            var car = new Car();

            car.EngineStart();

            Enumerable.Range(0, 10).ToList().ForEach(s => car.Accelerate(100));

            car.BrakeBy(20);

            Assert.That(car.drivingInformationDisplay.ActualSpeed, Is.EqualTo(90), "Wrong actual speed!");

            car.BrakeBy(10);

            Assert.That(car.drivingInformationDisplay.ActualSpeed, Is.EqualTo(80), "Wrong actual speed!");
        }

        [Test, Order(10)]
        public void TestConsumptionSpeedUpTo30()
        {
            var car = new Car(1, 20);

            car.EngineStart();

            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);
            car.Accelerate(30);

            Assert.That(car.fuelTankDisplay.FillLevel, Is.EqualTo(0.98), "Wrong fuel tank fill level!");
        }


        [Test]
        public void TestAccelerateLowerThanActualSpeed()
        {
            var car = new Car(50, 20);

            car.EngineStart();

            car.Accelerate(10);
            car.Accelerate(5);

            Assert.That(car.drivingInformationDisplay.ActualSpeed, Is.EqualTo(10));
        }

        [Test]
        public void TestConsumptionLeadsToStopEngine()
        {
            var car = new Car(50, 20);

            car.EngineStart();

            car.Accelerate(10);
            car.Accelerate(5);

            Assert.That(car.EngineIsRunning, Is.False);
        }
    }
}