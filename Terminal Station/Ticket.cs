using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_Station.TripClasses;

namespace Terminal_Station
{
    internal class Ticket
    {
        public Trip Trip { get; set; }
        public int NumberSeat { get; set; }
        public Ticket(Trip trip, int numberSeat)
        {
            Trip = trip;
            SetSeat(numberSeat, trip);
        }
        void SetSeat(int numberSeat, Trip trip)
        {
            if (trip.bus.Seats[numberSeat].Reserved)
            {
                Console.WriteLine("This Seat Is Reserved Before! Please Choose Another Seat!");
            }
            else
            {
                trip.bus.Seats[numberSeat].Reserved = true;
            }
        }
        

    }
}
