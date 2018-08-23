using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark
{
    class Bay
    {
        //ATTRIBUTES
        private int bayNumber;
        private BaySensor bSensor;
        private bool secured;
        private string password;

        //CONSTRUCTORS
        public Bay(int bayNumber)
        {
            bSensor = new BaySensor();
            bSensor.CarInBayBack();
            bSensor.CarInBayFront();
            bSensor.CarInBayLeft();
            bSensor.CarInBayRight();
            this.bayNumber = bayNumber;
            secured = false;
            password = "";
        }

        //FUNCTIONS
        public int GetBayNumber()
        {
            return bayNumber;
        }
        public string GetPassword()
        {
            return password;
        }
        public bool CarIsInBay()
        {
            if (bSensor.GetLeft() == true && bSensor.GetRight() == true && bSensor.GetBack() == true && bSensor.GetFront() == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SecureBay(string newPassword)
        {
            secured = true;
            password = newPassword;
        }
        public void UnlockBay()
        {
            secured = false;
            bSensor.TurnOffSensors();
        }
    }
}
