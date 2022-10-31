using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using TermasApp.Models;

namespace TermasApp.Helpers
{
    public class ApplicationUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>
    {
        public ApplicationUserClaimsPrincipalFactory(UserManager<ApplicationUser> userManager,
           RoleManager<IdentityRole> roleManager, IOptions<IdentityOptions> options)
           : base(userManager, roleManager, options)
        {
        }

        protected override async Task<ClaimsIdentity> GenerateClaimsAsync(ApplicationUser user)
        {
            var identity = await base.GenerateClaimsAsync(user);
            identity.AddClaim(new Claim("IdUserOrig", user.IdUserOrig.ToString() ?? ""));
            identity.AddClaim(new Claim("TipoUser", user.TipoUser ?? ""));

            return identity;
        }
    }
}
