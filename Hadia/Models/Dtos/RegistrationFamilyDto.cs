using System;
using System.Collections.Generic;
using Hadia.Models.DomainModels;

namespace Hadia.Models.Dtos
{
    public class RegistrationFamilyDto
    {
        public int UserId { get; set; }
        public string SpouseName { get; set; }
        public int? SpouseAge { get; set; }

        public int? SpouseEducationId { get; set; }

        public List<KidsDto> Children { get; set; }
    }

    public class KidsDto
    {
        public string KidName { get; set; }
        public int? Age { get; set; }
        public GenderType Gender { get; set; }

    }
}