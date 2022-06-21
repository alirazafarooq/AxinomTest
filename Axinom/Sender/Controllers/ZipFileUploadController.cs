using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sender.Services;
using System.Collections.Generic;
using System.IO;

namespace Sender.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZipFileUploadController : Controller
    {
        private readonly IExtractZipService _extractZipService;
        public ZipFileUploadController(IExtractZipService extractZipService)
        {
            _extractZipService = extractZipService;
        }


        [HttpGet]
        public IActionResult Get() 
        {
            return Ok("File Uploading API is running ....");
        }

        [HttpPost]
        [Route("zipupload")]
        public IActionResult zipUpload(IFormFile[] files)
        {

            if (files.Length == 0)
                return BadRequest();

            foreach (var file in files)
            {
                if (file.ContentType.Equals("application/zip") || file.ContentType.Equals("application/x-zip-compressed"))
                {
                    _extractZipService.zipUpload(file);
                }
                else 
                {
                    return BadRequest();
                }
            }
            
           // _extractZipService.zipUpload(file);
            return Ok();
        }
    }
}
