using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark
{
    class PedDoor
    {
        private bool open;


        public void Open()
        {
            open = true;
        }
        public void Close()
        {
            open = false;
        }
    }
}
