using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolSomewhatUnlimitedLtd
{
    /// <summary>
    /// the pump contains all relevent information about the
    /// pump: their fuel amounts, whether it's occupied, and
    /// the pump name.
    /// </summary>
    class Pump
    {
        private Fuel m_unleaded;                                                //the fuel information for unleaded.
        private Fuel m_LGP;                                                     //the fuel information for LGP.
        private Fuel m_diesel;                                                  //the fuel information for diesel.
        private int m_name;                                                     //the pump number.
        private bool m_occupied;                                                //whether the pump is occupied.
        private FuelInstance m_fuelingInstance;
        /// <summary>
        /// Creates a pump with three fuel tanks, it's
        /// name and a bool to show if it's occupied.
        /// </summary>
        /// <param name="unleaded">the fuel class with unleaded.</param>
        /// <param name="LGP">the fuel class with LGP.</param>
        /// <param name="diesel">the fuel class with diesel.</param>
        /// <param name="name">the pump number.</param>
        /// <param name="occupied">the pump status.</param>
        public Pump(Fuel unleaded, Fuel LGP, Fuel diesel, int name, bool occupied)
        {
            m_unleaded = unleaded;
            m_LGP = LGP;
            m_diesel = diesel;
            m_name = name;
            m_occupied = occupied;
        }

        /// <summary>
        /// reutrns the fuel object for the unleaded.
        /// </summary>
        /// <returns></returns>
        public Fuel unleaded()
        {
            return m_unleaded;
        }
        /// <summary>
        /// reutrns the fuel object for the lgp.
        /// </summary>
        /// <returns></returns>
        public Fuel lgp()
        {
            return m_LGP;
        }
        /// <summary>
        /// reutrns the fuel object for the diesel.
        /// </summary>
        /// <returns></returns>
        public Fuel diesel()
        {
            return m_diesel;
        }
        /// <summary>
        /// returns a bool showing whether the pump is
        /// occupied or unoccupied.
        /// </summary>
        /// <returns></returns>
        public bool status()
        {
            return m_occupied;
        }
        /// <summary>
        /// updates the status of the fuel pump based on what you input (true or false).
        /// </summary>
        /// <param name="occupied">the new status of the pump</param>
        public void statusUpdate(bool occupied)
        {
            m_occupied = occupied;
        }
        /// <summary>
        /// returns the fuelInstance of the pump.
        /// </summary>
        /// <returns></returns>
        public FuelInstance fuelinstance(){

            return m_fuelingInstance;
        }
        /// <summary>
        /// sets the fuel instance to the given instance
        /// and changes the status of the pump.
        /// </summary>
        /// <param name="fi"></param>
        public void setFuelInstance(FuelInstance fi)
        {
            m_occupied = true;
            m_fuelingInstance = fi;
        }
        /// <summary>
        /// updates the fuelInstance of the pump.
        /// </summary>
        public void update()
        {
            if (m_occupied == true)
            {
                m_fuelingInstance.fuelVehicle(0.1f);
            }
            else if (m_occupied==false)
            {
                m_fuelingInstance = null;
            }
        }

        /// <summary>
        /// returns the name of the pump.
        /// </summary>
        /// <returns></returns>
        public int name()
        {
            return m_name;
        }

    }
}
