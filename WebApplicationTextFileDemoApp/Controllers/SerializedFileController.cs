using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FileClassLibrary;
using FileClassLibrary.FileServiceModel;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using WebApplicationTextFileDemoApp.Data;
using WebApplicationTextFileDemoApp.Models;

namespace WebApplicationTextFileDemoApp.Controllers
{
    public class SerializedFileController : Controller
    {
        private readonly WebApplicationTextFileDemoAppContext _context;
        private readonly FileDbService _fileDbService = new FileDbService();
        private readonly FileSerialization _fileSerialization = new FileSerialization();


        public SerializedFileController(WebApplicationTextFileDemoAppContext context)
        {
            _context = context;
        }

        // GET: SerializedFile
        public async Task<IActionResult> Index()
        {
            return View(await _context.SerializedFile.ToListAsync());
        }

        // GET: SerializedFile/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serializedFile = await _context.SerializedFile
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serializedFile == null)
            {
                return NotFound();
            }

            return View(serializedFile);
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
        public async Task<IActionResult> Create([Bind("Id,Name,FileContent,Extension")] SerializedFileDto serializedFile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(serializedFile);
                await _context.SaveChangesAsync();

                _fileDbService.FileLocalCreate(serializedFile);

                return RedirectToAction(nameof(Index));
            }
            return View(serializedFile);
        }

        // GET: SerializedFile/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serializedFile = await _context.SerializedFile.FindAsync(id);
            if (serializedFile == null)
            {
                return NotFound();
            }
            return View(serializedFile);
        }

        // POST: SerializedFile/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,FileContent,Extension")] SerializedFileDto serializedFile)
        {
            if (id != serializedFile.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serializedFile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SerializedFileExists(serializedFile.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(serializedFile);
        }

        public IActionResult MyAction(string submitButton, IEnumerable<int> ids, IEnumerable<FileExtEnum> ext)
        {
            switch (submitButton)
            {
                case "CheckDelete":
                    return CheckDelete(ids);
                case "DbDownload":
                    return DbDownload(ids, ext);
                default:
                    return (View("Index"));
            }
        }

        //Post : SerializedFile/DbDownload
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DbDownload(IEnumerable<int> ids, IEnumerable<FileExtEnum> ext)
        {
            List<SerializedFileDto> dtoCheckedFileList = _context.SerializedFile.Where(x => ids.Contains(x.Id)).ToList();
            List<SerializedFile> checkedFileList = new List<SerializedFile>();

            foreach (SerializedFileDto serializedFileDto in dtoCheckedFileList)
            {
                SerializedFile serializedFile = SerializedFileDto.MapTo(serializedFileDto);
                serializedFile.Extension = "." + ext.ToString();
                checkedFileList.Add(serializedFile);
            }

            if (checkedFileList.Count == 0)
            {
                return RedirectToAction("CheckDelete");
            }

            if (checkedFileList.Count == 1)
            {

                //int checkedItemIndex = fileGridView.SelectedCells[0].RowIndex;
                //DataGridViewRow selectedRow = fileGridView.Rows[checkedItemIndex];

                //var checkedItem = Convert.ToString(selectedRow.Cells["FileName"].Value);
                //var checkedExt = "." + Convert.ToString(selectedRow.Cells["DownloadFormat"].Value);

                //var db = new FiledbEntities();
                //var checkedItemContent = db.SerializedFiles.FirstOrDefault(x =>
                //    x.Name == checkedItem)?.FileContent;

                //SerializedFile file = _fileSerialization.CreateFile(SerializedFile., checkedExt, checkedItemContent);

                switch (ext)
                {
                    //case FileExtEnum.xml:
                    //    _fileSerialization.XmlSerializeToFile(SerializedFileDto.MapTo(checkedFileList[0]));

                    //case ".json":
                    //    _fileSerialization.JsonSerializeToFile(SerializedFileDto.MapTo(file));
                    //    MessageBox.Show(@"Json serialized file downloaded");
                    //    break;
                    //case ".bin":
                    //    _fileSerialization.BinarySerializeToFile(SerializedFileDto.MapTo(file));
                    //    MessageBox.Show(@"Bin serialized file downloaded");
                    //    break;
                    //default:
                    //    MessageBox.Show(@"Please select a format to download");
                    //    break;
                }
                return RedirectToAction("CheckDelete");
            }

            return RedirectToAction("CheckDelete");
        }


        //POST : SerializedFile/Multipledelete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CheckDelete(IEnumerable<int> ids)
        {
            List<SerializedFileDto> dtoCheckedFileList =   _context.SerializedFile.Where(x => ids.Contains(x.Id)).ToList();
            List<SerializedFile> checkedFileList = new List<SerializedFile>();
            
            foreach (SerializedFileDto serializedFileDto in dtoCheckedFileList)
            {
                SerializedFile serializedFile = SerializedFileDto.MapTo(serializedFileDto);
                checkedFileList.Add(serializedFile);
            }

             _fileDbService.FileDelete(checkedFileList);
            
            return View();
        }



        // GET: SerializedFile/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serializedFile = await _context.SerializedFile
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serializedFile == null)
            {
                return NotFound();
            }

            return View(serializedFile);
        }

        // POST: SerializedFile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var serializedFile = await _context.SerializedFile.FindAsync(id);
            _context.SerializedFile.Remove(serializedFile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SerializedFileExists(int id)
        {
            return _context.SerializedFile.Any(e => e.Id == id);
        }
    }
}
