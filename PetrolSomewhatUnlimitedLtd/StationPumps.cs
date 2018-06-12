using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PetrolSomewhatUnlimitedLtd
{
    class StationPumps
    {
        private Pump[,] m_pump;
        private Fuel m_unleaded;                                                            //the tank for unleaded fuel for the pumps.
        private Fuel m_LGP;                                                                 //the tank for LGP fuel for the pumps.
        private Fuel m_diesel;                                                              //the tank for diesel fuel for the pumps.
        WaitingList wl = new WaitingList();                                                 //the object containing the waiting vehicles.



        private char c = 'X';                                                               //exit flag.

        /// <summary>
        /// provides the details to create all the pumps.
        /// </summary>         
        public StationPumps()
        {
            m_unleaded = new Fuel("Unleaded", 900000, 900000);
            m_LGP = new Fuel("LGP", 900000, 900000);
            m_diesel = new Fuel("Diesel", 900000, 900000);
            m_pump = new Pump[3, 3] {{ createPump(1), createPump(2), createPump(3) },
                                  { createPump(4), createPump(5), createPump(6) },
                                  { createPump(7), createPump(8), createPump(9) }};
        }

        /// <summary>
        /// creates the pump using the name of the pump provided.
        /// </summary>
        /// <param name="i">the name of the pump</param>
        /// <returns>returns the pump.</returns>
        private Pump createPump(int i)
        {
            Pump p = new Pump(m_unleaded, m_LGP, m_diesel, i, false);                       //creates the pumps.
            return p;

        }
        /// <summary>
        /// displays the station for the user to see.
        /// </summary>
        private void displayStation()
        {
            Console.WriteLine("\n" +
                                "   Please press the pump number to fuel the top vehicle. (or press q to quit!)");
            counters();
            fuelInformation();
            Console.WriteLine(
                                "\n" +
                                "           ----Pump 1---------Pump 2---------Pump 3----\n" +
                                "           ----{0}--------{1}--------{2}---\n" +
                                "           ----Pump 4---------Pump 5---------Pump 6----\n" +
                                "           ----{3}--------{4}--------{5}---\n" +
                                "           ----Pump 7---------Pump 8---------Pump 9----\n" +
                                "           ----{6}--------{7}--------{8}---" +
                                "\n",
                                        pumpUse('1'), pumpUse('2'), pumpUse('3'),
                                        pumpUse('4'), pumpUse('5'), pumpUse('6'),
                                        pumpUse('7'), pumpUse('8'), pumpUse('9'));
        }
        /// <summary>
        /// checks if the pump number is in use and shows the
        /// percentage and vehicle type of it is.
        /// </summary>
        /// <param name="i">the pump number.</param>
        /// <returns>the console output for the pump.</returns>
        private string pumpUse(char i)
        {
            string container;                                                               //the console output.
            Pump p = findPump(i);                                                           //finds the pyump based on the name (from the input).

            if (p.status())                                                                 //checks if the pump is occupied.
            {
                FuelInstance fi = p.fuelinstance();                                         //gets the fuelinstance.
                Vehicle v = fi.vehicleOnPump();                                             //gets the vehicle from the fuel instance.
                Fuel fv = v.fuelTank();                                                     //gets the vehicles fuel.
                double per = fv.fuelPercent();                                              //gets the percentage of fuel within the vehicle.
                if (per > 9)
                {
                    container = v.vehicleType() + "-" + per + "%";                          //sets the container to the vehicle type and the percentace of fuel it contains.
                }
                else
                {
                    container = v.vehicleType() + "--" + per + "%";
                }
            }
            else                                                                            //if the pump isn't in use it returns dashes.
            {
                container = "-------";
            }
            return container;
        }
        /// <summary>
        /// the back bone of the program
        /// creates two timers, one for the cars to arrive, the other updates everything.
        /// </summary>
        public void timings()
        {
            Random r = new Random();                                                        //gets the random object.
            Timer t = new Timer()                                                           //creates the timer for the cars to appear.
            {
                Interval = r.Next(1500, 2200),                                              //the interval of the timer is between 1500ms and 2200ms.
                AutoReset = true,
            };
            t.Elapsed += addVehicle;                                                        //once the time elapses it'll add a new vehicle to the list.
            GC.KeepAlive(t);

            t.Start();                                                                      //starts the timer to updat the vehicle list.

            Timer waitingT = new Timer(100);
            waitingT.Elapsed += update;                                                     //updates the program every 100ms.

            waitingT.Start();                                                               //starts the waitingT timer.

            while (c != 'q')                                                                //checks the user input.
            {
                ConsoleKeyInfo keypress = Console.ReadKey();
                c = keypress.KeyChar;                                                       //reads the keypress of the user.

                if ((c == '1') || (c == '2') || (c == '3') ||                               //checks if the user wants to add a vehicle to a pump.
                    (c == '4') || (c == '5') || (c == '6') ||
                    (c == '7') || (c == '8') || (c == '9'))
                {
                    Pump p = findPump(c);                                                   //finds the pump based on the user input.
                    if (wl.listCout() > 0)                                                  //checks if there are vehicles waiting to be fueled.
                    {
                        if ((!p.status()) && (!pumpBlocker(int.Parse(c + ""))))             //checks if the pump is free and accessible.
                        {
                            Vehicle v = wl.vehicleServiced();                               //tells the waiting list the vehicle is to be seviced.
                            FuelInstance fi = new FuelInstance(v, p);                       //creates a a fuel instance with the pump and the vehicle.
                            p.setFuelInstance(fi);                                          //sets the pumps fuel instance.
                        }
                    }
                }
            }

            if (TransactionList.totalSales() > 0)                                           //checks if any transactions have been made.
            {
                waitingT.Stop();                                                            //stops the timers.
                t.Stop();

                
                overview();                                                                 //prints the overview for all the counters.
            }
        }
        /// <summary>
        /// adds a random vehicle tot he waiting list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addVehicle(Object sender, ElapsedEventArgs e)
        {
            wl.addVehicle();
        }
        /// <summary>
        /// updates the program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void update(object sender, ElapsedEventArgs e)
        {
            Console.Clear();                                                                //clears the console
            displayStation();                                                               //displays the station again.
            wl.updateList(100);                                                             //updates the waiting list
            foreach (Pump p in m_pump)                                                        //updates the pumps
            {
                p.update();
            }

            wl.waitingVehicles();                                                           //lists all the waiting vehicles.
        }
        /// <summary>
        /// finds the pump based on the number input.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>returns the pump</returns>
        private Pump findPump(char input)
        {
            int i = int.Parse(input + " ");
            i -= 1;
            int y = i / 3;
            int x = i % 3;
            return m_pump[y, x];
        }
        /// <summary>
        /// blocks off all pumps that can't be accessed.
        /// </summary>
        /// <param name="i">the pump number.</param>
        /// <returns>returns a bool to shoe if the pump is free.</returns>
        private bool pumpBlocker(int i)
        {
            i -= 1;
            int y = i / 3;
            int x = i % 3;
            for (int j = x - 1; j >= 0; j--)
            {
                if (m_pump[y, j].status())
                {
                    return true;
                }
            }
            return false;

        }
        /// <summary>
        /// the transaction overview
        /// </summary>
        private void overview()
        {
            Console.Clear();
            Console.WriteLine("\n" +
                                "       Overview            (Press any key to exit)");
            counters();
            Console.WriteLine("           Unleaded {0:F1}  LGP {1:F1}  Diesel {2:F1}\n", m_unleaded.fuelNeeded(), m_LGP.fuelNeeded(), m_diesel.fuelNeeded());
            TransactionList.listTransactions();
            Console.ReadKey();
        }
        /// <summary>
        /// shows all the counters.
        /// </summary>
        private void counters()
        {

            Console.WriteLine("\n" +
                                "           Litres Dispensed     {0:F0}L\n" +
                                "           Gross Income        £{1:F2}\n" +
                                "           Commission          £{2:F2}\n" +
                                "\n" +
                                "           Vehicles Seviced {3}         Vehicles Left {4}\n",
                                TransactionList.fuelSold(), TransactionList.grossMoney(), TransactionList.commission(),
                                TransactionList.totalSales(), VehiclesLeft.totalVehiclesLeft());
        }
        /// <summary>
        /// Prints out how much fuel has been used and whether it has all been used
        /// </summary>
        private void fuelInformation()
        {
            Console.WriteLine("            Unleaded {0:F1}  LGP {1:F1}  Diesel {2:F1}\n", value(m_unleaded), value(m_LGP), value(m_diesel));
        }
        /// <summary>
        /// checks there is any fuel in the oject and returns the number left or "empty" if none is left.
        /// </summary>
        /// <param name="i">the fuel object</param>
        /// <returns></returns>
        private string value(Fuel i){
            string re;
            if (i.fuelNeeded() < i.maxFuel())
            {
                re = Math.Round(i.fuelNeeded(),1).ToString();
            }
            else
            {
                re = "Empty";
            }
            return re;
            }
    }
}
