using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructing_a_car__3___On_Board_Computer
{
    public interface IDrivingProcessor // car #2
    {
        double ActualConsumption { get; } // car #3

        int ActualSpeed { get; }

        void EngineStart(); // car #3

        void EngineStop(); // car #3

        void IncreaseSpeedTo(int speed);

        void ReduceSpeed(int amount);
    }

}
