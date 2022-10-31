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
    public class TipoTratamentoController : Controller
    {
        private readonly ITipoTratamentoRepository _tipoTratamentoRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public TipoTratamentoController(IWebHostEnvironment webHostEnvironment,
            ITipoTratamentoRepository tipoTratamentoRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            _tipoTratamentoRepository = tipoTratamentoRepository;
        }

        // GET: TipoTratamentoModel
        public async Task<IActionResult> Index()
        {
            return View(await _tipoTratamentoRepository.GetAllTTratamento());
        }

        // GET: TipoTratamentoModel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoConsulta = await _tipoTratamentoRepository.GetTTratamentoById(id);
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

        // POST: TipoTratamentoModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipoTratamentoModel tipoTratamento)
        {
            if (ModelState.IsValid)
            {
                if (tipoTratamento.Imagem != null)
                {
                    string folder = "images/TTratamento/";
                    tipoTratamento.ImagemPublicitaria = await UploadImage(folder, tipoTratamento.Imagem);
                }
                int Id = await _tipoTratamentoRepository.AddNewTTratamento(tipoTratamento);

                return RedirectToAction("Details", new { Id });

            }
            return View(tipoTratamento);
        }

        // GET: TipoTratamentoModel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTratamento = await _tipoTratamentoRepository.GetTTratamentoById(id);
            if (tipoTratamento == null)
            {
                return NotFound();
            }
            return View(tipoTratamento);
        }

        // POST: TipoTratamentoModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TipoTratamentoModel tipoTratamento)
        {
            if (id != tipoTratamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (tipoTratamento.Imagem != null)
                {
                    string folder = "images/TConsulta/";
                    tipoTratamento.ImagemPublicitaria = await UploadImage(folder, tipoTratamento.Imagem);
                }
                try
                {
                    await _tipoTratamentoRepository.UpdateTTratamento(tipoTratamento);
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction("Details", new { tipoTratamento.Id });
            }
            return View(tipoTratamento);
        }

        // GET: TipoTratamentoModel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTratamento = await _tipoTratamentoRepository.GetTTratamentoById(id);

            if (tipoTratamento == null)
            {
                return NotFound();
            }

            return View(tipoTratamento);
        }

        // POST: TipoTratamentoModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _tipoTratamentoRepository.Delete(id);
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