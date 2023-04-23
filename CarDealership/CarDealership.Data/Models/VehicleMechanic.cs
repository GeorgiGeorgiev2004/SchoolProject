using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealership.Data.Models;

public class VehicleMechanic
{
    [ForeignKey(nameof(Mechanic))]
    [Required]
    public int MechanicId { get; set; }
    [Required]
    public Mechanic Mechanic { get; set; }

    [ForeignKey(nameof(Vehicle))]
    [Required]
    public int VehicleId { get; set; }
    [Required]
    public Vehicle Vehicle { get; set; }
}
