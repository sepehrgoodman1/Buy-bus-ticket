using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal_Station.BusCodes;

namespace Terminal_Station.TripClasses
{
    internal class Trip
    {
        public string source { get; set; }
        public string Destination { get; set; }
        public double Price { get; set; }

        public Bus bus { get; set; }
       

        public Trip(string source, string destination, double basePrice , Bus bus)
        {
            this.source = source;

            Destination = destination;

            this.bus = bus;

            Price = CalculatePrice(bus, basePrice);

        }

       

        double CalculatePrice(Bus bus, double basePrice)
        {
            if (bus.Type == "Vip")
            {
                return basePrice * 1.4;
            }
            else
            {
                return basePrice;
            }
        }
        


    }
}
