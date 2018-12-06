using System.Collections.Generic;

namespace Hadia.Models.Dtos
{
    public class EducationRegisterDto
    {
        public List<QualificationDto> Qualifications { get; set; }
        public List<ProjectworkDto> Projects { get; set; }
    }
}