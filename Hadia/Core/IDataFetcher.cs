using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hadia.Areas.Login.Models;
using Hadia.Models.DomainModels;
using Hadia.Models.Dtos;

namespace Hadia.Core
{
    public interface IDataFetcher
    {
        int UserId { get; set; }
        DateTime SyncTime { get; set; }
        Task<DateTime?> GetSyncTime();
        Task<List<DataMemberDto>> GetMembers();
        Task<List<DataPostDto>> GetPosts();
        Task<List<DataPostImageDto>> GetPostImages();
        Task<List<DataLikeDto>> GetLikes();
        Task<List<DataCommentDto>> GetComments();
        Task SaveSyncTimeAsync();

    }
}
