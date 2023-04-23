using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.Models
{
    public class SalesMenVehicles
    {
        [ForeignKey(nameof(SalesMan))]
        [Required]
        public int SalesManId { get; set; }
        [Required]
        public SalesMan SalesMan { get; set; }

        [ForeignKey(nameof(Vehicle))]
        [Required]
        public int VehicleId { get; set; }
        [Required]
        public Vehicle Vehicle { get; set; }
    }
}
