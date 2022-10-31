using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TermasApp.Models
{
    public class MudarPasswordModel
    {
        [Required, DataType(DataType.Password), Display(Name = "Password atual")]
        public string? PasswordAtual { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "Nova password")]
        public string? NovaPassword { get; set; }

        [Required, DataType(DataType.Password), Display(Name = "Confirme a  nova password")]
        [Compare("NovaPassword", ErrorMessage = "Confirme a  nova password, não coincidem")]
        public string? ConfirmeNovaPassword { get; set; }
    }
}
