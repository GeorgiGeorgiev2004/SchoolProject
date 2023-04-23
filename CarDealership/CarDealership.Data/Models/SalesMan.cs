using CarDealership.Data.Common;
using CarDealership.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarDealership.Data.Models;

public class SalesMan
{
    public SalesMan()
    {
        SalesMenVehicles = new HashSet<SalesMenVehicles>();
    }
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public int SalesManId { get; set; }

    [Required]
    [MinLength(ValidationConstraints.FNMinLenght)]
    [MaxLength(ValidationConstraints.FNMaxLenght)]
    public string FirstName { get; set; } = null!;

    [MinLength(ValidationConstraints.MNMinLenght)]
    [MaxLength(ValidationConstraints.MNMaxLenght)]
    public string? MiddleName { get; set; }

    [Required]
    [MaxLength(ValidationConstraints.LNMaxLenght)]
    [MinLength(ValidationConstraints.LNMinLenght)]
    public string LastName { get; set; } = null!;

    [Required]
    [Range(ValidationConstraints.SalaryMinSM, ValidationConstraints.SalaryMaxSM)]
    public decimal Salary { get; set; }

    [Required]
    public InStoreRankings Ranking { get; set; }
    
    [Required]
    public DateTime BirthDate { get; set; }

    [Required]
    public DateTime HireDate { get; set; }

    public ICollection<SalesMenVehicles> SalesMenVehicles { get; set; }
}
