using System.ComponentModel.DataAnnotations;

namespace TermasApp.Data
{
    public class Triagem
    {
        [Key]
        public int Id { get; set; }
        public int? IdEnfermeiro { get; set; }
        public int? IdAquista { get; set; }
        [MaxLength(50)]
        public string? Hora { get; set; }
        [MaxLength(50)]
        public string? Data { get; set; }
    }
}
