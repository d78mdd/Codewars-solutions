using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructing_a_car__3___On_Board_Computer
{
    public interface IOnBoardComputer // car #3
    {
        int TripRealTime { get; }

        int TripDrivingTime { get; }

        // The driving-distance-values are calculated in km
        // should have at max 2 decimal places.
        int TripDrivenDistance { get; }

        int TotalRealTime { get; }

        int TotalDrivingTime { get; }

        int TotalDrivenDistance { get; }

        double TripAverageSpeed { get; }

        double TotalAverageSpeed { get; }

        int ActualSpeed { get; }

        double ActualConsumptionByTime { get; }

        double ActualConsumptionByDistance { get; }

        double TripAverageConsumptionByTime { get; }

        double TotalAverageConsumptionByTime { get; }

        double TripAverageConsumptionByDistance { get; }

        double TotalAverageConsumptionByDistance { get; }

        int EstimatedRange { get; }

        void ElapseSecond();

        void TripReset();

        void TotalReset();
    }
}
