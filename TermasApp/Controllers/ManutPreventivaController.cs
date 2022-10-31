using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TermasApp.Data;
using TermasApp.IRepository;
using TermasApp.Models;

namespace TermasApp.Controllers
{
    public class ManutPreventivaController : Controller
    {
        public readonly IEquipamentoRepository _equipamentoRepository;
        public readonly IPedidoRepository _pedidoRepository;
        public ManutPreventivaController(IEquipamentoRepository equipamentoRepository, 
                                        IPedidoRepository pedidoRepository)
        {
            _equipamentoRepository = equipamentoRepository;
            _pedidoRepository = pedidoRepository;
        }

        // GET: ManutPreventivaController
        public async Task<ActionResult> Index()
        {
            return View(await _equipamentoRepository.GetAllEquipamentoPreventiva());
        }
        public async Task<ActionResult> Pedidos()
        {
            return View(await _pedidoRepository.GetAllPedidosPreventivaAberto());
        }
        public async Task<ActionResult> PedidosAll()
        {
            return View(await _pedidoRepository.GetAllPedidosPreventiva());
        }
        // GET: ManutPreventivaController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipamento = await _equipamentoRepository.GetEquipamentoPreventivaById(id);
            if (equipamento == null)
            {
                return NotFound();
            }

            return View(equipamento);
        }

        // POST: ManutPreventivaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EquipamentoPreventivaModel equipamento)
        {
            if (id != equipamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _equipamentoRepository.UpdateEquipamentoPreventiva(equipamento);
                }
                catch (DbUpdateConcurrencyException)
                {

                }

                return RedirectToAction(nameof(Index));
            }
            return View(equipamento);
        }
        // GET: ManutPreventivaController/Edit/5
        public ActionResult EditMapa()
        {
            return View();
        }

        // POST: ManutPreventivaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditMapa(List<EquipamentoPreventivaModel> ListModel)
        {
            try
            {
                await _equipamentoRepository.UpdateListEquipamentoPreventiva(ListModel);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(ListModel);
            }
        }

        public async Task<IActionResult> CriarPedidosPreventiva()
        {
            await _pedidoRepository.CriarPedido();
            return RedirectToAction(nameof(Pedidos));
        }
    }
}
