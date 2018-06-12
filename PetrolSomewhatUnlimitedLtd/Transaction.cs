using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolSomewhatUnlimitedLtd
{
    /// <summary>
        /// this class creates the a transaction using all the details from
        /// the fuelInstance.
        /// </summary>
    class Transaction
    {
        private Vehicle m_vehicle;                                                  //the vehicle.
        private Pump m_pump;                                                        //the pump.
        private string m_vehicleType;                                               //the type to vehicle.
        private double m_fuelAmount;                                                //the amount of fuel bought.
        private string m_fuelType;                                                  //the type of fuel bought.
        private double m_fuelingPrice;                                              //the price of the fuel bought.
        private int m_pumpNum;

        /// <summary>
        /// creates a transaction which contains all the information the company
        /// needs to keep a record of - such as the vehicle, pump, cost of transacting etc..
        /// </summary>
        /// <param name="vehicle">the vehicle that bought the fuel.</param>
        /// <param name="pump">the pump whoes fuel was bought.</param>
        /// <param name="vehicleType">the type of the vehicle.</param>
        /// <param name="fuelAmount">the amount of fuel bought.</param>
        /// <param name="fuelType">the type of fuel bought.</param>
        /// <param name="fuelingPrice">the cost of all fuel.</param>
        public Transaction(Vehicle vehicle, Pump pump, double fuelAmount, string fuelType, double fuelingPrice)
        {
            m_vehicle = vehicle;
            m_pump = pump;
            m_fuelAmount = fuelAmount;
            m_fuelType = fuelType;
            m_fuelingPrice = fuelingPrice;
            m_vehicleType = m_vehicle.vehicleType();
            m_pumpNum = m_pump.name();

        }

        /// <summary>
        /// returns the amount of fuel bought.
        /// </summary>
        /// <returns>the amount of fuel</returns>
        public double fuelAmount()
        {
            return m_fuelAmount;
        }
        /// <summary>
        /// returns the price of the fuel bought.
        /// </summary>
        /// <returns></returns>
        public double transCost()
        {
            return m_fuelingPrice;
        }
        /// <summary>
        /// returns the number of the pump.
        /// </summary>
        /// <returns></returns>
        public int pumpNumber()
        {
            return m_pumpNum;
        }
        /// <summary>
        /// returns the type of fuel.
        /// </summary>
        /// <returns></returns>
        public string fuelType()
        {
            return m_fuelType;
        }
        /// <summary>
        /// returns the vehicle type.
        /// </summary>
        /// <returns></returns>
        public string vehicleType()
        {
            return m_vehicleType;
        }

    }
}
