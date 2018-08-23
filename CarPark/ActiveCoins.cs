using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark
{
    class ActiveCoins
    {
        //ATTRIBUTES
        private List<Coin> coins;

        //CONSTRUCTOR
        public ActiveCoins()
        {
            coins = new List<Coin>();
            coins.Add(new Coin(1));
            coins.Add(new Coin(2));
            coins.Add(new Coin(3));
            coins.Add(new Coin(4));
            coins.Add(new Coin(5));
            coins.Add(new Coin(6));
            coins.Add(new Coin(7));
            coins.Add(new Coin(8));
            coins.Add(new Coin(9));
            coins.Add(new Coin(10));
            coins.Add(new Coin(11));

        }

        //FUNCTIONS
        public void AddCoin(int number)
        {
            coins[number].SetActive();
        }
        /*public int GetCoinID(int coinID)
        {
            return
        }*/
        public void SetPaid(int number)
        {
            coins[number].SetPaid();
        }
        public bool HasPaid(int number)
        {
            if (coins[number].IsPaid())
            {
                return true;
            }
            return false;
        }
        public bool IsActive(int number)
        {
            if (coins[number].GetActive() == true)
            {
                return true;
            }
            return false;
        }
        public List<Coin> GetCoins()
        {
            return coins;
        }

        public void RemoveCoin(int coinCode)
        {
            //loop over each ticket in the collection tickets
            foreach (Coin coin in coins)
            {
                //when the customers ticket is found in the list....
                if (coinCode == coin.GetHashCode())
                {
                    //remove that ticket from the list
                    coins.Remove(coin);
                }
            }
        }
    }
}
