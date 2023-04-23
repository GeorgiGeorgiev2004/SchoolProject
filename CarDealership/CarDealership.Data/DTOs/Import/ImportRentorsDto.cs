using CarDealership.Data.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.DTOs.Import;

public class ImportRentorsDto
{
    [JsonProperty("BirthDate")]
    public string BirthDate { get; set; }

    [Required]
    [MinLength(ValidationConstraints.FNMinLenght)]
    [MaxLength(ValidationConstraints.FNMaxLenght)]
    [JsonProperty("FirstName")]
    public string FirstName { get; set; } = null!;
    [Required]
    [MaxLength(ValidationConstraints.LNMaxLenght)]
    [MinLength(ValidationConstraints.LNMinLenght)]
    [JsonProperty("LastName")]
    public string LastName { get; set; } = null!;

    [MinLength(ValidationConstraints.MNMinLenght)]
    [MaxLength(ValidationConstraints.MNMaxLenght)]
    [JsonProperty("MiddleName")]
    public string? MiddleName { get; set; }

    [JsonProperty("DriverLicense")]
    [Required]
    public string DriverLicense { get; set; } = null!;

    [JsonProperty("PaymentMethod")]
    public int PaymentMethod { get; set; }

    //[JsonProperty("RentedVehicles")]
    //public int[] RentedVehicles { get; set; }
}
