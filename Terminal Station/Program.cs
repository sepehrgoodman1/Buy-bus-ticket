
using ConsoleTables;
using Terminal_Station.BusCodes;
using Terminal_Station.TripClasses;

namespace Terminal_Station
{
    class Program
    {

        static void Main(string[] args)
        {
            

            List<NormalBus> normalBus = new List<NormalBus>();
            List<VipBus> vipBus = new List<VipBus>();

            List<Bus> buses = new List<Bus>();


            List<Trip> allTrips = new List<Trip>();
            List<Ticket> allTickets = new List<Ticket>();


            // Using Build Design Pattern

            RepeatConsoleMessage();


            void RepeatConsoleMessage()
            {
                Console.WriteLine("\n1)Define bus\n2)Define Trip\n3)Buy Ticket\n4)Calculate Trip Income\n5)Show Buses\n6)Show Trip Buses Seat And Income", Console.ForegroundColor = ConsoleColor.Green);
                int selectedMenu = Convert.ToInt32(Console.ReadLine());



                switch (selectedMenu)
                {
                    case 1:
                        {
                            Console.WriteLine("Please enter the bus name: (Enter -1 To Back To Menu)", Console.ForegroundColor = ConsoleColor.Yellow);
                            string busName = Console.ReadLine();
                            BackToMenu(busName);

                            Console.WriteLine("Please enter the bus type (1 for Normal, 2 for VIP):", Console.ForegroundColor = ConsoleColor.Yellow);
                            int busType = Convert.ToInt32(Console.ReadLine());
                            BackToMenu(busName);


                            if (busType == 1)
                            {
                                buses.Add(new NormalBus(busName));
                            }
                            else if (busType == 2)
                            {
                                buses.Add(new VipBus(busName));
                            }
                            else if(busType == -1)
                            {
                                RepeatConsoleMessage();
                            }
                            else
                            {
                                ShowErr();
                            }

                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Please enter the source of the trip: (Enter -1 To Back To Menu)", Console.ForegroundColor = ConsoleColor.Yellow);
                            string sourceName = Console.ReadLine();
                            BackToMenu(sourceName);


                            Console.WriteLine("Please enter the destination of the trip:", Console.ForegroundColor = ConsoleColor.Yellow);
                            string destinationName = Console.ReadLine();
                            BackToMenu(destinationName);

                            Console.WriteLine("Please enter the base price of the trip:", Console.ForegroundColor = ConsoleColor.Yellow);
                            int basePrice = Convert.ToInt32(Console.ReadLine());

                            BackToMenu(Convert.ToString(basePrice));

                            Console.WriteLine("Please Choose The Trip Bus:", Console.ForegroundColor = ConsoleColor.Yellow);



                            /*                            Console.WriteLine("\nName                Type                Seats", Console.ForegroundColor = ConsoleColor.Yellow);
                            */
                            var table = new ConsoleTable("Index","Name", "Type", "Seats");

                            Console.ResetColor();

                            for (int i = 0; i < buses.Count; i++)
                            {
                                table.AddRow($"{ i +1 }" , $"{buses[i].Name}", $"{buses[i].Type}", $"{buses[i].SeatsCount}");

/*                                Console.WriteLine($"{i + 1}){buses[i].Name}                {buses[i].Type}                 {buses[i].SeatsCount}", Console.ForegroundColor = ConsoleColor.White);
*/                            }
                            table.Write();


                            int busTripId = Convert.ToInt32(Console.ReadLine()) - 1;

                            BackToMenu(Convert.ToString(busTripId + 1));

                            Bus selectedBus = null;

                            for(int i = 0; i < buses.Count; i++)
                            {
                                if(busTripId == i)
                                {
                                    selectedBus = buses[i];
                                }
                            }
                            try
                            {
                                allTrips.Add(new Trip(sourceName, destinationName, basePrice, selectedBus));
                            }
                            catch
                            {
                                ShowErr();
                            }





                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Select The Trip (Enter -1 To Back To Menu)", Console.ForegroundColor = ConsoleColor.Yellow);

                            var table = new ConsoleTable("Index", "Source", "Destination", "Bus Name", "Bus Type", "Buy Price", "Empty Seats");
                            Console.ResetColor();

                            /*                            Console.WriteLine("Source              Destination         Bus Name            Bus Type            Buy Price           Empty Seats");
                            */
                            foreach (var trip in allTrips.Select((value, i) => new { i, value }))
                            {
                                int emptySeatsCount = trip.value.bus.Seats.Count(_ => _.Reserved == false);

                                table.AddRow($"{trip.i + 1}", $"{trip.value.source}", $"{trip.value.Destination}", $"{trip.value.bus.Name}", $"{trip.value.bus.Type}", $"{trip.value.Price}", $"{emptySeatsCount}");

/*                                Console.WriteLine($"{trip.i + 1}){trip.value.source}              {trip.value.Destination}              {trip.value.bus.Name}              {trip.value.Price}           {emptySeatsCount}", Console.ForegroundColor = ConsoleColor.White);
*/                            }
                            table.Write();
                            int selectedTrip = Convert.ToInt32(Console.ReadLine()) - 1;

                            BackToMenu(Convert.ToString(selectedTrip + 1));


                            Console.WriteLine("Select The Seat Number", Console.ForegroundColor = ConsoleColor.Yellow);

                            foreach (var Seat in allTrips[selectedTrip].bus.Seats.Select((value, i) => new { i, value }))
                            {

                                string reserved = Seat.value.Reserved ? "Sold" : "Empty";

                                Console.ForegroundColor = Seat.value.Reserved ? ConsoleColor.Red : ConsoleColor.White;

                                Console.WriteLine($"{Seat.i + 1}) {reserved}", Console.ForegroundColor);
                            }

                            int selectedSeat = Convert.ToInt32(Console.ReadLine()) - 1;

                            BackToMenu(Convert.ToString(selectedSeat + 1));

                            try
                            {
                                allTickets.Add(new Ticket(allTrips[selectedTrip], selectedSeat));
                            }
                            catch
                            {
                                ShowErr();
                            }

                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Select The Trip (Enter -1 To Back To Menu)", Console.ForegroundColor = ConsoleColor.Yellow);

                            var table = new ConsoleTable("Index", "Source", "Destination", "Bus Name", "Bus Type", "Buy Price", "Empty Seats");
                            Console.ResetColor();

                            /*                            Console.WriteLine("Source              Destination         Bus Name            Bus Type            Buy Price           Empty Seats", Console.ForegroundColor = ConsoleColor.Yellow);
                            */
                            int emptySeatsCount = 0;
                            foreach (var trip in allTrips.Select((value, i) => new { i, value }))
                            {
                                emptySeatsCount = trip.value.bus.Seats.Count(_ => _.Reserved == false);

                                table.AddRow($"{trip.i + 1}", $"{trip.value.source}", $"{trip.value.Destination}", $"{trip.value.bus.Name}", $"{trip.value.bus.Type}", $"{trip.value.Price}", $"{emptySeatsCount}");

/*                                Console.WriteLine($"{trip.i+1}){trip.value.source}              {trip.value.Destination}              {trip.value.bus.Name}              {trip.value.Price}           {emptySeatsCount}", Console.ForegroundColor = ConsoleColor.White);
*/                            }
                            table.Write();
                            int selectedTrip = Convert.ToInt32(Console.ReadLine())-1;

                            BackToMenu(Convert.ToString(selectedTrip + 1));


                            double totalIncome = 0;

                            try
                            {
                                totalIncome = allTrips[selectedTrip].Price * (allTrips[selectedTrip].bus.SeatsCount - emptySeatsCount);
                            }
                            catch
                            {
                                ShowErr();
                            }




                            Console.WriteLine("ToTal InCome :" + totalIncome, Console.ForegroundColor = ConsoleColor.Green);
                            break;
                        }
                    case 5:
                        {
/*                            Console.WriteLine("Name                Type                Seats\n", Console.ForegroundColor = ConsoleColor.Yellow);
*/
                            var table = new ConsoleTable("Name", "Type", "Seats");
                            Console.ResetColor();

                            foreach (Bus bus in buses)
                            {
                                table.AddRow($"{bus.Name}", $"{bus.Type}", $"{bus.SeatsCount}");

/*                                Console.WriteLine($"{bus.Name}                {bus.Type}                 {bus.SeatsCount}", Console.ForegroundColor = ConsoleColor.White);
*/                            }
                            table.Write();

                            break;
                        }

                    case 6:
                        {
                            var table = new ConsoleTable("Source", "Destination", "Bus Name", "Bus Type", "Buy Price");
                            Console.ResetColor();

                            /*                            Console.WriteLine("Source           Destination           Bus Name           Bus Type           Buy Price           ", Console.ForegroundColor = ConsoleColor.Yellow);
                            */
                            foreach (var trip in allTrips)
                            {
                                table.AddRow($"{trip.source}", $"{trip.Destination}", $"{trip.bus.Name}", $"{trip.bus.Type}", $"{trip.Price}");

/*                                Console.WriteLine($"{trip.source}           {trip.Destination}           {trip.bus.Name}           {trip.bus.Type}           {trip.Price}           ", Console.ForegroundColor = ConsoleColor.White);
*/                            }

                            break;
                        }
                    default:
                        {
                            ShowErr();
                            break;
                        }
                       


                }

                RepeatConsoleMessage();

            }

            void ShowErr(string message = $" Entered Number Is Out Of Range! Please Enter a Number Between range")
            {
                Console.WriteLine(message, Console.ForegroundColor = ConsoleColor.Yellow);
                RepeatConsoleMessage();

            }
            void BackToMenu(string enteredNum)
            {
                if(enteredNum == "-1" )
                {
                    RepeatConsoleMessage();
                }
            }
            void ShowInTable()
            {

            }
            

        }

    }
}