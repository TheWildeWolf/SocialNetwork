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
    //        , string sortOrder,
    //string currentFilter,
    //string searchString,
    //int? page)
        {
            var listOfMember = await _db.Mem_Masters.AsNoTracking()
                 .Include(x => x.UgCollege)
                 .Include(x => x.MembershipInGroups)
                 .ThenInclude(x => x.GroupMaster)
                 .Include(x => x.MainGroup)
                 .Select(x => _mapper.Map<MemberViewModel>(x)).ToListAsync();
            memberMaster.BatchList = new SelectList(_db.Post_GroupMasters.Where(s => s.Type == GroupType.Batch), "Id", "GroupName");
            if (memberMaster.BatchId != null)
            {
                listOfMember = listOfMember.Where(s => s.GroupId == memberMaster.BatchId).ToList();
            }
            memberMaster.ChapterList = new SelectList(_db.Post_GroupMasters.Where(s => s.Type == GroupType.Chapter), "Id", "GroupName");
            if(memberMaster.ChapterId != null)
            {
                listOfMember = listOfMember.Where(s => s.ChapterId== memberMaster.ChapterId).ToList();
            }
            switch (memberMaster.Approval)
            {
                case "Approved":
                    {
                        listOfMember = listOfMember.Where(s => s.IsVarified).ToList();
                        break;
                    }
                case "Not Approved":
                    {
                        listOfMember = listOfMember.Where(s => !s.IsVarified).ToList();
                        break;
                    }
                default:
                    {
                        listOfMember = listOfMember.ToList();
                        break;
                    }
            }

            memberMaster.Approval = memberMaster.Approval ?? "All";
            memberMaster.Members = listOfMember;
            return View(memberMaster);
        }
        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var memberDetails = await _db.Mem_Masters.AsNoTracking()
                .Include(x => x.UgCollege)
                .Include(x => x.MainGroup)
                .Include(x => x.MembershipInGroups)
                       .ThenInclude(n=>n.GroupMaster)
                .Include(x=>x.District)
                .Include(y=>y.Kids)
                .Include(y => y.SpouseEducation)
                .Include(x => x.EducationDetails)
                    .ThenInclude(x => x.Qualification)
                .Include(x => x.EducationDetails)
                    .ThenInclude(x => x.University)
                .Include(x=>x.WorkDetails)
                    .ThenInclude(x=>x.Country)
                .Select(x => _mapper.Map<MemberDetailsViewModel>(x))
                .FirstOrDefaultAsync(x => x.Id == id);

            return View(memberDetails);
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