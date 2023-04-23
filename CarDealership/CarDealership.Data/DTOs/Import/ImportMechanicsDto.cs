using CarDealership.Data.Common;
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
    public class ImportMechanicsDto
    {
        [Required]
        [MinLength(ValidationConstraints.FNMinLenght)]
        [MaxLength(ValidationConstraints.FNMaxLenght)]
        [JsonProperty("FirstName")]
        public string FirstName { get; set; } = null!;

        [MinLength(ValidationConstraints.MNMinLenght)]
        [MaxLength(ValidationConstraints.MNMaxLenght)]
        [JsonProperty("MiddleName")]
        public string? MiddleName { get; set; }

        [Required]
        [MinLength(ValidationConstraints.LNMinLenght)]
        [MaxLength(ValidationConstraints.LNMaxLenght)]
        [JsonProperty("LastName")]
        public string LastName { get; set; } = null!;

        [Required]
        [JsonProperty("Specialisation")]
        public Specialisations Specialisation { get; set; }

        [Required]
        [JsonProperty("BirthDate")]
        public string BirthDate { get; set; }

        [Required]
        [JsonProperty("HireDate")]
        public string HireDate { get; set; }

        [Required]
        [Range(ValidationConstraints.SalaryMinM, ValidationConstraints.SalaryMaxM)]
        [JsonProperty("Salary")]
        public decimal Salary { get; set; }

        [Required]
        [JsonProperty("IsNewRecruit")]
        public bool IsNewRecruit { get; set; }

        [Required]
        [JsonProperty("Vehicles")]
        public int[] Vehicles { get; set; }
    }
}
