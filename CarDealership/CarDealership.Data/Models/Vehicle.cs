using CarDealership.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CarDealership.Data.Models;
using CarDealership.Data.Common;

public class Vehicle
{

    public Vehicle()
    {
        VehiclesMechanics =  new HashSet<VehicleMechanic>();
        SalesMenVehicles = new HashSet<SalesMenVehicles>();
    }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int VehicleId { get; set; }
    [Required]
    [RegularExpression(ValidationConstraints.RegexLicensePlate)]
    public string LicensePlate  { get; set; }

    [Required]
    public Makes Make { get; set; }

    [Required]
    public string Model { get; set; } = null!;

    public DateTime? RentedOn { get; set; }

    public DateTime? ReturnDate { get; set; }

    [Required]
    public bool IsRented { get; set; }

    [Required]
    public FuelTypes FuelType { get; set; }

    [Required]
    public decimal Mileage { get; set; }

    [Required]
    public decimal HorsePower { get; set; }
    [Required]
    public decimal Cost { get; set; }
 

    public int? RentorId { get; set; }
    [ForeignKey(nameof(RentorId))]
    public Rentor Rentor { get; set; }

    public ICollection<SalesMenVehicles> SalesMenVehicles { get; set; }

    public ICollection<VehicleMechanic> VehiclesMechanics { get; set; }
}
