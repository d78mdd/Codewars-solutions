using Constructing_a_car__1___Engine_and_Fuel_Tank;

namespace Constructing_a_car__1___Engine_and_Fuel_Tank___tests
{
    public class Tests
    {
        [Test, Order(1)]
        public void TestMotorStartAndStop()
        {
            var car = new Car();

            Assert.That(car.EngineIsRunning, Is.False, "Engine could not be running.");

            car.EngineStart();

            Assert.That(car.EngineIsRunning, Is.True, "Engine should be running.");

            car.EngineStop();

            Assert.That(car.EngineIsRunning, Is.False, "Engine could not be running.");
        }

        [Test, Order(2)]
        public void TestFuelConsumptionOnIdle()
        {
            var car = new Car(1);

            car.EngineStart();

            Enumerable.Range(0, 3000).ToList().ForEach(s => car.RunningIdle());

            Assert.That(car.fuelTankDisplay.FillLevel, Is.EqualTo(0.10), "Wrong fuel tank fill level!");
        }

        [Test, Order(3)]
        public void TestFuelTankDisplayIsComplete()
        {
            var car = new Car(60);

            Assert.That(car.fuelTankDisplay.IsComplete, Is.True, "Fuel tank must be complete!");
        }

        [Test, Order(4)]
        public void TestFuelTankDisplayIsOnReserve()
        {
            var car = new Car(4);

            Assert.That(car.fuelTankDisplay.IsOnReserve, Is.True, "Fuel tank must be on reserve!");
        }

        [Test, Order(5)]
        public void TestRefuel()
        {
            var car = new Car(5);

            car.Refuel(40);

            Assert.That(car.fuelTankDisplay.FillLevel, Is.EqualTo(45), "Wrong fuel tank fill level!");
        }
    }
}