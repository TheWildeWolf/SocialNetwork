using System;
using Hadia.Models.DomainModels;

namespace Hadia.Models.Dtos
{
    public class ProfileSaveDto 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AdNo { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; }
        public string CountryCode { get; set; }
        public MaritalStatus? MaritalStatusId { get; set; }
        public int? DistrictId { get; set; }
        public int ChapterId { get; set; }
        public int StateId { get; set; }
    }
}
