using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_Station.BusCodes
{
    internal class NormalBus : Bus
    {
        public NormalBus(string name) : base(name)
        {
            Type = "Normal";
            SeatsCount = 44;
            for (int i = 0; i < SeatsCount; i++)
            {
                Seats.Add(new Seat(i));
            }
        }

    }
}
