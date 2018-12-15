using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Models.DomainModels;
using Hadia.Models.ViewModels;
using Hadia.Models.Dtos;

namespace Hadia.Helper
{
    public class MappingProfile :Profile
    {
        
        public MappingProfile()
        {
            CreateMap<Mem_UgColleges, UgCollageDto>();
            CreateMap<Mem_StateMaster,StateDto>();

            CreateMap<Mem_EducationalQualificationMaster, EducationalQualificationMasterViewModel>();
            CreateMap<EducationalQualificationMasterViewModel, Mem_EducationalQualificationMaster>();

            CreateMap<Mem_SpouseEducationMaster, SpouseEducationMasterViewModel>();
            CreateMap<SpouseEducationMasterViewModel, Mem_SpouseEducationMaster>();
            
            
            CreateMap<Mem_StateMaster, StateMasterViewModel>();
            CreateMap<StateMasterViewModel, Mem_StateMaster>();

            CreateMap<Mem_UgColleges, UgCollegesViewModel>();
            CreateMap<UgCollegesViewModel, Mem_UgColleges>();

            CreateMap<Mem_DistrictMaster, DistrictMasterViewModel>().
                ForMember(dest => dest.StateName, o => o.MapFrom(s => s.State.StateName));
            CreateMap<DistrictMasterViewModel, Mem_DistrictMaster>();

            CreateMap<Mem_CountryCode, CountryViewModel>();
            CreateMap<CountryViewModel, Mem_CountryCode>();

            CreateMap<Mem_UniversityMaster, UniversityMasterViewModel>().
               ForMember(dest => dest.CountryName, o => o.MapFrom(s => s.Country.CountryName));
            CreateMap<UniversityMasterViewModel, Mem_UniversityMaster>();

            CreateMap<Mem_JobCategoryMaster, JobCategoryViewModel>();
            CreateMap<JobCategoryViewModel, Mem_JobCategoryMaster>();

            CreateMap<Post_GroupMaster, BatchViewModel>().
            ForMember(dest => dest.GroupName, o => o.MapFrom(s => s.GroupName));
            CreateMap<BatchViewModel, Post_GroupMaster>();

            CreateMap<Post_GroupMaster, ChapterViewModel>().
            ForMember(dest => dest.GroupName, o => o.MapFrom(s => s.GroupName))
            .ForMember(dest => dest.ChapterImage, o => o.MapFrom(s => s.GroupImage));
            CreateMap<ChapterViewModel, Post_GroupMaster>();

            CreateMap<Mem_Master, MemberViewModel>()
            .ForMember(dest => dest.UgCollegeName, o => o.MapFrom(s => s.UgCollege.UgCollegeName))
            .ForMember(dest => dest.BatchName, o => o.MapFrom(s => s.MainGroup.GroupName));
            
            CreateMap<MemberViewModel, Mem_Master>();


        }
    }
}
