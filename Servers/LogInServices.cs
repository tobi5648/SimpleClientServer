using Entities;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace Servers
{
    class LogInServices : TcpListener
    {
        private const int port = 8000;
        DatabaseHandler logIn;

        public LogInServices(int port = port) : base(IPAddress.Parse("127.0.0.1"), port)
        {
            try
            {
                this.Start();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ListenForLogins()
        {
            while (true)
            {
                // Code
                User loggedInUser;
                bool successfullLogin = logIn.CheckForUserWithPassword(loggedInUser);
            }
        }

        //public bool TryLogOn(User user)
        //{
        //    logIn = new DatabaseHandler();
        //    if (logIn.CheckForUserWithoutPassword(out user, user.Username))
        //        if (logIn.CheckForUserWithPassword(out user, user.Username, user.Password))
        //            return true;
        //    return false;
        //}
    }

    
}
