using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolSomewhatUnlimitedLtd
{
    class VehicleCreation
    {
    /// <summary>
    /// This class creates a vehicle randomly and assigns the fuel to it.
    /// till then retrun the vehicle once it is created.
    /// </summary>
        
        private string[] m_type = {"Car","Van","HGV"};                                      //an array containing all the posible variations of vehicles.
        private string[] m_fuel = {"Diesel","LGP", "Unleaded" };                            //an array containing all posible fuel types.
        
        /// <summary>
        /// randomly creates the vehicles and thier fuel types based on the
        /// requirements set.
        /// </summary>
        /// <returns>a random vehicle.</returns>
        public Vehicle createVehicle()
        {
            Random r = new Random();;                                                       //random number generater.
            //used to randomly pick the vehicle type.
            int vehicleNum = r.Next(0, 3);
            string type = m_type.ElementAt(vehicleNum);
            int wait = r.Next(1000, 2200);

            double max;                                                                      //container for the maximun fuel amount.
            double cur;                                                                      //container for the vehicles current fuel.
            string fuelType;                                                                //container for the vehicles fuel type

            //sets the maximun fuel, the current fuel and the fuel type based
            //on which vehicle type has been set. 
            if (type == "Car")
            {
                int ifuelType = r.Next(0, 3);
                fuelType = m_fuel.ElementAt(ifuelType);
                max = 40; 
                cur = r.Next(0,10);
            }
            else if (type =="Van")
            {
                int ifuelType = r.Next(0, 2);
                fuelType = m_fuel.ElementAt(ifuelType);
                max = 80;
                cur = r.Next(0, 20);
            }
            else
            {
                fuelType = "Diesel";
                max = 150;
                cur = r.Next(0,37);
            }
            Fuel f = new Fuel(fuelType, cur, max);                                      //the vehicles fuel based on the random information.
            Vehicle v = new Vehicle(f, type, wait);                                           //the vehicle based on random information.
            return v;
        }
    }
}
