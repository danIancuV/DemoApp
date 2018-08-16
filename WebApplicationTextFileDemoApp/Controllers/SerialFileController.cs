using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DbCoreLibrary;
using DbCoreLibrary.DbServiceModel;

namespace WebApplicationTextFileDemoApp.Controllers
{
    public class SerialFileController : Controller
    {
        private readonly FileDbService _fileDbService = new FileDbService();      

        // GET: SerialFile
        public IActionResult Index()
        {
            List<SerialFileDto> fileList = _fileDbService.GetdBItems();

            return View(fileList);
        }

        // GET: SerialFile/Details/5
        public  IActionResult Details(int? id)
        {
            if (id == null)
            {
                return Content("File not found in DB!");
            }
            var fileDetailed = _fileDbService.GetDetails(id);

            return View(fileDetailed);
        }

        // GET: SerializedFile/Edit/5
        public IActionResult Edit(int? id)
        {

            var serialFileDto = _fileDbService.GetEdit(id);
            if (serialFileDto == null)
            {
                return NotFound();
            }
            return View(serialFileDto);

        }

        // POST: SerializedFile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,FileContent,Extension")] SerialFileDto serialFileDto)
        {
            var isEdited = _fileDbService.PerformEdit(id, serialFileDto);

            if (isEdited)
            {
                return RedirectToAction("Index");
            }

            else
            {
                return Content("File not edited");
            }
        }


        // GET: SerializedFile/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SerializedFile/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create([Bind("Id,Name,FileContent,Extension")] SerialFileDto serialFileDto)
        {
            var isCreated = _fileDbService.FileCreate(serialFileDto);

            if (isCreated)
            {
                return RedirectToAction("Index");
            }

            else
            {
                return Content("File not created");
            }     
        }


        // GET: SerialFile/Upload
        public IActionResult Upload()
        {
            return View();
        }


        //POST : SerialFile/Upload
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upload(string file)
        {
            bool isUploaded = _fileDbService.FileDbUpload(file);
            if (isUploaded)
            {
                return RedirectToAction("Index");
            }

            else
            {
                return Content("Please select a local file");
            }
        }


        //POST : SerialFile/Checkdelete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckDelete(List<int?> checkedIds)
        {

            bool isDeleted = _fileDbService.FileDelete(checkedIds);
            if (isDeleted)
            {
                return RedirectToAction("Index");
            }

            else
            {
                return Content("Please check at least one file");
            }
        }


        // GET: SerialFile/Download    
        public IActionResult Download()
        {
            List<SerialFileDto> fileList = _fileDbService.GetdBItems();

            return View(fileList);
        }


        //POST : SerialFile/Download
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Download(SerialFileDto serialFileDto)
        {

            bool isDownloaded = _fileDbService.FileDbDownload(serialFileDto);
            if (isDownloaded)
            {
                return Content("Please check at least one file");
            }

            else
            {
                return Content("Please check at least one file");
            }
        }
    }
}
