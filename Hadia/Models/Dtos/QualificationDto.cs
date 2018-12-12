using System.Collections.Generic;
using Hadia.Models.DomainModels;

namespace Hadia.Models.Dtos
{
    public class QualificationDto
    {
        
       public int  UserId { get; set; }
       public int QualificationId { get; set; }
       public int UniversityId { get; set; }
       public int PassoutYear { get; set; }
       public string  Specialization { get; set; }
       public string Topic { get; set; }

       
    }
}