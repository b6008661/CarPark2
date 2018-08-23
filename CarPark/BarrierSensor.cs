using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark
{
    class BarrierSensor : Sensor
    {

        public bool CarDetected()
        {
            carOnSensor = true;
            return carOnSensor;
        }

        public bool CarLeft()
        {
            if (carOnSensor == false)
            {
                return true;
            }
            return carOnSensor;
        }
    }
}
