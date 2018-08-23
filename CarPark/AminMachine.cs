using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark
{
    class AdminMachine
    {
        private string user;
        private string password;

        public AdminMachine()
        {
            user = "admin";
            password = "carpark";
        }

        public string GetUser()
        {
            return user;
        }
        public string GetPassword()
        {
            return password;
        }
    }
}
