using System;
using System.ComponentModel.DataAnnotations;
using Hadia.Models.DomainModels;

namespace Hadia.Models.Dtos
{
    public class RegistrationDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string AdNo { get; set; }
        [Required]
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public MaritalStatus MaritalStatus { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public int UgCollageId { get; set; }
        public int DistrictId { get; set; }

        [Required]
        public string Phone { get; set; }
        [Required]
        public string CountryCode { get; set; }
        public int? GroupId { get; set; }
        
        [Required]
        [EmailAddress(ErrorMessage="Must be Email")]
        public string Email { get; set; }

        public string Password { get; set; }
    }
}