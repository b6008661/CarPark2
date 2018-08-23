using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark
{
    class PayMachine
    {
        private ActiveCoins coins;
        private int hours;
        private int amount;

        public PayMachine(ActiveCoins coins)
        {
            amount = 2;
            hours = 2;
            this.coins = coins;
        }
        public void SetPrice(int newAmount)
        {
            amount = newAmount;
        }
        public int GetAmount()
        {
            return amount;
        }
        public int CalculateAmountToPay()
        {
            return hours * amount;
        }

        public void Pay(int number)
        {
            coins.SetPaid(number);
        }
    }
}
