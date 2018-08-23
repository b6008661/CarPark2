using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark
{
    class Sensor
    {
        protected bool carOnSensor;

        public bool IsCarOnSensor()
        {
            return carOnSensor;
        }
    }
}
