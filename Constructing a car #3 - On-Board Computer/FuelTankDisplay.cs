namespace Constructing_a_car__3___On_Board_Computer;

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
        Console.WriteLine("FuelTankDisplay(IFuelTank fuelTank)");

        _fuelTank = fuelTank;
    }

}