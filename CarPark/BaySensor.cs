using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark
{
    class BaySensor : Sensor
    {
        private bool left;
        private bool right;
        private bool back;
        private bool front;

        public bool CarDetected()
        {
            carOnSensor = true;
            return carOnSensor;

        }
        public void TurnOffSensors()
        {

        }
        public void TurnOnSensors()
        {

        }

        public bool GetLeft()
        {
            return left;
        }
        public bool GetRight()
        {
            return right;
        }
        public bool GetFront()
        {
            return front;
        }
        public bool GetBack()
        {
            return back;
        }
        public void CarInBayLeft()
        {
            //when button.left is pressed
            left = true;
        }
        public void CarInBayRight()
        {
            //when button.right is pressed
            right = true;
        }
        public void CarInBayFront()
        {
            //when button.front is pressed
            front = true;
        }
        public void CarInBayBack()
        {
            //when button.back is pressed
            back = true;
        }
        public string NotInLeft()
        {
            if (left == true)
            {
                return ("left");
            }

            return ("");
        }
        public string NotInRight()
        {
            if (right == true)
            {
                return ("right");
            }

            return ("");
        }
        public string NotInFront()
        {
            if (front == true)
            {
                return ("front");
            }

            return ("");
        }
        public string NotInBack()
        {
            if (back == true)
            {
                return ("back");
            }

            return ("");
        }
    }
}
