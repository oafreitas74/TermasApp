using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TermasApp.IRepository;
using TermasApp.Models;

namespace TermasApp.Controllers
{
    public class UserController : Controller
    {
        public readonly IFuncionarioRepository _funcionarioRepository;
        public readonly IAquistaRepository _aquistaRepository;
        public readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository,
                                IFuncionarioRepository funcionarioRepository,
                                IAquistaRepository aquistaRepository)
        {
            _userRepository = userRepository;
            _funcionarioRepository = funcionarioRepository;
            _aquistaRepository = aquistaRepository;
        }

        [Route("CreatedUser")]
        public IActionResult CreatedUser(int id, string tipo)
        {
            var model = new CreatedUserModel()
            {
                IdUserOrig = id,
                TipoUser = tipo,
            };

            return View(model);
        }

        [Route("CreatedUser")]
        [HttpPost]
        public async Task<IActionResult> CreatedUser(CreatedUserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var userId = await _userRepository.CreateUserAsync(userModel);

                if(userModel.TipoUser == "Aquistas")
                {
                    var b = await _aquistaRepository.AquistaLoginTrue(userModel.IdUserOrig);
                    if (b == true)
                        ModelState.Clear();
                }
                else
                {
                    var b = await _funcionarioRepository.FuncionarioLoginTrue(userModel.IdUserOrig);
                    if (b == true)
                        ModelState.Clear();
                }

                return RedirectToAction("LoginCreate", "Home", new { userName = userModel.UserName, pass = userModel.Password });

            }

            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _userRepository.PasswordSignInAsync(loginModel);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "User Login ou Password incorretos");

            }

            return View(loginModel);
        }


        public async Task<IActionResult> Logout()
        {
            await _userRepository.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult ChangePassword(int? id)
        {
            ViewBag.IdEmpresa = id;
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ChangePassword(MudarPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userRepository.ChangePasswordAsync(model);
                if (result.Succeeded)
                {
                    ViewBag.IsSuccess = true;
                    ModelState.Clear();
                    return View();
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);

        }

        public async Task<IActionResult> DeleteUserAsync(int id, string tipo)
        {
            await _userRepository.DeleteUser(id, tipo);

            return RedirectToAction("Index", "Funcionarios");
        }

    }
}

