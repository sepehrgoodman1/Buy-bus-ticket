using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_Station.BusCodes
{
      abstract class Bus
    {
        
        public string  Name { get; set; }
        public string Type { get; set; }
        public int SeatsCount { get; set; }
        public List<Seat> Seats = new List<Seat>();

        public Bus(string name)
        {
            Name = name;
           /* Seats = new List<Seat>();*/
        }


    }
}
