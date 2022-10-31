using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TermasApp.Data;
using TermasApp.IRepository;
using TermasApp.Models;

namespace TermasApp.Controllers
{
    public class AquistasController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IAquistaRepository _aquistaRepository;
        public AquistasController(IWebHostEnvironment webHostEnvironment, 
                                IAquistaRepository aquistaRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            _aquistaRepository = aquistaRepository;
        }

        // GET: Aquistas
        public async Task<IActionResult> Index()
        {
              return View(await _aquistaRepository.GetAllAquista());
        }

        // GET: Aquistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aquista = await _aquistaRepository.GetAquistaById(id);
            if (aquista == null)
            {
                return NotFound();
            }

            return View(aquista);
        }

        // GET: Aquistas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aquistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AquistaModel aquista)
        {
            if (ModelState.IsValid)
            {
                if (aquista.Foto != null)
                {
                    string folder = "images/aquistas/";
                    aquista.FotoSrc = await UploadImage(folder, aquista.Foto);
                }
                int Id = await _aquistaRepository.AddNewAquista(aquista);

                return RedirectToAction("Details", new { Id });
            }
            return View(aquista);
        }

        // GET: Aquistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aquista = await _aquistaRepository.GetAquistaById(id);
            if (aquista == null)
            {
                return NotFound();
            }
            return View(aquista);
        }

        // POST: Aquistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, AquistaModel aquista)
        {
            if (id != aquista.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (aquista.Foto != null)
                {
                    string folder = "images/aquistas/";
                    aquista.FotoSrc = await UploadImage(folder, aquista.Foto);
                }
                try
                {

                    await _aquistaRepository.UpdateAquista(aquista);
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(aquista);
        }

        // GET: Aquistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aquista = await _aquistaRepository.GetAquistaById(id);
            if (aquista == null)
            {
                return NotFound();
            }

            return View(aquista);
        }

        // POST: Aquistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
        
            await _aquistaRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {

            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }
    }
}
