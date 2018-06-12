using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetrolSomewhatUnlimitedLtd
{
    /// <summary>
    /// Keeps track of all the vehicles that have left
    /// after not being serviced by the petrol station.
    /// </summary>
    class VehiclesLeft
    {

        private static int counter;                                //this is the container for the count.

        /// <summary>
        /// this methood adds 1 to the current counter
        /// of vehicles left.
        /// </summary>
        public static void vehicleLeft()
        {
            counter+=1;
        }
        /// <summary>
        /// using this methood you are able to get the
        /// current count of vehicles that have left the station.
        /// </summary>
        /// <returns>the count of vehicles</returns>
        public static int totalVehiclesLeft()
        {
            return counter;
        }
    }
}
