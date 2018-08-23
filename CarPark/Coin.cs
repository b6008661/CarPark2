using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark
{
    class Coin
    {
        //ATTRIBUTES
        private bool paid;
        private int id;
        private bool active;

        //CONSTRUCTORS
        public Coin(int id)
        {
            paid = false;
            active = false;
            this.id = id;
        }
        //FUNCTIONS
        public bool IsPaid()
        {
            return paid;
        }
        public void SetActive()
        {
            active = true;
        }
        public bool GetActive()
        {
            return active;
        }
        public void SetPaid()
        {
            paid = true;
        }
    }
}
