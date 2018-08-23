using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark
{
    class Barrier
    {
        //ATTRIBUTES
        private bool lifted;

        //CONSTRUCTORS
        public Barrier()
        {
            lifted = false;
        }

        //FUNCTIONS
        public void Lower()
        {
            lifted = false;
        }
        public void Raise()
        {
            lifted = true;
        }
        public bool IsLifted()
        {
            return lifted;
        }
    }
}
