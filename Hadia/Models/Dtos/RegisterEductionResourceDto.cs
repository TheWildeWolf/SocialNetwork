using System.Collections.Generic;

namespace Hadia.Models.Dtos
{
    public class RegisterEductionResourceDto
    {
        public List<EducationQualificationDto> EducationQualifications { get; set; }
        public List<UniversityDto> Universities { get; set; }

    }
}