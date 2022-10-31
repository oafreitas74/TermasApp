using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TermasApp.Models
{
    public class CreatedUserModel
    {


        public int IdUserOrig { get; set; }
        public string? TipoUser { get; set; }

        [Required(ErrorMessage = "UserName")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Por favor, coloque uma password forte")]
        [Compare("ConfirmPassword", ErrorMessage = "Password não coincidem")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Por favor, confirme a sua password")]
        [Display(Name = "Confirmar Password")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
    }
}
