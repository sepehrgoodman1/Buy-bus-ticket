using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal_Station.BusCodes
{
    internal class VipBus :Bus
    {
        public VipBus(string name) : base(name)
        {
            SeatsCount = 25;
            Type = "Vip";

            for (int i = 0; i < SeatsCount; i++)
            {
                Seats.Add(new Seat(i));
            }
        }


    }
}
