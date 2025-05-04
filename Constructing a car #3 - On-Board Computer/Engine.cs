namespace Constructing_a_car__3___On_Board_Computer;

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