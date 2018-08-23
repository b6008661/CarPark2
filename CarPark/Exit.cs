using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark
{
    class Exit
    {

        private ActiveCoins coins;
        private Barrier exitBarrier;
        private BarrierSensor exitSensor;

        public Exit(ActiveCoins coins)
        {
            this.coins = coins;
            exitBarrier = new Barrier();
            exitSensor = new BarrierSensor();
        }

        public void RaiseExitBarrier()
        {
            exitBarrier.Raise();
        }
        public void LowerExitBarrier()
        {
            if (exitSensor.CarLeft())
            {
                exitBarrier.Lower();

            }
        }
        public string Reset()
        {
            return "Insert your coin.";
        }
        public string Disable()
        {
            return "Sorry, you cannot exit. Please wait.";
        }
    }
}
