using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark
{
    class Entry
    {
        //ATTRIBUTES
        private ActiveCoins coins;
        private Barrier entryBarrier;
        private BarrierSensor entrySensor;
        Random r = new Random();

        public Entry(ActiveCoins coins)
        {
            this.coins = coins;
            entryBarrier = new Barrier();
            entrySensor = new BarrierSensor();
        }

        public int DispenseCoin()
        {
            int number = r.Next(1, 10);
            while (coins.IsActive(number))
            {
                number = r.Next(1, 10);
            }
            coins.AddCoin(number);
            return number;
        }

        public void RaiseEntryBarrier()
        {
            entryBarrier.Raise();
        }
        public void LowerEntryBarrier()
        {
            if (entrySensor.CarLeft())
            {
                entryBarrier.Lower();

            }
        }
        public string ResetWelcome()
        {
            return "Welcome, please press enter.";
        }
        public string ResetCoinID()
        {
            return "";
        }
        public string Disable()
        {
            return "Sorry, you cannot enter";
        }
    }
}
