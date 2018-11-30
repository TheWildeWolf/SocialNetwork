using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Hadia.Models.DomainModels
{
    public class Mem_Master
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string AdNo { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public MaritalStatus Type { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int UgCollageId { get; set; }
        public int DistrictId { get; set; }

        public string SpouseName { get; set; }
        public DateTime? SpouseAge { get; set; }

        public int SpouseEducationId { get; set; }
        public int GroupId { get; set; }
        public bool IsBatchAdmin { get; set; }
        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public bool IsVarified { get; set; }

        public int VarifiedBy { get; set; }
        public DateTime? VarifiedDate { get; set; }


        public int MyProperty { get; set; }

        public ICollection<Mem_EducationalQualificationMaster> EducationalQualificationMasters { get; set; }
        public ICollection<Mem_SpouseEducationMaster> SpouseEducationMasters { get; set; }
        public ICollection<Mem_StateMaster> StateMasters { get; set; }
        public ICollection<Mem_DistrictMaster> DistrictMasters { get; set; }
        public ICollection<Mem_UniversityMaster> UniversityMasters { get; set; }


    }

    public enum MaritalStatus :byte
    {
        [DisplayName("Single")]
        Single=1,
        [DisplayName("Married")]
        Married = 2,
        [DisplayName("Divorced")]
        Divorced = 3
    }
}
