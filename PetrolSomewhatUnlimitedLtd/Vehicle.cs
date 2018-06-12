using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolSomewhatUnlimitedLtd
{
    /// <summary>
    /// blueprint for the vehicle.
    /// allowing for the creating for the vehicle and contains returns 'fuel' and 'type'.
    /// </summary>
    class Vehicle
    {
        private Fuel m_fuel;                                    //container for the fuel tank (fuel type,max, and amount).
        private string m_type;                                  //the type of vehicle.
        private int m_wait;                                     //the time the vehicle should wait for.
        private bool m_left;                                    //a bool to show whether the vehicle has left or not.
        /// <summary>
        /// creates the vehicle using the fuel, registration number 
        /// and the type of vehicle.
        /// </summary>
        /// <param name="fuel">contains object fuel.</param>
        /// <param name="name">contains the objects registration number.</param>
        /// <param name="type">contains the type of vehicle.</param>
        public Vehicle(Fuel fuel, string type, int wait)
        {
            m_fuel = fuel;
            m_type = type;
            m_wait = wait;
            m_left = false;
        }
        /// <summary>
        /// returns the fuel object for the class.
        /// </summary>
        /// <returns>returns the fuel object for the class.</returns>
        public Fuel fuelTank()
        {
            return m_fuel;
        }
        /// <summary>
        /// returns the vehicle type.
        /// </summary>
        /// <returns>returns the vehicle type.</returns>
        public string vehicleType()
        {

            return m_type;
        }
        /// <summary>
        /// adds to the waiting time to see if the vehicle has left.
        /// </summary>
        /// <param name="i">i is the amount of time past since the last check.</param>
        public void updateWaitTime(int i)
        {
            if (i >= m_wait)                //checks if the vehicle should leave the station.
            {
                m_left = true;
            }
            else
            {
                m_wait -= i;
            }
        }
        /// <summary>
        /// returns the status of the vehicle (a check to see if the vehicle has left the station or not).
        /// </summary>
        /// <returns></returns>
        public bool status()
        {
            return m_left;
        }

    }
}
