using System.Threading.Tasks;
using Hadia.Controllers;
using Hadia.Data;
using Hadia.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace Hadia.Areas.Post.Apis
{
    public class PostController : BaseApiController
    {
        private HadiaContext _db;

        public PostController(HadiaContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            return Ok();
        }
    }
}