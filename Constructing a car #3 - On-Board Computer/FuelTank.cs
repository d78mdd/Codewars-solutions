using System.Diagnostics.Metrics;

namespace Constructing_a_car__3___On_Board_Computer;

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

    private int _counter = 0;

    public void Consume(double liters)
    { // what if liters is negative
        _counter++;
        if (_counter < 100)
        {
            Console.WriteLine("Consume");
        }

        _fillLevel -= liters;
        if (_fillLevel < 0)
        {
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

        if (_fillLevel < 0)
        {
            _fillLevel = 0;
        }
    }
}