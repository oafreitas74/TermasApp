using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TermasApp.Data;
using TermasApp.IRepository;
using TermasApp.Models;

namespace TermasApp.Controllers
{
    public class TipoConsultasController : Controller
    {
        private readonly ITipoConsultaRepository _tipoConsultaRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TipoConsultasController(IWebHostEnvironment webHostEnvironment, 
            ITipoConsultaRepository tipoConsultaRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            _tipoConsultaRepository = tipoConsultaRepository;
        }

        // GET: TipoConsultas
        public async Task<IActionResult> Index()
        {
              return View(await _tipoConsultaRepository.GetAllTConsulta());
        }

        // GET: TipoConsultas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoConsulta = await _tipoConsultaRepository.GetTConsultaById(id);
            if (tipoConsulta == null)
            {
                return NotFound();
            }

            return View(tipoConsulta);
        }
   
        // GET: TipoConsultas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoConsultas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipoConsultaModel tipoConsulta)
        {
            if (ModelState.IsValid)
            {
                if (tipoConsulta.Imagem != null)
                {
                    string folder = "images/TConsulta/";
                    tipoConsulta.ImagemPublicitaria = await UploadImage(folder, tipoConsulta.Imagem);
                }
                int Id = await _tipoConsultaRepository.AddNewTConsulta(tipoConsulta);

                return RedirectToAction("Details", new { Id });

            }
            return View(tipoConsulta);
        }

        // GET: TipoConsultas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoConsulta = await _tipoConsultaRepository.GetTConsultaById(id);
            if (tipoConsulta == null)
            {
                return NotFound();
            }
            return View(tipoConsulta);
        }

        // POST: TipoConsultas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,TipoConsultaModel tipoConsulta)
        {
            if (id != tipoConsulta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (tipoConsulta.Imagem != null)
                {
                    string folder = "images/TConsulta/";
                    tipoConsulta.ImagemPublicitaria = await UploadImage(folder, tipoConsulta.Imagem);
                }
                try
                {
                    await _tipoConsultaRepository.UpdateTConsulta(tipoConsulta);
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction("Details", new { tipoConsulta.Id });
            }
            return View(tipoConsulta);
        }

        // GET: TipoConsultas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoConsulta = await _tipoConsultaRepository.GetTConsultaById(id);

            if (tipoConsulta == null)
            {
                return NotFound();
            }

            return View(tipoConsulta);
        }

        // POST: TipoConsultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _tipoConsultaRepository.Delete(id);
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
