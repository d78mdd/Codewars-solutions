using System.Diagnostics.Metrics;

namespace Constructing_a_car__3___On_Board_Computer;

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
        Console.WriteLine("EngineStart");

        _engineIsRunning = true;
    }

    public void EngineStop()
    {
        Console.WriteLine("EngineStop");

        _engineIsRunning = false;
    }

    private int _counter = 0;

    public void IncreaseSpeedTo(int speed)
    {
        _counter++;
        if (_counter < 100)
        {
            Console.WriteLine("IncreaseSpeedTo");
        }

        _actualSpeed = speed;
        if (_actualSpeed > 250)
        {
            _actualSpeed = 250;
        }

        // set actual consumption
        if (_actualSpeed == 0)
        {
            _actualConsumption = 0.0003d;
        }
        else if (_actualSpeed <= 60)
        {
            _actualConsumption = 0.0020d;
        }
        else if (_actualSpeed <= 100)
        {
            _actualConsumption = 0.0014d;
        }
        else if (_actualSpeed <= 140)
        {
            _actualConsumption = 0.0020d;
        }
        else if (_actualSpeed <= 200)
        {
            _actualConsumption = 0.0025d;
        }
        else  // speed <= 250)
        {
            _actualConsumption = 0.0030d;
        }
    }

    public void ReduceSpeed(int amount)
    {
        Console.WriteLine("ReduceSpeed");

        _actualSpeed -= amount;
        if (_actualSpeed < 0)
        {
            _actualSpeed = 0;
        }

        _actualConsumption = 0;
    }
}