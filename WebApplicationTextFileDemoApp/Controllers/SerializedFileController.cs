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
using WebApplicationTextFileDemoApp.Models;

namespace WebApplicationTextFileDemoApp.Controllers
{
    public class SerializedFileController : Controller
    {
        private readonly WebApplicationTextFileDemoAppContext _context;
        private readonly FileDbService _fileDbService = new FileDbService();
    
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

        //POST : SerializedFile/Multipledelete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToActionResult CheckDelete(IEnumerable<int> ids)
        {
            List<SerializedFileDto> dtoCheckedFileList = _context.SerializedFile.Where(x => ids.Contains(x.Id)).ToList();
            List<SerializedFile> checkedFileList = new List<SerializedFile>();
            
            foreach (SerializedFileDto serializedFileDto in dtoCheckedFileList)
            {
                SerializedFile serializedFile = SerializedFileDto.MapTo(serializedFileDto);
                checkedFileList.Add(serializedFile);
            }

            _fileDbService.FileDelete(checkedFileList);
            return RedirectToAction(nameof(Index));
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
