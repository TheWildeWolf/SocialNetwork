using System;
using System.Collections.Generic;
using System.Linq;
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

            
            CreateMap<Mem_Kid,KidsDto>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => DateTime.Now.Year - src.Age.Year));

            CreateMap<Mem_Kid, KidViewDto>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => DateTime.Now.Year - src.Age.Year));

            CreateMap<KidsDto, Mem_Kid>()
                .ForMember(dest => dest.Age,
                    opt => opt.MapFrom(src => new DateTime(DateTime.Now.Year - src.Age ?? 1, 1, 1)));

            CreateMap<Post_Category, PostCategoryDto>();


            CreateMap<Post_Comment, CommentViewDto>()
                .ForMember(dest => dest.Name, from =>
                    from.MapFrom(src => src.Createdby.Name))
                .ForMember(dest => dest.Text, from =>
                    from.MapFrom(src => GetUrl(src.Type, src.Comment, src.Date)));

            CreateMap<Post_Comment, CommentReplayDto>()
                .ForMember(dest => dest.Name, from =>
                    from.MapFrom(src => src.Createdby.Name))
                .ForMember(dest => dest.Text, from =>
                    from.MapFrom(src => GetUrl(src.Type, src.Comment, src.Date)));

            //CreateMap<Post_Master, TimelineViewDto>()
            //    .ForMember(dest => dest.Images, from =>
            //        from.MapFrom(src => GetUrl(src.PostImages)));

            CreateMap<Post_Master, FeedDto>()
                .ForMember(dest => dest.Images, from =>
                    from.MapFrom(src => GetUrl(src.PostImages)))
                .ForMember(dest => dest.Name, from =>
                    from.MapFrom(src => src.OpendBy.Name))
                .ForMember(dest => dest.Likes, from =>
                    from.MapFrom(src => src.Likes.Count != 0 ? src.Likes.Count(s=>s.Like):0))
                .ForMember(dest => dest.IsFollowed, from =>
                    from.MapFrom((src, dest, destMember, context) =>
                        src.Followers.Any(x => x.MemberId == Convert.ToInt32(context.Items["UserId"]))
                        && src.Followers.Single(x => x.MemberId == Convert.ToInt32(context.Items["UserId"])).Follow))
                .ForMember(dest => dest.IsLike, from =>
                    from.MapFrom((src, dest, destMember, context) => 
                        src.Likes.Any(x => x.MemberId == Convert.ToInt32(context.Items["UserId"]))
                        && src.Likes.Single(x => x.MemberId == Convert.ToInt32(context.Items["UserId"])).Like))
                .ForMember(dest => dest.Comments, from =>
                    from.MapFrom(src => src.Comments.Count))
                .ForMember(dest => dest.NewComments, from =>
                    from.MapFrom(src => src.Comments
                        .Count(x=>x.Views.Any(n=>n.IsRead && n.MemberId == src.OpnedId))))
                .ForMember(dest => dest.Date, from =>
                    from.MapFrom(src => src.CDate.ToString("yyyy-MM-dd hh:mm:ss tt")))
                .ForMember(dest => dest.Voice, from =>
                    from.MapFrom(src => src.Voice != null?GetVoice(src.Voice):null));

            CreateMap<Post_Master, TimelineViewDto>()
                .ForMember(dest => dest.Images, from =>
                    from.MapFrom(src => GetUrl(src.PostImages)))
                .ForMember(dest => dest.Date, from =>
                    from.MapFrom(src => src.CDate.ToString("yyyy-MM-dd hh:mm:ss tt")))
                .ForMember(dest => dest.Voice, from =>
                    from.MapFrom(src => src.Voice != null ? GetVoice(src.Voice) : null));

            CreateMap<Mem_Master, ProfileDetailViewDto>()
                .ForMember(dest => dest.UgCollegeName, o => o.MapFrom(s => s.UgCollege.UgCollegeName))
                .ForMember(dest => dest.ProfilePic, o => o.MapFrom(s => GetProfilePic(s.Photos.FirstOrDefault(x=>x.IsActive).Image)))
                .ForMember(dest => dest.BatchName, o => o.MapFrom(s => s.MainGroup.GroupName))
                .ForMember(dest => dest.DateOfBirth, o => o.MapFrom(s => s.DateOfBirth.ToString("dd-MMM-yyyy")))
                .ForMember(dest => dest.MaritalStatus, o => o.MapFrom(s => s.MaritalStatus))
                .ForMember(dest => dest.DistrictName, o => o.MapFrom(s => s.District.DistrictName))
                .ForMember(dest => dest.QualificationName, o => o.MapFrom(s => s.SpouseEducation.QualificationName))
                .ForMember(dest => dest.ChapterName, o => o.MapFrom(s => s.MembershipInGroups
                    .Where(x => x.GroupMaster.Type == GroupType.Chapter).OrderByDescending(x => x.GroupMaster.FormedOn)
                    .FirstOrDefault().GroupMaster.GroupName))
                .ForMember(des => des.SpouseAge, o => o.MapFrom(s => s.SpouseAge != null ? DateTime.Now.Year - s.SpouseAge.Value.Year : 0));

            CreateMap<Mem_EducationDetail, EducationDetailDto>()
                .ForMember(dest => dest.Qualification, o => o.MapFrom(s => s.Qualification.DegreeName))
                .ForMember(dest => dest.PassoutYear, o => o.MapFrom(s => s.PassoutYear.Year))
                .ForMember(dest => dest.University, o => o.MapFrom(s => s.University.UniversityName));

            CreateMap<Mem_ProjectWork, ProjectViewDto>();
            CreateMap<ProjectViewDto, Mem_ProjectWork>();

            CreateMap<Mem_WorkDetail, WorkDetailDto>()
                .ForMember(dest => dest.DateForm, o => o.MapFrom(s => s.DateForm.ToString("dd-MMM-yyyy")))
                .ForMember(dest => dest.DateUpto, o => o.MapFrom(s => s.DateUpto == null ? "" : s.DateUpto.Value.ToString("dd-MMM-yyyy")))
                .ForMember(dest => dest.Country, o => o.MapFrom(s => s.Country.CountryName))
                .ForMember(dest => dest.JobCategory, o => o.MapFrom(s => s.CategoryMaster.CategoryName));
        }


        private List<string> GetUrl(ICollection<Post_Image> images)
        {
            return images.Select(x => $"/Images/{x.Image}").ToList();
        }

        private string GetVoice(string url) => $"/Voice/{url}";

        private string GetProfilePic(string url) => $"/Profile/{url}";

        private string GetUrl(CommentType commentType,string src,DateTime date)
        {
            var folderName = date.ToString("yyyy-MM-dd");
            switch (commentType)
            {
                case CommentType.Image:
                    return $"/Images/{folderName}/{src}";
                case CommentType.Voice:
                    return $"/Voice/{folderName}/{src}";
                default:
                    return src;
            }
        }
    }
}