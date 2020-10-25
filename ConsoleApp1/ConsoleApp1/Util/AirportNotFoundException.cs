using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Util
{
    class AirportNotFoundException : Exception
    {
        public AirportNotFoundException() : base()
        {

        }

        public AirportNotFoundException(string message) : base(message)
        {

        }

        public AirportNotFoundException(string message, Exception exception) : base(message, exception)
        {

        }
    }
}
