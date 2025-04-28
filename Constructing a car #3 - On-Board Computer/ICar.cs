using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructing_a_car__3___On_Board_Computer
{
    public interface ICar
    {
        bool EngineIsRunning { get; }

        void BrakeBy(int speed); // car #2

        void Accelerate(int speed); // car #2

        void EngineStart();

        void EngineStop();

        void FreeWheel(); // car #2

        void Refuel(double liters);

        void RunningIdle();
    }

}
