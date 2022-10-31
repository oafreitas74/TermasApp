using Microsoft.AspNetCore.Identity;

namespace TermasApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int IdUserOrig { get; set; }
        public string? TipoUser { get; set; }
    }
}
