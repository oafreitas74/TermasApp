using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using TermasApp.Data;
using TermasApp.IRepository;
using TermasApp.Models;

namespace TermasApp.Controllers
{
    public class FuncionariosController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnvironment;
        public readonly IFuncionarioRepository _funcionarioRepository;

        public FuncionariosController(IHttpContextAccessor accessor,
                                    IWebHostEnvironment webHostEnvironment,
                                    IFuncionarioRepository funcionarioRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            _funcionarioRepository = funcionarioRepository;
        }

        // GET: Funcionarios
        public async Task<IActionResult> Index(string tipofuncionario)
        {
            List<FuncionarioModel>? model;
            if (tipofuncionario == null)
                model = await _funcionarioRepository.GetAllFuncionario();
            else
            {
                model = await _funcionarioRepository.GetAllFuncionarioTipo(tipofuncionario);
            }
            return View(model);
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var funcionario = await _funcionarioRepository.GetFuncionarioById(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public IActionResult Create(string tipoFuncionario)
        {

            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FuncionarioModel funcionario)
        {
            if (ModelState.IsValid)
            {
                if (funcionario.Foto != null)
                {
                    string folder = "images/funcionarios/";
                    funcionario.FotoSrc = await UploadImage(folder, funcionario.Foto);
                }
                int Id = await _funcionarioRepository.AddNewFuncionario(funcionario);

                return RedirectToAction("Details", new { Id });
            }
            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _funcionarioRepository.GetFuncionarioById(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, FuncionarioModel funcionario)
        {
            if (id != funcionario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (funcionario.Foto != null)
                {
                    string folder = "images/funcionarios/";
                    funcionario.FotoSrc = await UploadImage(folder, funcionario.Foto);
                }
                try
                {
                    await _funcionarioRepository.UpdateFuncionario(funcionario);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_funcionarioRepository.FuncionarioExists(funcionario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction("Details", new { funcionario.Id });
            }
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _funcionarioRepository.GetFuncionarioById(id);

            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _funcionarioRepository.Delete(id);
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
