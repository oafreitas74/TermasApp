using System.ComponentModel.DataAnnotations;

namespace TermasApp.Data
{
    public class Consulta
    {
        [Key]
        public int Id { get; set; }
        public int? IdMedico { get; set; }
        public int? IdAquista { get; set; }
        public int? IdTriagem { get; set; }
        [MaxLength(50)]
        public string? Hora { get; set; }
        [MaxLength(50)]
        public string? Data { get; set; }
        public string? Observacoes { get; set; }
        public int? IdTipoConsulta { get; set; }
        public bool? PrescricaoTrue { get; set; }
    }
}
