using System.ComponentModel.DataAnnotations;

namespace TermasApp.Models
{
    public class PrescricaoModel
    {
        [Key]
        public int Id { get; set; }
        public int? IdAquista { get; set; }
        public int? IdConsulta { get; set; }
        public int? IdTipoTratamento { get; set; }
        public int? Marcados { get; set; }
        public int? NTratamentos { get; set; }
        [MaxLength(50)]
        [DataType(DataType.Date)]
        public string? Data { get; set; }
    }
}
