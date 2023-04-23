using CarDealership.Data.Common;
using CarDealership.Data.Models.Enums;
using CarDealership.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CarDealership.Data.DTOs.Import
{
    public class ImportVehiclesDto
    {

        [Required]
        [RegularExpression(ValidationConstraints.RegexLicensePlate)]
        [JsonProperty("LicensePlate")]
        public string LicensePlate { get; set; }

        [Required]
        [JsonProperty("Make")]
        public int Make { get; set; }

        [Required]
        [JsonProperty("Model")]
        public string Model { get; set; } = null!;

        [Required]
        [JsonProperty("FuelType")]
        public int FuelType { get; set; }

        [Required]
        [JsonProperty("Mileage")]
        public decimal Mileage { get; set; }

        [Required]
        [JsonProperty("HorsePower")]
        public decimal HorsePower { get; set; }
        [Required]
        [JsonProperty("Cost")]
        public decimal Cost { get; set; }
    }
}
