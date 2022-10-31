using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TermasApp.IRepository;
using TermasApp.Models;

namespace TermasApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public readonly IFuncionarioRepository _funcionarioRepository;

        public HomeController(ILogger<HomeController> logger, 
                            SignInManager<ApplicationUser> signInManager, 
                            IFuncionarioRepository funcionarioRepository)
        {
            _logger = logger;
            _signInManager = signInManager;
            _funcionarioRepository = funcionarioRepository;
        }

        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                if (User.FindFirst("TipoUser").Value != "Aquistas")
                    return RedirectToAction(nameof(Dashboard));
                else
                    return RedirectToAction(nameof(Aquista));
            }
            var count = _funcionarioRepository.FuncionarioCount();
            if (count == 0)
                return RedirectToAction("Create", "Funcionarios");
            return View();
        }
        public IActionResult Dashboard()
        {

            if (User.FindFirst("TipoUser").Value == "Aquistas")
                return RedirectToAction(nameof(Aquista));

            return View();
        }
        public IActionResult Aquista()
        {
            if (User.FindFirst("TipoUser").Value != "Aquistas")
                return RedirectToAction(nameof(Dashboard));
            return View();
        }

        public IActionResult LoginCreate(string userName, string pass)
        {
            ViewBag.UserName = userName;
            ViewBag.Pass = pass;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

  
    }
}