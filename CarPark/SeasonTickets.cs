using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark
{
    class SeasonTickets
    {
        private List<SeasonTicket> seasonTickets;

        public SeasonTickets()
        {
            seasonTickets = new List<SeasonTicket>();
        }

        public void AddTicket(int ticketID)
        {
            seasonTickets.Add(new SeasonTicket(ticketID));
        }
        public void RemoveTicket(int ticketID)
        {
            foreach (SeasonTicket ticket in seasonTickets)
            {
                //when the customers ticket is found in the list....
                if (ticketID == ticket.GetID())
                {
                    //remove that ticket from the list
                    seasonTickets.Remove(ticket);
                }
            }
        }
        public bool FindTicket(int ticketID)
        {
            bool active = false; ;
            foreach (SeasonTicket ticket in seasonTickets)
            {
                if (ticketID == ticket.GetID())
                {
                    active = true;
                }

            }
            return active;
        }

        public List<SeasonTicket> GetList()
        {
            return seasonTickets;
        }
    }
}
