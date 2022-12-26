using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsPractices.Creational.Builder
{
    internal class MotorCycleBuilder : VehicleBuilder
    {
        public MotorCycleBuilder()
        {
            vehicle = new Vehicle("MotorCycle");
        }
        public override void BuildEngine()
        {
            vehicle["frame"] = "MotorCycle Frame";
        }

        public override void BuildFrame()
        {
            vehicle["engine"] = "500 CC";
        }

        public override void BuildOutDoors()
        {
            vehicle["wheels"] = "3";

        }

        public override void BuildWheels()
        {
            vehicle["doors"] = "0";

        }
    }
}
