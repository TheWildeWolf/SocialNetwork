using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Data;
using Hadia.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Post.Controllers
{
    public class ReportsController : BasePostController
    {
        private readonly HadiaContext _db;
        private IMapper _mapper;
        public ReportsController(HadiaContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index(ReportsViewModel reportsView)
        {
            var listOfReports = await _db.Post_Reports.AsNoTracking()
                   .Include(x => x.PostMaster)
                   .Include(x => x.ReportedBy)
                 
                   .Include(x => x.ReportReason)
                   .Select(x => _mapper.Map<ReportsViewModel>(x)).ToListAsync();
            return View(listOfReports);
        }
        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            var ReportDetails = _db.Post_Reports
                .Include(s => s.PostMaster)
                .ThenInclude(t => t.PostImages)
                 .Include(s => s.PostMaster)
                 .ThenInclude(u => u.GroupMaster)
                .Include(p => p.ReportedBy)
                .Include(x => x.ReportReason)
                .Select(o => _mapper.Map<PostReportViewModel>(o))
                .FirstOrDefault(x => x.Id == id);
            return View(ReportDetails);
        }
        

        
        public async Task<ActionResult> Remove(int id)
        {
            var editData = await _db.Post_Masters.FirstOrDefaultAsync(x => x.Id == id);
            editData.Status = Models.DomainModels.PostStatus.Removed;
            editData.DDate = DateTime.Now;
            var userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            editData.DLogin = userId;
            editData.DeletedBy = userId;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}