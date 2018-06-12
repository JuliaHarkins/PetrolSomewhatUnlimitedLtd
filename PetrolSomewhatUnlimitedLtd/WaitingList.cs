using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolSomewhatUnlimitedLtd
{
    class WaitingList
    {
        private List<Vehicle> waitingV = new List<Vehicle>();                                                   //list of waiting cars.
        VehicleCreation vc = new VehicleCreation();                                                             //the vehicle creation.

        /// <summary>
        /// adds a vehicle to the list.
        /// </summary>
        public void addVehicle()
        {
            if (waitingV.Count(s => s != null) < 5)                                                             //checks that there are less than 5 vehicles within the waiting list.
            {
                waitingV.Add(vc.createVehicle());                                                               //adds a random vehicle tot he list.
            }
        }
        /// <summary>
        /// finds the information for each vehicle within
        /// he list and lists them to the console.
        /// </summary>
        public void waitingVehicles()
        {
            foreach(Vehicle v in waitingV)
            {
                Fuel f = v.fuelTank();                                                                          //the fueltank of the vehicle.
                string vType = v.vehicleType();                                                                 //the vehicle type.
                string fType = f.fuelType();                                                                    //the fuel type.
                double fAmount = f.fuelAmount();                                                                //the fuel amount
                double fMaxAmount = f.maxFuel();                                                                //the maximun amount of fuel.
                Console.WriteLine("          "  + vType + " " + fAmount + "/" + fMaxAmount + "  " + fType );
            }
        }
        /// <summary>
        /// removes the vehicl from teh list.
        /// </summary>
        /// <returns></returns>
        public Vehicle vehicleServiced()
        {
            Vehicle v = waitingV.ElementAt(0);
            waitingV.RemoveAt(0);
            return v;
        }
        /// <summary>
        /// updates the list.
        /// </summary>
        /// <param name="time"></param>
        public void updateList(int time)
        {

            foreach(Vehicle v in waitingV)                                                                      //updates the time the vehicles have left to wait.
            {
                v.updateWaitTime(time);
            }
            for(int i = waitingV.Count - 1; i >= 0; i--)                                                        //goes through the list of waiting vehicles and removes the vehicels that wont wait anymore.
            {
                Vehicle v = waitingV.ElementAt(i);
                if (v.status() == true)
                {
                    waitingV.Remove(v);
                    VehiclesLeft.vehicleLeft();
                }
            }
        }
        /// <summary>
        /// counts the vehicles within the waiting list.
        /// </summary>
        /// <returns></returns>
        public int listCout()
        {
            return waitingV.Count();
        }

    }
}
