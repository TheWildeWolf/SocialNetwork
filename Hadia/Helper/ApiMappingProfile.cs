using System;
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

            CreateMap<Mem_Master, RegistrationDto>();
            CreateMap<RegistrationDto, Mem_Master>();

            CreateMap<Mem_UniversityMaster,UniversityDto>()
             .ForMember(dest => dest.Name, o => o.MapFrom(s => s.UniversityName));

            CreateMap<UniversityDto,Mem_UniversityMaster>()
            .ForMember(dest => dest.UniversityName, o => o.MapFrom(s => s.Name));

            CreateMap<Mem_EducationalQualificationMaster,EducationQualificationDto>()
                .ForMember(dest => dest.Name, o => o.MapFrom(s => s.DegreeName));
            CreateMap<EducationQualificationDto,Mem_EducationalQualificationMaster>();
                        


            
            CreateMap<Mem_JobCategoryMaster,JobCategoryDto>();
            CreateMap<JobCategoryDto,Mem_JobCategoryMaster>();

            
            CreateMap<Mem_CountryCode,CountryDto>();
            CreateMap<CountryDto,Mem_CountryCode>();

            CreateMap<Mem_WorkDetail,JobdetailDto>();
            CreateMap<JobdetailDto,Mem_WorkDetail>();

            CreateMap<Mem_SpouseEducationMaster,SpouseEducationDto>()
                .ForMember(f=>f.Name,o=> o.MapFrom(s=>s.QualificationName));
            CreateMap<SpouseEducationDto,Mem_SpouseEducationMaster>();

            
            CreateMap<Mem_Kid,KidsDto>();
            CreateMap<KidsDto,Mem_Kid>()
             .ForMember(dest => dest.Age,opt => opt.MapFrom(src => new DateTime(DateTime.Now.Year - src.Age??1,1,1)));
               
        }
    }
}