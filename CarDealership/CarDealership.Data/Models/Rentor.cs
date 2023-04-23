using CarDealership.Data.Common;
using CarDealership.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealership.Data.Models;

public class Rentor
{
	public Rentor()
	{
        RentedVehicles = new HashSet<Vehicle>();
    }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RentorId { get; set; }

    [Required]
    [MinLength(ValidationConstraints.FNMinLenght)]
    [MaxLength(ValidationConstraints.FNMaxLenght)]
    public string FirstName { get; set; } = null!;

    [MinLength(ValidationConstraints.MNMinLenght)]
    [MaxLength(ValidationConstraints.MNMaxLenght)]
    public string? MiddleName { get; set; }

    [Required]
    [MinLength(ValidationConstraints.LNMinLenght)]
    [MaxLength(ValidationConstraints.LNMaxLenght)]
    public string LastName { get; set; } = null!;

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    [RegularExpression(ValidationConstraints.RegexDriverLicense)]
    public string DriverLicense { get; set; }

    [Required]
    public PaymentMethods PaymentMethod{ get; set; }

    public ICollection<Vehicle> RentedVehicles { get; set; }
}
