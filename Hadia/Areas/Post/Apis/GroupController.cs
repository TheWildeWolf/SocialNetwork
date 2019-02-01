using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Controllers;
using Hadia.Data;
using Hadia.Models.DomainModels;
using Hadia.Models.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Post.Apis
{
    public class GroupController : BaseApiController
    {
        private HadiaContext _db;
        private IHostingEnvironment _hostingEnvironment;
        private IMapper _mapper;

        public GroupController(
            HadiaContext db,
            IHostingEnvironment hostingEnvironment,
            IMapper mapper)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
        }

        [HttpGet("/api/groups")]
        public async Task<IActionResult> All()
        {
          var listOfGroups = await _db.Post_GroupMasters
                                  .Include(x => x.GroupMembers)
                                  .Where(x => x.GroupMembers.Any(n=>n.MemberId == UserId && n.IsActive && n.GroupMaster.Type == GroupType.Group))
                                  .OrderByDescending(x=>x.CDate)
                                  .Select(x => _mapper.Map<GroupResultDto>(x,n=> n.Items.Add("UserId", UserId)))
                                  .ToListAsync();
            return Ok(listOfGroups);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateGroupDto newGroup)
        {
            var imageName = string.Empty;
            var imageUploadPath = Path.Combine(_hostingEnvironment.WebRootPath, "Media/GroupImage/");
            try
            {
                if (newGroup.Image != null && newGroup.Image.Length > 0)
                {
                    string extension = Path.GetExtension(newGroup.Image.FileName);
                    imageName = DateTime.Now.ToFileTime() + "_" + UserId + extension;
                    var filePath = Path.Combine(imageUploadPath, imageName); //Path.Combine(imageUploadPath, DateTime.Now.ToFileTime()+"_"+ userid + extension);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await newGroup.Image.CopyToAsync(fileStream);
                    }
                }
                var groupMaster = new Post_GroupMaster
                {
                    CDate = DateTime.UtcNow,
                    CLogin = UserId,
                    Description = newGroup.Description,
                    FormedOn = DateTime.UtcNow,
                    OpenOrClosed = newGroup.OpenOrClosed,
                    Type = GroupType.Group,
                    GroupImage = imageName,
                    GroupName = newGroup.GroupName,
                    GroupMembers = new List<Post_GroupMember>()
                };
                if (newGroup.Members.Any())
                {
                    foreach (var memberId in newGroup.Members)
                    {
                        groupMaster.GroupMembers.Add(new Post_GroupMember
                        {
                            AddedBy = UserId,
                            CDate = DateTime.UtcNow,
                            IsActive = true,
                            IsGroupAdmin = false,
                            MemberId = memberId
                        });
                    }

                }
                groupMaster.GroupMembers.Add(new Post_GroupMember
                {
                    AddedBy = UserId,
                    CDate = DateTime.UtcNow,
                    IsActive = true,
                    IsGroupAdmin = true,
                    MemberId = UserId
                });
                await _db.Post_GroupMasters.AddAsync(groupMaster);

                await _db.SaveChangesAsync();
                return Ok(new GroupResultDto
                {
                    Id = groupMaster.Id,
                    Name = groupMaster.GroupName,
                    Discription = groupMaster.Description,
                    Image = groupMaster.GroupImage
                });

            }
            catch (Exception e)
            {
                throw e;
            }

        }
        [HttpGet]
        public async Task<IActionResult> Members(int id)
        {
            var members = await _db.Post_GroupMembers.AsNoTracking()
                            .Include(x => x.Member)
                                .ThenInclude(x => x.Photos)
                            .Where(x => x.GroupId == id && x.IsActive)
                            .Select(x => _mapper.Map<GroupMemberDto>(x)).ToListAsync();
            return Ok(members);
        }
        [HttpPost]
        public async Task<IActionResult> AddMember(AddMemberDto member)
        {
            if(_db.Post_GroupMembers.Any(x=>x.MemberId == member.MemberId))
            {
                var oldMember =await _db.Post_GroupMembers.SingleOrDefaultAsync(x => x.MemberId == member.MemberId);
                oldMember.IsActive = true;
                _db.Update(oldMember);
            }
            else
            {
                await _db.Post_GroupMembers.AddAsync(new Post_GroupMember
                {
                    MemberId = member.MemberId,
                    GroupId = member.GroupId,
                    AddedBy = UserId,
                    CDate = DateTime.UtcNow,
                    IsActive = true
                });
            }
            try
            {
                await _db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpGet]
        public async Task<IActionResult> MakeAdmin(int memberId, int groupId)
        {
            var memberInDb = await _db.Post_GroupMembers
                        .SingleOrDefaultAsync(x => x.MemberId == memberId && x.GroupId == groupId);
            memberInDb.IsGroupAdmin = true;
            _db.Update(memberInDb);
            try
            {
                await _db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpGet]
        public async Task<IActionResult> Deactive(int memberId, int groupId)
        {
            var memberInDb = await _db.Post_GroupMembers
                .SingleOrDefaultAsync(x => x.MemberId == memberId && x.GroupId == groupId);
            memberInDb.IsActive = false;
            _db.Update(memberInDb);
            try
            {
                await _db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(GroupEditDto groupEdit)
        {
            var groupInDb =await _db.Post_GroupMasters.FindAsync(groupEdit.GroupId);
            var imageName = string.Empty;
            var imageUploadPath = Path.Combine(_hostingEnvironment.WebRootPath, "Media/GroupImage/");
            if (groupEdit.Image != null && groupEdit.Image.Length > 0)
            {

                string extension = Path.GetExtension(groupEdit.Image.FileName);
                imageName = DateTime.Now.ToFileTime() + "_" + UserId + extension;
                var filePath = Path.Combine(imageUploadPath, imageName); //Path.Combine(imageUploadPath, DateTime.Now.ToFileTime()+"_"+ userid + extension);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await groupEdit.Image.CopyToAsync(fileStream);
                }
            }
            return Ok();
        }
    }
}