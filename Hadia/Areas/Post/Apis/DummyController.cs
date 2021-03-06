﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Hadia.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hadia.Areas.Post.Apis
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    [ApiController]
    public class DummyController : ControllerBase
    {
        private IHostingEnvironment _hostingEnvironment;
        private INotification _notification;
        public DummyController(IHostingEnvironment hostingEnvironment, INotification notification)
        {
            _hostingEnvironment = hostingEnvironment;
            _notification = notification;
        }

        [HttpGet]
        public async Task Get()
        {
            await _notification.Notify(2, "Test", "Checking");
        }

        [HttpPost]
        public async Task Upload([FromForm]MainForm form)
        {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "ChapterImages");
            foreach (var item in form.PostImages)
            {
                if (item.Length > 0)
                {

                    var filePath = Path.Combine(uploads, DateTime.Now.ToFileTime()+".jpg");
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await item.CopyToAsync(fileStream);
                    }
                }
            }
            var voicePath = Path.Combine(uploads, DateTime.Now.ToFileTime() + "_voice.m4a");
            using (var fileStream = new FileStream(voicePath, FileMode.Create))
            {
                await form.Voice.CopyToAsync(fileStream);
            }
        }
    }

    public class MainForm
    {
        public List<IFormFile> PostImages { get; set; }
        public IFormFile Voice { get; set; }
        public string Topic { get; set; }
    }
}