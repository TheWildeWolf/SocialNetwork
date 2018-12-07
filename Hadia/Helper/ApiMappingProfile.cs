using AutoMapper;
using Hadia.Models.DomainModels;
using Hadia.Models.Dtos;

namespace Hadia.Helper
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<Mem_UgColleges, UgCollageDto>();
            CreateMap<Mem_StateMaster,StateDto>();

            CreateMap<Mem_UniversityMaster,UniversityDto>();
            CreateMap<UniversityDto,Mem_UniversityMaster>();

            CreateMap<Mem_EducationalQualificationMaster,EducationQualificationDto>();
            CreateMap<EducationQualificationDto,Mem_EducationalQualificationMaster>();

            
            CreateMap<Mem_JobCategoryMaster,JobCategoryDto>();
            CreateMap<JobCategoryDto,Mem_JobCategoryMaster>();

            
            CreateMap<Mem_CountryCode,CountryDto>();
            CreateMap<CountryDto,Mem_CountryCode>();

            CreateMap<Mem_WorkDetail,JobdetailDto>();
            CreateMap<JobdetailDto,Mem_WorkDetail>();

            CreateMap<Mem_SpouseEducationMaster,SpouseEducationDto>();
            CreateMap<SpouseEducationDto,Mem_SpouseEducationMaster>();
        }
    }
}