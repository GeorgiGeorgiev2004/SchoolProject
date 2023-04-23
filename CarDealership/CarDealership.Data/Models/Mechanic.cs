using CarDealership.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CarDealership.Data.Common;

namespace CarDealership.Data.Models;
public class Mechanic 
{
	public Mechanic()
	{
        VehiclesMechanics = new HashSet<VehicleMechanic>();
    }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int MechanicId { get; set; }

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
    public Specialisations Specialisation { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    public DateTime HireDate { get; set; }

    [Required]
    [Range(ValidationConstraints.SalaryMinM,ValidationConstraints.SalaryMaxM)]
    public decimal Salary { get; set; }

    [Required]
    public bool IsNewRecruit { get; set; }
    public ICollection<VehicleMechanic> VehiclesMechanics { get; set; }

}
