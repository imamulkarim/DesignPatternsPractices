using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternsPractices.Creational.Builder
{
    internal class CarBuilder : VehicleBuilder
    {
        public CarBuilder()
        {
            vehicle = new Vehicle("Car");
        }
        public override void BuildEngine()
        {
            vehicle["frame"] = "Car Frame";
        }

        public override void BuildFrame()
        {
            vehicle["engine"] = "1500 CC";
        }

        public override void BuildOutDoors()
        {
            vehicle["wheels"] = "2";
        }

        public override void BuildWheels()
        {
            vehicle["doors"] = "3";

        }
    }
}
