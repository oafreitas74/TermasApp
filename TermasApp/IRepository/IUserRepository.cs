using Microsoft.AspNetCore.Identity;
using TermasApp.Models;

namespace TermasApp.IRepository
{
    public interface IUserRepository
    {
        Task<IdentityResult> ChangePasswordAsync(MudarPasswordModel model);
        Task<string> CreateUserAsync(CreatedUserModel userModel);
        Task DeleteAsync(string userId);
        Task DeleteUser(int id, string tipo);
        Task<int> GetIdUser();
        Task<string> GetTipoUser();
        Task<ApplicationUser> GetUserByNameAsync(string userName);
        Task<SignInResult> PasswordSignInAsync(LoginModel loginModel);
        Task SignOutAsync();
    }
}