using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Hadia.Areas.Post.Controllers
{
    public class BatchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {

        }
    }
}