using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Data;
using Hadia.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hadia.Models.DomainModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hadia.Areas.Member.Controllers
{
    public class MemberListController : BaseMemberController
    {
        private HadiaContext _db;
        private IMapper _mapper;
        public MemberListController(HadiaContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(MembersMasterViewModel memberMaster)
        {
            var ListOfMember = await _db.Mem_Masters
                 .Include(x => x.UgCollege)
                 .Include(x => x.MembershipInGroups)
                 .ThenInclude(x => x.GroupMaster)
                 .Include(x => x.MainGroup)
                 .Select(x => _mapper.Map<MemberViewModel>(x)).ToListAsync();
            memberMaster.BatchList = new SelectList(_db.Post_GroupMasters.Where(s => s.Type == GroupType.Batch), "Id", "GroupName");
            if (memberMaster.BatchId != null)
            {
                ListOfMember = ListOfMember.Where(s => s.GroupId == memberMaster.BatchId).ToList();
            }
            memberMaster.ChapterList = new SelectList(_db.Post_GroupMasters.Where(s => s.Type == GroupType.Chapter), "Id", "GroupName");
            if(memberMaster.ChapterId != null)
            {
                ListOfMember = ListOfMember.Where(s => s.ChapterId== memberMaster.ChapterId).ToList();
            }
            switch (memberMaster.Approval)
            {
                case "Approved":
                    {
                        ListOfMember = ListOfMember.Where(s => s.IsVarified).ToList();
                        break;
                    }
                case "Not Approved":
                    {
                        ListOfMember = ListOfMember.Where(s => !s.IsVarified).ToList();
                        break;
                    }
                default:
                    {
                        ListOfMember = ListOfMember.ToList();
                        break;
                    }
            }
          
            memberMaster.Approval = memberMaster.Approval ?? "All";
            memberMaster.Members = ListOfMember;
            return View(memberMaster);

        }
        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var  KidsLists = _db.Mem_Kids.Where(s => s.MemberId == id).ToList();
            var memViewModel = new MemberDetailsViewModel
            {
                Kids = KidsLists
            };
            var MemberDetails = await _db.Mem_Masters.Include(x => x.UgCollege).Include(x => x.MainGroup)
                .Include (x=>x.District)
                .Include (y=>y.Kids)
                 .Include(y => y.SpouseEducation)
                 .Include(x => x.EducationDetails)
                 .ThenInclude(x => x.Qualification)
                  .Include(x => x.EducationDetails)
                 .ThenInclude(x => x.University)
                 .Include(x=>x.WorkDetails)
                 .ThenInclude(x=>x.Country)
                .Select(x => _mapper.Map<MemberDetailsViewModel>(x))
                .FirstOrDefaultAsync(x => x.Id == id);
            return View(MemberDetails);
        }
        [HttpGet]
        public async Task<ActionResult> Approve(int? id)
        {
            var EditData = await _db.Mem_Masters.FirstOrDefaultAsync(x => x.Id == id);
            EditData.IsVarified = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}