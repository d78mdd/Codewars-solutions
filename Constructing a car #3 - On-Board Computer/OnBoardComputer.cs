using System;

namespace Constructing_a_car__3___On_Board_Computer;

public class OnBoardComputer : IOnBoardComputer // car #3
{
    // When the car is built, it should be assumed that the consumption was 4.8 Liter for the last 100 seconds
    private const double defaultConsumption = 4.8;
    private const int seconds = 100;


    private IDrivingProcessor _drivingProcessor;

    private IEngine _engine;

    private IFuelTank _fuelTank;

    public OnBoardComputer(IDrivingProcessor drivingProcessor, IEngine engine, IFuelTank fuelTank)
    {
        _drivingProcessor = drivingProcessor;
        _engine = engine;

        _fuelTank = fuelTank;

        for (int i = 0; i < seconds; i++)
        {
            last100SecondsConsumptions.Enqueue(defaultConsumption / seconds);
        }
    }

    private int _tripRealTime;
    public int TripRealTime
    {
        get { return _tripRealTime; }
    }

    private int _tripDrivingTime;
    public int TripDrivingTime
    {
        get { return _tripDrivingTime; }
    }

    // The driving-distance-values are calculated in km
    // should have at max 2 decimal places.
    private int _tripDrivenDistance;
    public int TripDrivenDistance
    {
        get { return _tripDrivenDistance; }
    }

    private int _totalRealTime;
    public int TotalRealTime
    {
        get
        {
            return _totalRealTime;
        }
    }

    private int _totalDrivingTime;
    public int TotalDrivingTime
    {
        get
        {
            return _totalDrivingTime;
        }
    }

    private int _totalDrivenDistance;
    public int TotalDrivenDistance
    {
        get
        {
            return _totalDrivenDistance;
        }
    }

    public double TripAverageSpeed
    {
        get
        {
            if (_tripDrivingTime == 0)
            {
                return 0; // NaN?
            }
            return _tripDrivenDistance / (_tripDrivingTime / 3600d);
        }
    }

    public double TotalAverageSpeed
    {
        get
        {
            if (_totalDrivingTime == 0)
            {
                return 0; // NaN?
            }
            return _totalDrivenDistance / (_totalDrivingTime / 3600d);
        }
    }

    public int ActualSpeed
    {
        get
        {
            return _drivingProcessor.ActualSpeed;
        }
    }

    private double _actualConsumptionByTime;
    public double ActualConsumptionByTime
    {
        get
        {
            return Math.Round(_actualConsumptionByTime, 5);
        }
    }

    private double _actualConsumptionByDistance;
    public double ActualConsumptionByDistance
    {
        get
        {
            if (ActualSpeed == 0)  // if (IsRunning == false)?
            {
                return Double.NaN;
            }
            return _actualConsumptionByDistance;
        }
    }

    public double TripAverageConsumptionByTime  // uses _tripRealTime
    {
        get
        {
            if (TotalDrivingTime == 0)
            {
                return 0;
            }
            return consumptionsTimeTrip.Average();
        }
    }

    public double TotalAverageConsumptionByTime  // uses _totalRealTime??
    {
        get
        {
            if (TotalDrivingTime == 0)
            {
                return 0;
            }
            return consumptionsTimeTotal.Average();
        }
    }

    public double TripAverageConsumptionByDistance  // consumption-average-by-distance-values 
        // are calculated in liter/100 km and should be rounded for 1 decimal place.
    {
        get
        {
            if (consumptionsDistTrip.Count == 0)
            {
                return 0;
            }
            else
            {
                return consumptionsDistTrip.Average();
            }
        }
    }

    public double TotalAverageConsumptionByDistance  // consumption-average-by-distance-values
        // are calculated in liter/100 km and should be rounded for 1 decimal place.
    {
        get
        {
            if (consumptionsDistTotal.Count == 0)
            {
                return 0;
            }
            else
            {
                return consumptionsDistTotal.Average();
            }
        }
    }

    // estimated distance
    // estimated remaining distance 
    public int EstimatedRange  // in km
    {
        get
        {
            double avgConsumptionPer1S = last100SecondsConsumptions.Average();

            double remainingDrivingTimeInSec = _fuelTank.FillLevel / avgConsumptionPer1S;

            double estimatedRangeInKm = ActualSpeed * (remainingDrivingTimeInSec / 3600);

            return (int)Math.Round(estimatedRangeInKm);
        }
    }

    private Queue<double> last100SecondsConsumptions = new Queue<double>();

    public void ElapseSecond()
    {
        // track time
        // it seems it needs to split somehow
        _tripRealTime++;  // used by TripAverageConsumptionByTime
        _totalRealTime++;  // used by TotalAverageConsumptionByTime
            
        if (ActualSpeed > 0)
        {
            _tripDrivingTime++;
            _totalDrivingTime++;
        }


        // track distance
        // distance = speed * time
        // at max 2 decimal places
        double currentDrivenDistance = this._drivingProcessor.ActualSpeed * (1 / 3600d);  // in km
        _tripDrivenDistance += (int)currentDrivenDistance;  // in km
        _totalDrivenDistance += (int)currentDrivenDistance;  // in km



        //if (ActualSpeed == 0)
        //{
        //    return;
        //}

        // track consumption
        double currentConsumption = _drivingProcessor.ActualConsumption;


        _actualConsumptionByTime = currentConsumption; // +=1 ? =consumption/totalDrivingTime?  +=consumption?

        consumptionsTimeTrip.Add(currentConsumption);
        consumptionsTimeTotal.Add(currentConsumption);

        last100SecondsConsumptions.Enqueue(currentConsumption);
        if (last100SecondsConsumptions.Count > 100)
        {
            last100SecondsConsumptions.Dequeue();
        }

        // l/km
        double currentConsumptionPerCurrentDistance = currentConsumption / currentDrivenDistance;

        // consumption for 100km according to current consumption // l/km
        _actualConsumptionByDistance = currentConsumptionPerCurrentDistance * 100;

        if (!double.IsNaN(_actualConsumptionByDistance) && !double.IsInfinity(_actualConsumptionByDistance))
        {
            consumptionsDistTrip.Add(_actualConsumptionByDistance);
            consumptionsDistTotal.Add(_actualConsumptionByDistance);
        }
    }

    private List<double> consumptionsTimeTrip = new List<double>();
    private List<double> consumptionsTimeTotal = new List<double>();

    private List<double> consumptionsDistTrip = new List<double>();
    private List<double> consumptionsDistTotal = new List<double>();


    public void TripReset()
    {
        _tripDrivingTime = 0;
        _tripRealTime = 0;

        consumptionsDistTrip.Clear();

        consumptionsTimeTrip.Clear();

        _tripDrivenDistance = 0;
    }

    public void TotalReset()
    {
        _totalDrivingTime = 0;
        _totalRealTime = 0;

        consumptionsDistTotal.Clear();

        consumptionsTimeTotal.Clear();

        _totalDrivenDistance = 0;
    }

    public void SetActualConsumptionByTime0()
    {
        _actualConsumptionByTime = 0;
    }

    public void SetActualConsumptionByDistance0()
    {
        _actualConsumptionByDistance = 0;
    }
}