using System.ComponentModel.DataAnnotations;

namespace TermasApp.Models
{
    public class TriagemModel
    {
        [Key]
        public int Id { get; set; }
        public int? IdEnfermeiro { get; set; }
        public int? IdAquista { get; set; }
        [MaxLength(50)]
        [DataType(DataType.Time)]
        public string? Hora { get; set; }
        [MaxLength(50)]
        [DataType(DataType.Date)]
        public string? Data { get; set; }
    }
}
