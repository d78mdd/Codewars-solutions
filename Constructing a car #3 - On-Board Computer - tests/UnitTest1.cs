using Constructing_a_car__3___On_Board_Computer;

namespace Constructing_a_car__3___On_Board_Computer___tests;

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



    //[Test, Order(6)]
    //public void TestStartSpeed()
    //{
    //    var car = new Car();

    //    car.EngineStart();

    //    Assert.That(car.drivingInformationDisplay.ActualSpeed, Is.EqualTo(0), "Wrong actual speed!");
    //}

    //[Test, Order(7)]
    //public void TestFreeWheelSpeed()
    //{
    //    var car = new Car();

    //    car.EngineStart();

    //    Enumerable.Range(0, 10).ToList().ForEach(s => car.Accelerate(100));

    //    Assert.That(car.drivingInformationDisplay.ActualSpeed, Is.EqualTo(100), "Wrong actual speed!");

    //    car.FreeWheel();
    //    car.FreeWheel();
    //    car.FreeWheel();

    //    Assert.That(car.drivingInformationDisplay.ActualSpeed, Is.EqualTo(97), "Wrong actual speed!");
    //}

    //[Test, Order(8)]
    //public void TestAccelerateBy10()
    //{
    //    var car = new Car();

    //    car.EngineStart();

    //    Enumerable.Range(0, 10).ToList().ForEach(s => car.Accelerate(100));

    //    car.Accelerate(160);
    //    Assert.That(car.drivingInformationDisplay.ActualSpeed, Is.EqualTo(110), "Wrong actual speed!");
    //    car.Accelerate(160);
    //    Assert.That(car.drivingInformationDisplay.ActualSpeed, Is.EqualTo(120), "Wrong actual speed!");
    //    car.Accelerate(160);
    //    Assert.That(car.drivingInformationDisplay.ActualSpeed, Is.EqualTo(130), "Wrong actual speed!");
    //    car.Accelerate(160);
    //    Assert.That(car.drivingInformationDisplay.ActualSpeed, Is.EqualTo(140), "Wrong actual speed!");
    //    car.Accelerate(145);
    //    Assert.That(car.drivingInformationDisplay.ActualSpeed, Is.EqualTo(145), "Wrong actual speed!");
    //}

    //[Test, Order(9)]
    //public void TestBraking()
    //{
    //    var car = new Car();

    //    car.EngineStart();

    //    Enumerable.Range(0, 10).ToList().ForEach(s => car.Accelerate(100));

    //    car.BrakeBy(20);

    //    Assert.That(car.drivingInformationDisplay.ActualSpeed, Is.EqualTo(90), "Wrong actual speed!");

    //    car.BrakeBy(10);

    //    Assert.That(car.drivingInformationDisplay.ActualSpeed, Is.EqualTo(80), "Wrong actual speed!");
    //}

    //[Test, Order(10)]
    //public void TestConsumptionSpeedUpTo30()
    //{
    //    var car = new Car(1, 20);

    //    car.EngineStart();

    //    car.Accelerate(30);
    //    car.Accelerate(30);
    //    car.Accelerate(30);
    //    car.Accelerate(30);
    //    car.Accelerate(30);
    //    car.Accelerate(30);
    //    car.Accelerate(30);
    //    car.Accelerate(30);
    //    car.Accelerate(30);
    //    car.Accelerate(30);

    //    Assert.That(car.fuelTankDisplay.FillLevel, Is.EqualTo(0.98), "Wrong fuel tank fill level!");
    //}

    //[Test]
    //public void TestAccelerateLowerThanActualSpeed()
    //{
    //    var car = new Car(50, 20);

    //    car.EngineStart();

    //    car.Accelerate(10);
    //    car.Accelerate(5);

    //    Assert.That(car.drivingInformationDisplay.ActualSpeed, Is.EqualTo(10));
    //}

    //[Test]
    //public void TestConsumptionLeadsToStopEngine()
    //{
    //    var car = new Car(50, 20);

    //    car.EngineStart();

    //    car.Accelerate(10);
    //    car.Accelerate(5);

    //    Assert.That(car.EngineIsRunning, Is.False);
    //}






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

        // distance = speed * time



        // speed = time /* distance
        // km/h = km / h 
        // speed = distance / time

        // TripAverageSpeed = TripDrivenDistance / (TripDrivingTime / 3600) ?

        // km/h = km / 3600s

        // 18 = 6 * 3?  = x / 6?

        Assert.That(car.onBoardComputerDisplay.TripAverageSpeed, Is.EqualTo(18), "Wrong Trip-Average-Speed.");
        Assert.That(car.onBoardComputerDisplay.TotalAverageSpeed, Is.EqualTo(18), "Wrong Total-Average-Speed.");

        //average speeds are not actually average but the speeds for the last 100km?
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






    [Test]
    public void TestEstimatedRangeBeforeDriving()
    {
        var car = new Car();

        Assert.That(car.onBoardComputerDisplay.EstimatedRange, Is.EqualTo(417), "Wrong Estimated-Range.");
    }

    [Test]
    public void TestEstimatedRangeAfterDrivingSlowSpeedForLowerThan100Seconds()
    {
        var car = new Car();

        car.EngineStart();

        Enumerable.Range(0, 50).ToList().ForEach(c => car.Accelerate(30));

        Assert.That(car.onBoardComputerDisplay.EstimatedRange, Is.EqualTo(133), "Wrong Estimated-Range.");
    }

    [Test]
    public void TestAverageConsumptionsAfterAcceleratingAndReset()
    {
        var car = new Car();

        car.EngineStart();

        car.Accelerate(30);
        car.Accelerate(30);
        car.Accelerate(30);

        car.onBoardComputerDisplay.TripReset();

        car.Accelerate(30);
        car.Accelerate(30);
        car.Accelerate(30);

        car.onBoardComputerDisplay.TotalReset();

        Assert.That(car.onBoardComputerDisplay.TripAverageConsumptionByTime, Is.EqualTo(0.002));
    }

    [Test]
    public void TestActualConsumptionEngineStopAfterDriving()
    {
        var car = new Car();

        car.EngineStart();

        car.Accelerate(10);
        car.BrakeBy(10);
        car.EngineStop();

        Assert.That(car.onBoardComputerDisplay.ActualConsumptionByTime, Is.EqualTo(0));
    }
}
