﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Services
{
    public interface IGreeter {
        string GetGreeting();
    }

    public class Greeter : IGreeter
    {
        private string _greeting;

        public Greeter(IConfiguration conf)
        {
            _greeting = conf["greeting"];
        }
        public string GetGreeting()
        {
            return _greeting;
        }
    }
}
