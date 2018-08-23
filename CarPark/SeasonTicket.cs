using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark
{
    class SeasonTicket
    {
        private int id;

        public SeasonTicket(int ticketID)
        {
            id = ticketID;
        }

        public int GetID()
        {
            return id;
        }
    }
}
