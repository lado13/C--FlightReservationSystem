using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Services;
using System.Text;
using System.Threading.Tasks;

namespace FlyProject
{
    internal class FlightReservationSystem 
    {
        private List<Flight> Flights { get; set; }
        private List<Reservation> Reservations { get; set; }


        public FlightReservationSystem()
        {
            Flights = new List<Flight>();

            FillFlight();
            Reservations = new List<Reservation>();      
        }

        private void FillFlight()
        {
            Flights = new List<Flight>()
            {
                new Flight()
                {
                    DepartureCity = "TBS",
                    ArrivalCity = "DXB",
                    FlightNumber = "WQ 2099",
                    AvailableSeats = 13,
                    DepartureTime = new System.DateTime(2023,6,24)
                },
                new Flight()
                {
                    DepartureCity = "TBS",
                    ArrivalCity = "JED",
                    FlightNumber = "WP 2099",
                    AvailableSeats = 80,
                    DepartureTime = new System.DateTime(2023,6,24)
                },
                new Flight()
                {
                    DepartureCity = "TBS",
                    ArrivalCity = "AMB",
                    FlightNumber = "DK 1550",
                    AvailableSeats = 12,
                    DepartureTime = new System.DateTime(2023,6,24)
                },
                new Flight()
                {
                    DepartureCity = "TBS",
                    ArrivalCity = "DXB",
                    FlightNumber = "JK 2077",
                    AvailableSeats = 80,
                    DepartureTime = new System.DateTime(2023,6,28)
                },
            };
        }

        public void PrintFlightList()
        {
            Console.WriteLine("-------------------");
            foreach (Flight flight in Flights)
            {
                Console.WriteLine(flight);
            }
            Console.WriteLine("-------------------");

        }

        public void PrintReservationList()
        {
            Console.WriteLine("-------------------");
            foreach (Reservation reservation in Reservations)
            {
                Console.WriteLine(reservation);
            }
            Console.WriteLine("-------------------");
           
        }


        public List<Flight> SearchFlights(string departureCity, string arrivalCity)
        {
            List<Flight> flights = new List<Flight>();


            foreach (Flight item in Flights)
            {
                if (item.DepartureCity == departureCity && item.ArrivalCity == arrivalCity)
                {
                    flights.Add(item);
                }


            }
            PrintSearch(flights);
            return flights;
        }


        public void PrintSearch(List<Flight> flights)
        {
            foreach (var item in flights)
            {
                Console.WriteLine(item);
            }
        }












        public bool BookTicket(Flight flight, string passengerName)
         {
            
            if (flight.AvailableSeats > 0)
            {
                Reservations.Add(new Reservation()
                {
                    ReservationNumber = Guid.NewGuid().ToString(),
                    PassengerName = passengerName,
                    Flight = flight,
                });


                for (int i = 0; i < Flights.Count; i++)
                {
                    if (Flights[i].ToString() == flight.ToString())
                    {
                        Flights[i].AvailableSeats--;
                    }
                }

            }
            else
            {
               
                Console.WriteLine("No available seats for this flight.");    
            }

            return Reservations.Count > 0 ? true : false;   
         } 




        public bool CancelReservation(Reservation reservation)
        {
            for (int i = 0; i < Flights.Count; i++)
            {
                if (reservation.Flight.ToString() == Flights[i].ToString())
                {
                    Flights[i].AvailableSeats++;
                }
               
            }
            Console.WriteLine("Succesfuly removed reservation!!!");
            return Reservations.Remove(reservation);
        }

        public Flight GetFlight(string flightNumber)
        {
            Flight flight = null;

            foreach (var item in Flights)
            {
                if (item.FlightNumber == flightNumber)
                {
                    flight = item;
                    break;
                }
            }

            return flight;
        }

        public Reservation GetReservation(string reservationNumber)
        {
            Reservation reservation = null;

            foreach(var item in Reservations)
            {
                if (item.ReservationNumber == reservationNumber)
                {
                    reservation = item;
                    break;
                }
             

            }
            
            return reservation;
        }






        public static void Print()
        {
            Console.WriteLine("Flight Project");
            FlightReservationSystem flightReservationSystem = new FlightReservationSystem();
            Flight flight = new Flight();


            flightReservationSystem.Flights.Add(new Flight
            {
                FlightNumber = "12",
                DepartureCity = "Paris",
                ArrivalCity = "London",
                DepartureTime = new DateTime(2023, 6, 23, 9, 0, 0),
                AvailableSeats = 3,
               
                
            });






            while (true)
            {
               
                Console.WriteLine("Search(1)");
                Console.WriteLine("Book Ticket(2)");
                Console.WriteLine("Print Flight List(3)");
                Console.WriteLine("Print Reservation List(4)");
                Console.WriteLine("Cancel Reservation(5)");

                string chose = Console.ReadLine();
                

                if (chose == "1")
                {
                    Console.Write("Enter Departure City : ");
                    string departureCity = Console.ReadLine();
                    Console.Write("Enter Arrival City : ");
                    string arrivalCity = Console.ReadLine();
                    flightReservationSystem.SearchFlights(departureCity,arrivalCity);
                }
                else if (chose == "2")
                {
                    Console.Write("Flight number: ");
                    string fN = Console.ReadLine(); 

                    Console.Write("Enter name : ");                 
                    string passengerName = Console.ReadLine();

                    Console.WriteLine();
                    flightReservationSystem.BookTicket(flightReservationSystem.GetFlight(fN),passengerName);
                }
                else if (chose == "3")
                {
                    flightReservationSystem.PrintFlightList();
                }
                else if (chose == "4")
                {
                    if (flightReservationSystem.Reservations.Count == 0)
                    {
                        Console.WriteLine("Reservation list are empty feel it...");
                    }
                    else
                    {
                        flightReservationSystem.PrintReservationList();
                    }
                   
                }
                else if (chose == "5")
                {
                    Console.Write("Enter reservation number : ");
                    string reservationNumber = Console.ReadLine();  
                    flightReservationSystem.CancelReservation(flightReservationSystem.GetReservation(reservationNumber)); 
                }


            }
        }
    }
}
