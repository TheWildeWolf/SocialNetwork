using System.Collections.Generic;

namespace Hadia.Models.Dtos
{
    public class RegistrationResourseDto
    {
        public List<StateDto> States { get; set; }
        public List<UgCollageDto> UgCollages { get; set; }

        public List<BatchDto> Batches { get; set; }

        public List<EnumValuesDto> MaritalStatus { get; set; }
    }
}