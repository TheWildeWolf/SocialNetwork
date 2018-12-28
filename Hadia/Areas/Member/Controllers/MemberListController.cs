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
using Hadia.Helper;

namespace Hadia.Areas.Member.Controllers
{
    public class MemberListController : BaseMemberController
    {
        private readonly HadiaContext _db;
        private IMapper _mapper;
        public MemberListController(HadiaContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(MembersMasterViewModel memberMaster,int? page)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(memberMaster.SortOrder) ? "name_desc" : "";
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
            memberMaster.ChapterList = new SelectList(_db.Post_GroupMasters.Where(s => s.Type == GroupType.Chapter).OrderBy(x=>x.GroupName), "Id", "GroupName");
            if(memberMaster.ChapterId != null)
            {
                listOfMember = listOfMember.Where(s => s.ChapterId== memberMaster.ChapterId).ToList();
            }
            if (!string.IsNullOrEmpty(memberMaster.Name))
                listOfMember = listOfMember.Where(n => (n.Name).Replace(" ", "").ToUpper().Contains(memberMaster.Name.Replace(" ", "").ToUpper())).ToList();
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

            int i = 1;
            foreach (var item in listOfMember)
            {
                item.Sn=i;
                i++;
            }
            memberMaster.Approval = memberMaster.Approval ?? "All";
            memberMaster.Members = PaginatedList<MemberViewModel>.Create(listOfMember, page ?? 1, 100);
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
        public async Task<IActionResult> Delete(int id)
        {
            var DelData = await _db.Mem_Masters.FindAsync(id);
            _db.Mem_Masters.Remove(DelData);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> EditProfile(int? id)
        {
            var data = await _db.Mem_Masters
                  .Include(x => x.MembershipInGroups)
                     .ThenInclude(n => n.GroupMaster)
                  .Include(X => X.UgCollege)
                     .FirstOrDefaultAsync(x => x.Id == id);
            
            var profile = _mapper.Map<ProfileEditViewModel>(data);
            profile.BatchList = 
                new SelectList(_db.Post_GroupMasters
                .Where(x=>x.Type ==GroupType.Batch).ToList(), "Id", "GroupName", profile.GroupId);

            profile.ChapterList =
                new SelectList(_db.Post_GroupMasters
                .ToList(), "Id", "GroupName", profile.ChapterId);
            profile.UgCollegeList =
                new SelectList(_db.Mem_UgColleges.ToList(),"Id", "UgCollegeName", profile.UgCollageId);
            return PartialView("_ProfileEdit", profile);
        }
        [HttpPost]
        //public async Task<IActionResult> EditProfile(int id,  districtMaster)
        //{
        //    if (id != districtMaster.Id)
        //    {
        //        return NotFound();
        //    }
        //    if (_db.Mem_DistrictMasters.Any(x => x.DistrictName == districtMaster.DistrictName && x.Id != districtMaster.Id))
        //    {
        //        ModelState.AddModelError("DistrictName", "District Name Already Exist");

        //    }
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            //View model to DomainModel
        //            var dataInDb = _db.Mem_DistrictMasters.Find(id);
        //            var editMaster = _mapper.Map(districtMaster, dataInDb);
        //            await _db.SaveChangesAsync();
        //            return RedirectToAction(nameof(Index));
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            throw;
        //        }

        //    }
        //    return View(districtMaster);
        //}
        public async Task<IActionResult> EditEducationalQualif(int? id)
        {
            return View();
        }
        public async Task<IActionResult> DeleteEducationalQualif(int? id)
        {
            return View();
        }
        public async Task<IActionResult> EditFamily(int? id)
        {
            return View();
        }
        public async Task<IActionResult> DeleteFamily(int? id)
        {
            return View();
        }
        public async Task<IActionResult> EditWorkDetails(int? id)
        {
            return View();
        }
        public async Task<IActionResult> DeleteWorkDetails(int? id)
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> Approve(int? id,bool isActive)
        {
            var editData = await _db.Mem_Masters.FirstOrDefaultAsync(x => x.Id == id);
            editData.IsVarified = isActive;
            await _db.SaveChangesAsync();
            TempData["message"] = Notifications.NormalNotify(isActive ? "Approved " + editData.Name +" Successfully.": "Approval of " +editData.Name+" Cancelled.");
            return RedirectToAction("Index");
        }
      
    }
}