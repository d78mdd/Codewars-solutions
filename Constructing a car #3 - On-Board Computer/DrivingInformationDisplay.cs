namespace Constructing_a_car__3___On_Board_Computer;

public class DrivingInformationDisplay : IDrivingInformationDisplay // car #2
{
    private IDrivingProcessor _drivingProcessor;

    public int ActualSpeed
    {
        get { return _drivingProcessor.ActualSpeed; }
    }

    public DrivingInformationDisplay(IDrivingProcessor drivingProcessor)
    {
        _drivingProcessor = drivingProcessor;
    }
}
