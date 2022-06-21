using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Reciever.Models;
using Reciever.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reciever.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ZipFileContentController : Controller
    {
        private IArchiveRepository _archiverepository;
        public ZipFileContentController(IArchiveRepository archiverepository)
        {
            _archiverepository = archiverepository;
        }
       
        [HttpPost]
        [Route("filecontent")]
        
        public async Task<ActionResult> ZipFileContent(List<Archive> fileContent)
        {
            await _archiverepository.Create(fileContent);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var files = await _archiverepository.GetAll();
            ViewBag.files = files;
            return View();
        }

    }

    

    

    //public class Entry
    //{
    //    public long Crc32 { get; set; }
    //    public int CompressedLength { get; set; }
    //    public int ExternalAttributes { get; set; }
    //    public string FullName { get; set; }
    //    public DateTime LastWriteTime { get; set; }
    //    public int Length { get; set; }
    //    public string Name { get; set; }
    //}

}
