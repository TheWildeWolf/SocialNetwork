using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Areas.Login.Models;
using Hadia.Controllers;
using Hadia.Core;
using Hadia.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hadia.Areas.Login.Api
{
    public class DataController : BaseApiController
    {
        private IDataFetcher _dataFetcher;
        public DataController(IDataFetcher dataFetcher)
        {
            _dataFetcher = dataFetcher;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _dataFetcher.UserId = UserId;
            await _dataFetcher.GetSyncTime();
            DataMainDto dataMaster =new DataMainDto();
            dataMaster.members = await _dataFetcher.GetMembers();
            dataMaster.posts = await _dataFetcher.GetPosts();
            dataMaster.postImages = await _dataFetcher.GetPostImages();
            dataMaster.comments = await _dataFetcher.GetComments();
            dataMaster.likes = await _dataFetcher.GetLikes();
            await _dataFetcher.SaveSyncTimeAsync();
            return Ok(dataMaster);
        }
    }
}