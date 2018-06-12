using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolSomewhatUnlimitedLtd
{
    /// <summary>
    /// the fuel instance updates the fuel in both the
    /// vehicle and the pump then creates a transaction
    /// to be added to the transaction list.
    /// </summary>
    class FuelInstance
    {
        
        private Pump m_pump;                                                                                    //the pump in use.
        private Vehicle m_vehicle;                                                                              //the vehicle being fueled.
        private double m_litresDispensed;                                                                       //a lifetime total of the amount of litres dipenced.
        private double m_price;                                                                                 //the price that check liter costs.
        /// <summary>
        /// creating a new fuel instance.
        /// </summary>
        /// <param name="v">the vehicle being fueled.</param>
        /// <param name="p">the pump being used.</param>
        public FuelInstance(Vehicle v, Pump p)
        {
            m_vehicle = v;
            m_pump = p;
            m_litresDispensed = 0f;
            m_price = 0f;
        }
        /// <summary>
        /// finds all the relevent details to do with the car and pump to add
        /// to the transactionlist. but will only update the fuel and add a
        /// transaction if the pump isn't occupied and the pump contains 
        /// ennough fuel to fully fuel the vehicle. 
        /// </summary>
        public void fuelVehicle(double i)
        {
            Fuel vehicleTank = m_vehicle.fuelTank();                                                            //the fuel for the vehicle.
            String fuelType = vehicleTank.fuelType();                                                           // the type of fuel being sold.
            Fuel pumpTank;                                                                                      //the fuel from the pump in use.
            double cost;                                                                                        //the cost per litre for the fuel.
            
            if (fuelType == "LGP")                                                                              //checking which fuel type is being sold and setting the price.
            {
                cost = 1.05;
                pumpTank = m_pump.lgp();
            }
            else if (fuelType == "Diesel")
            {
                cost = .95;
                pumpTank = m_pump.diesel();
            }
            else {
                cost = .85;
                pumpTank = m_pump.unleaded();
            }

            double pumpAmount = pumpTank.fuelAmount();                                                          //total fuel in the pump of the correct type.
            double fuelneeded = vehicleTank.fuelNeeded();                                                       //the amount of fuel the car needs to be fully fueled.
            bool occupied = m_pump.status();                                                                    //bool showing whether the pump is occupied. 

            if ((pumpAmount > 0))                                                                               //a check to see if theres enough fuel to fully fuel the vehicle, to prevent vehicles from fueling when there is a lack of fuel.
            {

                double fuelAmount = vehicleTank.addFuel(i);                                                     //the amount of fuel added.
                m_litresDispensed += i;                                           
                pumpTank.removeFuel(i);
                m_price += cost * fuelAmount;                                                                   //the price of the fueling.
                String vehicleType = m_vehicle.vehicleType();                                                   //the type of the vehicle fueled.

                if ((vehicleTank.fuelNeeded() <= 0f) || (pumpAmount <=0))                                       //a check to find out if the vehicle is fully fueled or the pump is out of fuel
                {
                    m_pump.statusUpdate(false);                                                                 //setting the pump to no longer be occupied.
                    Transaction t = new Transaction(m_vehicle, m_pump,m_litresDispensed, fuelType, m_price);    //creating a transaction.
                    TransactionList.addTransaction(t);                                                          //adding the transaction the the list of transactions.
                }
            }
            else if(m_litresDispensed >0)                                                                       //vehicles leave if there isn't enought fuel to fill their tank.
            {
                m_pump.statusUpdate(false);                                                                     //setting the pump to no longer be occupied.
                Transaction t = new Transaction(m_vehicle, m_pump, m_litresDispensed, fuelType, m_price);       //creating a transaction.
                TransactionList.addTransaction(t);                                                              //adding the transaction the the list of transactions.

            }
            else
            {
                m_pump.statusUpdate(false);
                VehiclesLeft.vehicleLeft();
            }
        }
        /// <summary>
        /// retruns the vehicle involved in the transaction.
        /// </summary>
        /// <returns></returns>
        public Vehicle vehicleOnPump()
        {
            return m_vehicle;
        }
    }
}
