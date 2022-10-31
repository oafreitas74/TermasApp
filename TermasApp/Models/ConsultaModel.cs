using System.ComponentModel.DataAnnotations;

namespace TermasApp.Models
{
    public class ConsultaModel
    {
        [Key]
        public int Id { get; set; }
        public int? IdMedico { get; set; }
        public int? IdAquista { get; set; }
        public int? IdTriagem { get; set; }
        public int? IdTipoConsulta { get; set; }
        [MaxLength(50)]
        [DataType(DataType.Time)]
        public string? Hora { get; set; }
        [MaxLength(50)]
        [DataType(DataType.Date)]
        public string? Data { get; set; }
        public string? Observacoes { get; set; }
        public bool? PrescricaoTrue { get; set; }
    }
}
