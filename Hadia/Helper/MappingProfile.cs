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


        }
    }
}
