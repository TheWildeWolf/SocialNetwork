using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Data;
using Hadia.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Member.Controllers
{
    public class MemberListController :BaseMemberController
    {
        private HadiaContext _db;
        private IMapper _mapper;
        public MemberListController(HadiaContext context, IMapper mapper)
        {
            _db = context;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var ListOfMember = await _db.Mem_Masters
                 .Include(x => x.UgCollege).Include(x=>x.MainGroup)
                 .Select(x => _mapper.Map<MemberViewModel>(x)).ToListAsync();
            return View(ListOfMember);
        }
    }
}