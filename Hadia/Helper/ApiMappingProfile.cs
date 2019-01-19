using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Hadia.Areas.Login.Models;
using Hadia.Models;
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
                .ForMember(dest => dest.Ago, from =>
                    from.MapFrom(src => src.Date.ToStringDate()))
                .ForMember(dest => dest.ProfilePhoto, from =>
                    from.MapFrom(src => src.Createdby.Photos != null && src.Createdby.Photos.Any() ? "/Profile/" +src.Createdby.Photos.Single(x=>x.IsActive).Image :""))
                .ForMember(dest => dest.Replies, from =>
                    from.MapFrom(src => src.PostComments))
                .ForMember(dest => dest.Comment, from =>
                    from.MapFrom(src => GetUrl(src.Type, src.Comment)));

            CreateMap<Post_Comment, CommentReplayDto>()
                .ForMember(dest => dest.Name, from =>
                    from.MapFrom(src => src.Createdby.Name))
                .ForMember(dest => dest.Text, from =>
                    from.MapFrom(src => GetUrl(src.Type, src.Comment)));

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
                    from.MapFrom((src, dest, destMember, context) => src.Comments
                        .Count(x => x.Views.Any() && x.Views.Any(n => !n.IsRead && n.MemberId == Convert.ToInt32(context.Items["UserId"])))))
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

            CreateMap<ProfileSaveDto, Mem_Master>()
                .ForMember(dest => dest.MaritalStatus, o => o.MapFrom(s => s.MaritalStatusId));

        

            CreateMap<Mem_Master, ProfileDetailViewDto>()
                .ForMember(dest => dest.UgCollegeName, o => o.MapFrom(s => s.UgCollege.UgCollegeName))
                .ForMember(dest => dest.ProfilePic, o => o.MapFrom(s => GetProfilePic(s.Photos.FirstOrDefault(x=>x.IsActive).Image)))
                .ForMember(dest => dest.BatchName, o => o.MapFrom(s => s.MainGroup.GroupName))
                .ForMember(dest => dest.DateOfBirth, o => o.MapFrom(s => s.DateOfBirth.ToString("dd-MMM-yyyy")))
                .ForMember(dest => dest.MaritalStatus, o => o.MapFrom(s => s.MaritalStatus))
                .ForMember(dest => dest.Projects, o => o.MapFrom(s => s.Projects))
                .ForMember(dest => dest.DistrictName, o => o.MapFrom(s => s.District.DistrictName))
                .ForMember(dest => dest.StateName, o => o.MapFrom(s => s.District.State.StateName))
                .ForMember(dest => dest.QualificationName, o => o.MapFrom(s => s.SpouseEducation.QualificationName))
                .ForMember(dest => dest.ChapterName, o => o.MapFrom(s => s.MembershipInGroups
                    .Where(x => x.GroupMaster.Type == GroupType.Chapter).OrderByDescending(x => x.GroupMaster.FormedOn)
                    .FirstOrDefault().GroupMaster.GroupName))
                .ForMember(des => des.SpouseAge, o => o.MapFrom(s => s.SpouseAge != null ? DateTime.Now.Year - s.SpouseAge.Value.Year : 0));

            CreateMap<Mem_EducationDetail, EducationDetailDto>()
                .ForMember(dest => dest.Qualification, o => o.MapFrom(s => s.Qualification.DegreeName))
                .ForMember(dest => dest.PassoutYear, o => o.MapFrom(s => s.PassoutYear.Year))
                .ForMember(dest => dest.University, o => o.MapFrom(s => s.University.UniversityName));
            CreateMap<EducationDetailEditDto,Mem_EducationDetail>()
                .ForMember(dest => dest.EducationQualificationId, o => o.MapFrom(s => s.QualificationId))
                .ForMember(dest => dest.PassoutYear, o => o.MapFrom(s => new DateTime(s.PassoutYear, 1, 1)))
                .ForMember(dest => dest.UniversityId, o => o.MapFrom(s => s.UniversityId));

            CreateMap<Mem_ProjectWork, ProjectViewDto>()
                .ForMember(dest => dest.Description, o => o.MapFrom(s => s.Description))
                .ForMember(dest => dest.ProjectTitle, o => o.MapFrom(s => s.ProjectTitle));

            CreateMap<ProjectViewDto, Mem_ProjectWork>();

            CreateMap<Mem_WorkDetail, WorkDetailDto>()
                .ForMember(dest => dest.DateForm, o => o.MapFrom(s => s.DateForm.ToString("dd-MMM-yyyy")))
                .ForMember(dest => dest.DateUpto, o => o.MapFrom(s => s.DateUpto == null ? "" : s.DateUpto.Value.ToString("dd-MMM-yyyy")))
                .ForMember(dest => dest.Country, o => o.MapFrom(s => s.Country.CountryName))
                .ForMember(dest => dest.JobCategory, o => o.MapFrom(s => s.CategoryMaster.CategoryName));

            CreateMap<Mem_Photo,MemberPhotoDto>();
            //Data Fetch Mappers
            CreateMap<Post_Comment, DataCommentDto>()
                .ForMember(dest => dest.ImageOnline, o => o.MapFrom(x => GetUrl(x.Type, x.Comment,CommentType.Image)))
                .ForMember(dest => dest.VoiceOnline, o => o.MapFrom(x => GetUrl(x.Type, x.Comment, CommentType.Voice)))
                .ForMember(dest => dest.Read, o => o.MapFrom((src, dest, destMember, context) =>
                    src.Views != null &&
                    src.Views.Any(x => x.MemberId == Convert.ToInt32(context.Items["UserId"]))
                    && src.Views.Single(x => x.MemberId == Convert.ToInt32(context.Items["UserId"])).IsRead))
                .ForMember(des => des.Text, o => o.MapFrom(x => GetUrl(x.Type, x.Comment, CommentType.Text)))
                .ForMember(des => des.Date, o => o.MapFrom(x => x.Date.ToString("yyyy-MM-dd HH:mm:ss")));
                 
            CreateMap<Post_Like, DataLikeDto>();
            CreateMap<Post_Image, DataPostImageDto>()
                .ForMember(dest => dest.ImageOnline, o => o.MapFrom(x => GetUrl(CommentType.Image, x.Image)));

            CreateMap<Mem_Master, DataMemberDto>()
                .ForMember(dest => dest.Photo,
                    o => o.MapFrom(x => (x.Photos.Any() && x.Photos != null) ? x.Photos.Single(p => p.IsActive).Image : ""))
                .ForMember(dest => dest.BatchId, o => o.MapFrom(x => x.GroupId))
                .ForMember(dest => dest.ChapterId, o => o.MapFrom(x => x.MembershipInGroups.FirstOrDefault(s => s.IsActive && s.GroupMaster.Type == GroupType.Chapter).GroupId));

            CreateMap<Mem_Master, MemberSearchDto>()
                .ForMember(dest => dest.Photo,
                    o => o.MapFrom(x => x.Photos.Any() && x.Photos != null ? x.Photos.FirstOrDefault(p => p.IsActive).Image : ""))
                .ForMember(dest => dest.BatchId, o => o.MapFrom(x => x.GroupId))
                .ForMember(dest => dest.ChapterId, o => o.MapFrom(x => x.MembershipInGroups.FirstOrDefault(s => s.IsActive && s.GroupMaster.Type == GroupType.Chapter).GroupId))
                .ForMember(dest => dest.BatchName, o => o.MapFrom(x => x.MainGroup.GroupName))
                .ForMember(dest => dest.ChapterName, o => o.MapFrom(x => x.MembershipInGroups.FirstOrDefault(s => s.IsActive && s.GroupMaster.Type == GroupType.Chapter).GroupMaster.GroupName))
                .ForMember(dest => dest.UgCollege, o => o.MapFrom(x => x.UgCollege.UgCollegeName))
                .ForMember(dest => dest.Phone, o => o.MapFrom(x => x.Phone));

            CreateMap<Post_Master, DataPostDto>()
                .ForMember(dest => dest.Following, from =>
                    from.MapFrom((src, dest, destMember, context) =>
                        src.Followers != null&&
                        src.Followers.Any(x => x.MemberId == Convert.ToInt32(context.Items["UserId"]))
                        && src.Followers.Single(x => x.MemberId == Convert.ToInt32(context.Items["UserId"])).Follow))
                .ForMember(dest => dest.VoiceOnline, o => o.MapFrom(x => x.Voice == null ? null : GetVoice(x.Voice)))
                .ForMember(dest => dest.Type, o => o.MapFrom(x => x.CategoryId))
                .ForMember(dest => dest.Images, o => o.MapFrom(x => x.PostImages))
                .ForMember(dest => dest.MemberId, o => o.MapFrom(x => x.OpnedId))
                .ForMember(dest => dest.Date, o => o.MapFrom(x => x.CDate.ToString("yyyy-MM-dd HH:mm:ss")));

            CreateMap<Mem_ProjectWork, ProjectworkDto>();
            CreateMap<ProjectworkDto,Mem_ProjectWork> ();
        }


        private List<string> GetUrl(ICollection<Post_Image> images)
        {
            return images.Select(x => $"/Images/{x.Image}").ToList();
        }

        private string GetVoice(string url) => $"/Voice/{url}";

        private string GetProfilePic(string url) => $"/Profile/{url}";

        private string GetUrl(CommentType commentType, string src, CommentType currentType)
        {
            if (commentType != currentType)
                return null;
            switch (commentType)
            {
                case CommentType.Image:
                    return $"/Images/{src}";
                case CommentType.Voice:
                    return $"/Voice/{src}";
                default:
                    return src;
            }
        }
        private string GetUrl(CommentType commentType,string src)
        {
            if (string.IsNullOrEmpty(src))
                return "";
            switch (commentType)
            {
                case CommentType.Image:
                    return $"/Images/{src}";
                case CommentType.Voice:
                    return $"/Voice/{src}";
                default:
                    return src;
            }
        }
    }
}