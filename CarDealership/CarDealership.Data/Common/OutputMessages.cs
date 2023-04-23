using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Common
{
    public class OutputMessages
    {
        public const string ErrorNoSuchVehicle = "Vehicle not found";

        public const string SuccessfullyImportedSalesMen = "Successfully imported salesman -{0} with {1} vehicles!";

        public const string SuccessfullyImportedVehicles = "Successfully imported {0} vehicles!";

        public const string SuccessfullyImportedRentors = "Successfully imported {0} rentors!";

        public const string SuccessfullyImportedMechanic = "Successfully imported mechanic -{0} taking care of {1} vehicles!";

    }
}
