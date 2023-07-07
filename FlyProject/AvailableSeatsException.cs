using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyProject
{
    internal class AvailableSeatsException : ApplicationException
    {
        private string _Message;


        public AvailableSeatsException()
        {
            _Message = "No available seats for this flight.";
        }

        public override string Message { get { return _Message; } }
    }
}
