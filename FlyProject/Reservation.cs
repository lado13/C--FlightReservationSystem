using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyProject
{
    internal class Reservation
    {
        public string ReservationNumber { get; set; }
        public string PassengerName { get; set; }
        public Flight Flight { get; set; }

        public override string ToString()
        {
            return $"Reservation Number {ReservationNumber} Passenger Name: {PassengerName} {Flight.ToString()}";
        }
    }
}
