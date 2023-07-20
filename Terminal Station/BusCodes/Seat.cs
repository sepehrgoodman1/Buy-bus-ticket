using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_Station.BusCodes
{
    public class Seat
    {
        public bool Reserved { get; set; }
        public int SeatNumber { get; set; }
        public Seat(int seatNumber, bool reserved= false)
        {
            SeatNumber = seatNumber;
            Reserved = reserved;
        }
    }
}
