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
        private DateTime NextSync { get; set; }
        private bool IsNull { get; set; }
        public async Task<DateTime?> GetSyncTime()
        {
            var member = await _db.Mem_Masters.FindAsync(UserId);
            NextSync = DateTime.UtcNow;
            IsNull = member.SyncTime == null;
            return SyncTime = member.SyncTime ?? DateTime.UtcNow;
        }

        public async Task<List<DataMemberDto>> GetMembers(bool getAll = false,int id = 0)
        {
            if (IsNull || getAll)
            {
                return await _db.Mem_Masters
                    .AsNoTracking()
                    .Where(x => x.IsVarified)
                    .Include(x => x.Photos)
                    .Include(s => s.MembershipInGroups).ThenInclude(x => x.GroupMaster)
                    .Select(x => _mapper.Map<DataMemberDto>(x))
                    .ToListAsync();
            }
            if (id != 0)
            {
                return await _db.Mem_Masters
                    .AsNoTracking()
                    .Where(x => x.IsVarified && x.Id == id)
                    .Include(x => x.Photos)
                    .Include(s => s.MembershipInGroups).ThenInclude(x => x.GroupMaster)
                    .Select(x => _mapper.Map<DataMemberDto>(x))
                    .ToListAsync();
            }

            return await _db.Mem_Masters
                        .AsNoTracking()
                        .Where(x=>x.IsVarified && 
                                  (x.VarifiedDate > SyncTime 
                                  || x.MDate > SyncTime
                                  || x.Photos.FirstOrDefault(p=>p.IsActive).CDate > SyncTime)
                               )
                        .Include(x=> x.Photos)
                        .Include(s=>s.MembershipInGroups).ThenInclude(x => x.GroupMaster)
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
                    .Select(x => _mapper.Map<DataCommentDto>(x, opt => opt.Items.Add("UserId", UserId)))
                    .ToListAsync();
        }

        public async Task SaveSyncTimeAsync()
        {
            var member = await _db.Mem_Masters.FindAsync(UserId);
            member.SyncTime = NextSync;
            await _db.SaveChangesAsync();
        }
    }
}
