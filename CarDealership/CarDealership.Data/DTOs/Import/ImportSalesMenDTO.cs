using CarDealership.Data.Common;
using CarDealership.Data.Models;
using CarDealership.Data.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership.Data.DTOs.Import
{
    public class ImportSalesMenDTO
    {
        [JsonProperty("BirthDate")]
        public string BirthDate { get; set; }

        [Required]
        [MinLength(ValidationConstraints.FNMinLenght)]
        [MaxLength(ValidationConstraints.FNMaxLenght)]
        [JsonProperty("FirstName")]
        public string FirstName { get; set; } = null!;
        [JsonProperty("HireDate")]
        public string HireDate { get; set; }

        [Required]
        [MaxLength(ValidationConstraints.LNMaxLenght)]
        [MinLength(ValidationConstraints.LNMinLenght)]
        [JsonProperty("LastName")]
        public string LastName { get; set; } = null!;

        [MinLength(ValidationConstraints.MNMinLenght)]
        [MaxLength(ValidationConstraints.MNMaxLenght)]
        [JsonProperty("MiddleName")]
        public string? MiddleName { get; set; }
        [JsonProperty("Ranking")]
        public int Ranking { get; set; }

        [Required]
        [Range(ValidationConstraints.SalaryMinSM, ValidationConstraints.SalaryMaxSM)]
        [JsonProperty("Salary")]
        public decimal Salary { get; set; }

        [Required]
        [JsonProperty("Vehicles")]
        public int[] Vehicles { get; set; }
    }
}
