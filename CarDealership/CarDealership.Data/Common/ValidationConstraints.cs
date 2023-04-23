using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Common
{
    public class ValidationConstraints
    {
        //Common for all names
        public const int FNMinLenght = 1;
        public const int FNMaxLenght = 25;
                                    
        public const int MNMinLenght = 1;
        public const int MNMaxLenght = 25;
                                    
        public const int LNMinLenght = 1;
        public const int LNMaxLenght = 25;


        //Mechanic
        public const int SalaryMinM = 678;
        public const int SalaryMaxM = 4247;

        //Rentor
        public const string RegexDriverLicense = @"^[0-9]{9}$";

        //SalesMan
        public const int SalaryMinSM = 777;
        public const int SalaryMaxSM = 3743;

        //Vehicles
        public const string RegexLicensePlate = @"^[A-Z]{1,2}[0-9]{4}[A-Z]{2}$";


    }
}
