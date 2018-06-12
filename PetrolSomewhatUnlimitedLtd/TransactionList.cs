using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolSomewhatUnlimitedLtd
{
    /// <summary>
    /// the transactionList conatins all of the instances the vehicles used the pumps and
    /// all the relevent information to do with the transactions.
    /// the transactions list is able to list all the transactions and give data about its
    /// liftime use; such as the amount of fuel sold, the amount of a type fuel sold,
    /// the gross total gained from the transactions, the commissions, and the total
    /// transactions.
    /// </summary>
    class TransactionList
    {

        private static List<Transaction> Transactions = new List<Transaction>();                //the list of all transactions.

        /// <summary>
        /// adds a transaction to the list.
        /// </summary>
        /// <param name="i">a new transaction.</param>
        public static void addTransaction(Transaction i)
        {
            Transactions.Add(i);
        }
        /// <summary>
        /// goes thought the list one by one and prints out the transactions.
        /// </summary>
        public static void listTransactions()
        {
            Console.WriteLine("\tTransactions\n\n\tNumber\tPump\tVehicle\tCost\t Litres\t Fuel\t\n");
            for (int i = 0; i < Transactions.Count(); i++)
            {
                Console.WriteLine("\t{0}\t{1}\t{2}\t£{3:F2}\t {4:F0}L\t {5}",
                     i+1, Transactions[i].pumpNumber(),Transactions[i].vehicleType(),Transactions[i].transCost(), Transactions[i].fuelAmount(), Transactions[i].fuelType());
            }
        }
        /// <summary>
        /// calculates the amount of fuel sold.
        /// </summary>
        /// <returns>the amount of fuel sold thought the lifetime of the program.</returns>
        public static double fuelSold()
        {
            double amountF = 0;                                                                    //a varible containing the amount of fuel.
            for (int i = 0; i < Transactions.Count(); i++)
            {
                amountF += Transactions[i].fuelAmount();
            }
            return amountF;
        }
        /// <summary>
        /// calculates the worth of the fuel sold.
        /// </summary>
        /// <returns></returns>
        public static double grossMoney()
        {
            double amountM = 0;                                                                    //a varible containing the amount of money.
            for (int i = 0; i < Transactions.Count(); i++)
            {
                amountM += Transactions[i].transCost();
            }
            return amountM;
        }
        /// <summary>
        /// finds the gross amount and caculates the amount of commission.
        /// </summary>
        /// <returns>the life time commission.</returns>
        public static double commission()
        {
            double gross = grossMoney();                                                         //a varible containing the gross amount of money.
            double amountC = gross * 0.01;                                                      //a varible containing the total commission.
            return amountC;
        }
        /// <summary>
        /// counts all transactions.
        /// </summary>
        /// <returns>amount of transactions.</returns>
        public static int totalSales()
        {
            int i = Transactions.Count();                                                       //total amount of transactions.
            return i;
        }

    }
}
