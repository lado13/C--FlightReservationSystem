using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyProject
{
    internal class Flight
    {
        public string FlightNumber { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public int AvailableSeats { get; set; }

        

        public override string ToString()
        {
            return $"Flight Number: {FlightNumber} Departure City: {DepartureCity} " +
                   $"Arrival City: {ArrivalCity} Departure Time: {DepartureTime.ToShortDateString()} " +
                   $"Available Seats: {AvailableSeats}";

        }
    }
}
