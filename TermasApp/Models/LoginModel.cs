using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TermasApp.Models
{
    public class LoginModel
    {
        [Required]
        public string? UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }


    }
}
