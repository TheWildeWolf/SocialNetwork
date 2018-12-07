using System.Collections.Generic;

namespace Hadia.Models.Dtos
{
    public class RegisterJobResourceDto
    {
        public List<CountryDto> Countries { get; set; }
        public List<JobCategoryDto> JobCategories { get; set; }
    }
}