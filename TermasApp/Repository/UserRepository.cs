using Microsoft.AspNetCore.Identity;
using TermasApp.Data;
using TermasApp.IRepository;
using TermasApp.Models;
using TermasApp.Service;

namespace TermasApp.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserService _userService;
        private readonly TermasAppContext _db;

        public UserRepository(IUserService userService,
                            UserManager<ApplicationUser> userManager,
                            SignInManager<ApplicationUser> signInManager, TermasAppContext db)
        {
            _db = db;
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> CreateUserAsync(CreatedUserModel userModel)
        {
            var user = new ApplicationUser()
            {
                UserName = userModel.UserName,
                IdUserOrig = userModel.IdUserOrig,
                TipoUser = userModel.TipoUser,
            };
            await _userManager.UpdateAsync(user);
            var result = await _userManager.CreateAsync(user, userModel.Password);

            return user.Id;
        }

        public async Task<SignInResult> PasswordSignInAsync(LoginModel loginModel)
        {
            return await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, false, false);
        }

        public async Task<IdentityResult> ChangePasswordAsync(MudarPasswordModel model)
        {
            var userId = _userService.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);
            return await _userManager.ChangePasswordAsync(user, model.PasswordAtual, model.NovaPassword);
        }
        public async Task<int> GetIdUser()
        {
            var userId = _userService.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);
            return user.IdUserOrig;
        }
        public async Task<string> GetTipoUser()
        {
            var userId = _userService.GetUserId();
            var user = await _userManager.FindByIdAsync(userId);
            return user.TipoUser;
        }

        public async Task DeleteUser(int id, string tipo)
        {
            var userId =  _db.Users.FirstOrDefault(x => x.IdUserOrig == id && x.TipoUser == tipo).Id;
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.DeleteAsync(user);

            if(tipo == "Funcionarios")
            {
                var funcionario = _db.Funcionario.Find(id);
                funcionario.Pass = false;
                _db.Funcionario.Update(funcionario);
                await _db.SaveChangesAsync();
            }
            else
            {
                var aquista = _db.Aquista.Find(id);
                aquista.Pass = false;
                _db.Aquista.Update(aquista);
                await _db.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.DeleteAsync(user);
        }
        public async Task<ApplicationUser> GetUserByNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
