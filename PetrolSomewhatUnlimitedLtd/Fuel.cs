using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolSomewhatUnlimitedLtd
{
    /// <summary>
    /// blue print for the fuel.
    /// the fuel is made up of the type of fuel, the amount of fuel it has and and maximun 
    /// amount fuel. it allows for the editing of the fuel amount.
    /// </summary>
    class Fuel
    {
        private string m_type;                                          //the type of fuel.
        private double m_amount;                                        //the amount of fuel.
        private double m_max;                                           //maximun amount of fuel.

        /// <summary>
        /// creating of the object fuel.
        /// </summary>
        /// <param name="type">the type of fuel (diesel,LGP or unleaded).</param>
        /// <param name="amount">the amount of fuel the vehicle has.</param>
        /// <param name="max">the maximun amount of fuel the vehicle can take.</param>
        public Fuel(string type, double amount, double max)
        {
            m_type = type;
            m_amount = amount;
            m_max = max;
        }
        /// <summary>
        /// addds the amount of fuel provided to the vehicle and returns the amount
        /// the vehicle was filled.
        /// </summary>
        /// <param name="num">num conatains the amount of fuel added.</param>
        /// <returns></returns>
        public double addFuel(double num)
        {
            m_amount += num;
            return num;
        }
        /// <summary>
        /// removed the amount provided from the fuel tank.
        /// </summary>
        /// <param name="num">the amount that is to be taken out of the fuel tank.</param>
        public void removeFuel(double num)
        { 
                m_amount -= num;
        }
        /// <summary>
        /// returns the maximun fuel capasity.
        /// </summary>
        /// <returns>returns the maximun fuel capasity.</returns>
        public double maxFuel()
        {
            return m_max;
            }
        /// <summary>
        /// returns the difference between the maximum and minimun fuel.
        /// </summary>
        /// <returns>returns the difference between the max imum and minimun fuel.</returns>
        public double fuelNeeded()
        {
            double diff = m_max - m_amount;                             //the amount of fuel needed to get a full tank.
            return diff;
        }
        /// <summary>
        /// returns the type of fuel.
        /// </summary>
        /// <returns>returns the type of fuel.</returns>
        public string fuelType()
        {
            return m_type;
        }
        /// <summary>
        /// returns the amount of fuel.
        /// </summary>
        /// <returns>returns the amount of fuel.</returns>
        public double fuelAmount()
        {
            return m_amount;
        }
        /// <summary>
        /// retruns the current percentage of fuel.
        /// </summary>
        /// <returns></returns>
        public int fuelPercent()
        {
            double percent = m_amount / m_max * 100;
            return (int)percent;
        }
    }
}
