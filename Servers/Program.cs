﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servers
{
    class Program
    {
        static void Main(string[] args)
        {
            LogInServices loginService = new LogInServices();
            loginService.ListenForLogins();
        }
    }
}
