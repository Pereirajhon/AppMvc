using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AppMvc.Data;
using AppMvc.Models;

namespace AppMvc.Controllers
{
    public class IphoneController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IphoneController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Iphone
        public async Task<IActionResult> Index()
        {
            return View(await _context.Iphones.ToListAsync());
        }

        // GET: Iphone/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iphone = await _context.Iphones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iphone == null)
            {
                return NotFound();
            }

            return View(iphone);
        }

        // GET: Iphone/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Iphone/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model,ImagemUpload,Price")] Iphone iphone)
        {
            if (ModelState.IsValid)
            {
                var imgPrefixo = Guid.NewGuid() + "_";

                if (!await UploadImage(iphone.ImagemUpload, imgPrefixo)){
                    return View(iphone);
                }
                // Inicializa a lista de iPhones se for nula
                iphone.Imagem = imgPrefixo + iphone.ImagemUpload;

                _context.Add(iphone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iphone);
        }

        // GET: Iphone/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iphone = await _context.Iphones.FindAsync(id);
            if (iphone == null)
            {
                return NotFound();
            }
            return View(iphone);
        }

        // POST: Iphone/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Model,ImagemUpload,Price")] Iphone iphone)
        {
            if (id != iphone.Id)
            {
                return NotFound();
            }

            var iphonedb = await _context.Iphones.AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);

            if (ModelState.IsValid)
            {
                try
                {
                    iphone.Imagem = iphonedb.Imagem;
                    if(iphone.ImagemUpload != null)
                    {
                        var imgPrefixo = Guid.NewGuid() + "_";
                        if(!await UploadImage(iphone.ImagemUpload, imgPrefixo))
                        {
                            return View(iphone);
                        }
                        iphone.Imagem = imgPrefixo + iphone.ImagemUpload.FileName;
                    }
                    _context.Update(iphone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IphoneExists(iphone.Id))
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
            return View(iphone);
        }

        // GET: Iphone/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iphone = await _context.Iphones
                .FirstOrDefaultAsync(m => m.Id == id);
            if (iphone == null)
            {
                return NotFound();
            }

            return View(iphone);
        }

        // POST: Iphone/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iphone = await _context.Iphones.FindAsync(id);
            if (iphone != null)
            {
                _context.Iphones.Remove(iphone);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<bool> UploadImage(IFormFile arquivo, string imgPrefixo)
        {
            if (arquivo.Length <= 0) return false;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/image", imgPrefixo = arquivo.FileName);

            if (System.IO.File.Exists(path))
            {
                ModelState.AddModelError(string.Empty, "Já existe um arquivo com este nome !");
                return false;
            }

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await arquivo.CopyToAsync(stream);
            }
            return true;
        }


        private bool IphoneExists(int id)
        {
            return _context.Iphones.Any(e => e.Id == id);
        }
    }
}
