namespace Constructing_a_car__3___On_Board_Computer;

public class OnBoardComputerDisplay : IOnBoardComputerDisplay // car #3
{
    private IOnBoardComputer _onBoardComputer;


    public int TripRealTime
    {
        get { return _onBoardComputer.TripRealTime; }
    }

    public int TripDrivingTime
    {
        get { return _onBoardComputer.TripDrivingTime; }
    }

    public double TripDrivenDistance
    {
        get { return Math.Round(_onBoardComputer.TripDrivenDistance, 2); }
    }

    public int TotalRealTime
    {
        get { return _onBoardComputer.TotalRealTime; }
    }

    public int TotalDrivingTime
    {
        get { return _onBoardComputer.TotalDrivingTime; }
    }

    public double TotalDrivenDistance
    {
        get { return Math.Round(_onBoardComputer.TotalDrivenDistance, 2); }
    }

    public int ActualSpeed
    {
        get { return _onBoardComputer.ActualSpeed; }
    }

    public double TripAverageSpeed
    {
        get { return Math.Round(_onBoardComputer.TripAverageSpeed, 2); }
    }

    public double TotalAverageSpeed
    {
        get { return Math.Round(_onBoardComputer.TotalAverageSpeed, 2); }
    }

    public double ActualConsumptionByTime
    {
        get { return Math.Round(_onBoardComputer.ActualConsumptionByTime, 5); }
    }

    public double ActualConsumptionByDistance
    {
        get { return Math.Round(_onBoardComputer.ActualConsumptionByDistance, 1); }
    }

    public double TripAverageConsumptionByTime
    {
        get { return Math.Round(_onBoardComputer.TripAverageConsumptionByTime, 5); }
    }

    public double TotalAverageConsumptionByTime
    {
        get { return Math.Round(_onBoardComputer.TotalAverageConsumptionByTime, 5); }
    }

    public double TripAverageConsumptionByDistance
    {
        get
        {
            return Math.Round(_onBoardComputer.TripAverageConsumptionByDistance, 1);
        }
    }

    public double TotalAverageConsumptionByDistance
    {
        get { return Math.Round(_onBoardComputer.TotalAverageConsumptionByDistance, 1); }
    }

    public int EstimatedRange
    {
        get { return _onBoardComputer.EstimatedRange; }
    }


    public OnBoardComputerDisplay(IOnBoardComputer onBoardComputer)
    {
        _onBoardComputer = onBoardComputer;
    }


    public void TripReset()
    {
        _onBoardComputer.TripReset();
    }

    public void TotalReset()
    {
        _onBoardComputer.TotalReset();
    }
}