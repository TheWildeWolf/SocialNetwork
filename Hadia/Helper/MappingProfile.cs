﻿using System;
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
            .ForMember(dest => dest.BatchName, o => o.MapFrom(s => s.MainGroup.GroupName))
            .ForMember(dest => dest.DistrictName, o => o.MapFrom(s => s.District.DistrictName))
            .ForMember(dest => dest.ChapterName, o => o.MapFrom(s => s.MembershipInGroups
            .Where(x => x.GroupMaster.Type == GroupType.Chapter).OrderByDescending(x => x.GroupMaster.FormedOn)
            .FirstOrDefault().GroupMaster.GroupName))
            .ForMember(dest => dest.ChapterId, o => o.MapFrom(s => s.MembershipInGroups
            .Where(x => x.GroupMaster.Type == GroupType.Chapter).OrderByDescending(x => x.GroupMaster.FormedOn)
            .FirstOrDefault().GroupMaster.Id));
            CreateMap<MemberViewModel, Mem_Master>();

            CreateMap<Mem_Master, MemberDetailsViewModel>()
           .ForMember(dest => dest.UgCollegeName, o => o.MapFrom(s => s.UgCollege.UgCollegeName))
           .ForMember(dest => dest.BatchName, o => o.MapFrom(s => s.MainGroup.GroupName))
           .ForMember(dest => dest.DistrictName, o => o.MapFrom(s => s.District.DistrictName))
           .ForMember(dest => dest.Photo, o => o.MapFrom(s => s.Photos.Any() && s.Photos != null ? s.Photos.FirstOrDefault(p => p.IsActive).Image : ""))
           .ForMember(dest => dest.QualificationName, o => o.MapFrom(s => s.SpouseEducation.QualificationName))
           .ForMember(dest => dest.ChapterName, o => o.MapFrom(s => s.MembershipInGroups
           .Where(x => x.GroupMaster.Type == GroupType.Chapter).OrderByDescending(x => x.GroupMaster.FormedOn)
           .FirstOrDefault().GroupMaster.GroupName))
           .ForMember(dest => dest.ChapterId, o => o.MapFrom(s => s.MembershipInGroups
           .Where(x => x.GroupMaster.Type == GroupType.Chapter).OrderByDescending(x => x.GroupMaster.FormedOn)
           .FirstOrDefault().GroupMaster.Id))
           .ForMember(des => des.SpouseAge, o => o.MapFrom(s => s.SpouseAge != null ? DateTime.Now.Year - s.SpouseAge.Value.Year : 0));
            CreateMap<MemberDetailsViewModel, Mem_Master>();


            CreateMap<Mem_Kid, KidViewModel>()
            .ForMember(x => x.Age, o => o.MapFrom(s => s.Age != null ? DateTime.Now.Year - s.Age.Year : 0));
            CreateMap<KidViewModel, Mem_Kid>()
            .ForMember(x => x.Age, o => o.MapFrom(s => DateTime.Now.AddYears(-s.Age)));

            CreateMap<Mem_Kid, KidsViewModel>()
            .ForMember(x => x.Age, o => o.MapFrom(s => s.Age != null ? DateTime.Now.Year - s.Age.Year : 0));

            CreateMap<Mem_Master, ProfileEditViewModel>()
            //.ForMember(dest => dest.BatchName, o => o.MapFrom(s => s.MainGroup.GroupName))
            .ForMember(dest => dest.ChapterId, o => o.MapFrom(s => s.MembershipInGroups
            .Where(x => x.GroupMaster.Type == GroupType.Chapter).OrderByDescending(x => x.GroupMaster.FormedOn)
            .FirstOrDefault().GroupMaster.Id));
            CreateMap<ProfileEditViewModel, Mem_Master>();

            CreateMap<Mem_EducationDetail, EducationQualifictaionEditViewModel>()
                .ForMember(dest => dest.PassoutYear, o => o.MapFrom(s => s.PassoutYear.Year)); 
            CreateMap<EducationQualifictaionEditViewModel, Mem_EducationDetail>()
                .ForMember(dest => dest.PassoutYear, o => o.MapFrom(s => new DateTime(s.PassoutYear,1,1)));

            CreateMap<Mem_Master, SpouseViewModel>()
            .ForMember(dest => dest.QualificationName, o => o.MapFrom(s => s.SpouseEducation.QualificationName))
            .ForMember(des => des.SpouseAge, o => o.MapFrom(s => s.SpouseAge != null ? DateTime.Now.Year - s.SpouseAge.Value.Year : 0));
            CreateMap<SpouseViewModel,Mem_Master>()
            .ForMember(des => des.SpouseAge, o => o.MapFrom(s => s.SpouseAge != null ? DateTime.Now.AddYears(-s.SpouseAge ?? 0) : (DateTime?)null));

            CreateMap<Mem_WorkDetail, WorkDetailsViewModel>();
            CreateMap<WorkDetailsViewModel, Mem_WorkDetail>();

            CreateMap<Post_Report, ReportsViewModel>()
            .ForMember(dest => dest.Post, o => o.MapFrom(s => s.PostMaster.Topic))
            .ForMember(dest => dest.ReportedBy, o => o.MapFrom(s => s.ReportedBy.Name))
            .ForMember(dest => dest.Reason, o => o.MapFrom(s => s.ReportReason.Reason));
            CreateMap<ReportsViewModel, Post_Report>();

            CreateMap<Post_Report, PostReportViewModel>()
            .ForMember(dest => dest.Topic, o => o.MapFrom(s => s.PostMaster.Topic))
            .ForMember(dest => dest.Voice, o => o.MapFrom(s => s.PostMaster.Voice))
            .ForMember(dest => dest.Images, o => o.MapFrom(s => s.PostMaster.PostImages.Select(x=>x.Image)))
            .ForMember(dest => dest.PostedBy, o => o.MapFrom(s => s.ReportedBy.Name))
            .ForMember(dest => dest.GroupName, o => o.MapFrom(s => s.PostMaster.GroupMaster.GroupName))
            .ForMember(dest => dest.Reason, o => o.MapFrom(s => s.ReportReason.Reason))
            .ForMember(dest => dest.Date, o => o.MapFrom(s => s.PostMaster.CDate))
            .ForMember(dest => dest.ReportedDate, o => o.MapFrom(s => s.ReportReason.CDate))
             .ForMember(dest => dest.Narration, o => o.MapFrom(s => s.Narration))
             .ForMember(dest => dest.ReportedBy, o => o.MapFrom(s => s.ReportedBy.Name)) ;
            CreateMap<PostReportViewModel, Post_Report>();
           
    }
    }
}
