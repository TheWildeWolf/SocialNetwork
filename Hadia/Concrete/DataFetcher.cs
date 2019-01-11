using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Areas.Login.Models;
using Hadia.Core;
using Hadia.Data;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Concrete
{
    public class DataFetcher :IDataFetcher
    {
        private readonly HadiaContext _db;
        private readonly IMapper _mapper;
        public DataFetcher(HadiaContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public int UserId { get; set; }
        public DateTime SyncTime { get; set; }


        public async Task<DateTime?> GetSyncTime()
        {
            var member = await _db.Mem_Masters.FindAsync(UserId);
            return SyncTime = member.SyncTime ?? DateTime.UtcNow.AddHours(-1);
        }

        public async Task<List<DataMemberDto>> GetMembers()
        {
            return await _db.Mem_Masters.AsNoTracking()
                 .AsNoTracking()
                 .Include(x=> x.Photos)
                   .Select(x => _mapper.Map<DataMemberDto>(x))
                   .ToListAsync();
            
        }

        public async Task<List<DataPostDto>> GetPosts()
        { 
                return await _db.Post_Masters
                    .AsNoTracking()
                    .Where(x => x.CDate > SyncTime)
                    .Select(x => _mapper.Map<DataPostDto>(x, opt => opt.Items.Add("UserId", UserId)))
                    .ToListAsync();
        }

        public async Task<List<DataPostImageDto>> GetPostImages()
        {
            return await _db.Post_Images
                .AsNoTracking()
                .Include(x => x.PostMaster)
                .Where(x => x.PostMaster.CDate > SyncTime)
                .Select(x => _mapper.Map<DataPostImageDto>(x))
                .ToListAsync();
        }

        public async Task<List<DataLikeDto>> GetLikes()
        {
            return await _db.Post_Likes
                .AsNoTracking()
                .Where(x=>x.CDate > SyncTime)
                .Select(x => _mapper.Map<DataLikeDto>(x))
                .ToListAsync();
        }

        public async Task<List<DataCommentDto>> GetComments()
        {
                return await _db.Post_Comments
                    .AsNoTracking()
                    .Include(x=>x.Views) 
                    .Where(x => x.Date > SyncTime)
                    .Select(x => _mapper.Map<DataCommentDto>(x))
                    .ToListAsync();
        }

        public Task SaveSyncTimeAsync()
        {
            throw new NotImplementedException();
        }
    }
}
