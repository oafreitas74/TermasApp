using System.ComponentModel.DataAnnotations;

namespace TermasApp.Data
{
    public class Tratamento
    {
        [Key]
        public int Id { get; set; }
        public int? IdAquista { get; set; }
        public int? IdPrescricao { get; set; }
        public int? IdTerapeuta { get; set; }
        public int? IdTriagem { get; set; }
        [MaxLength(50)]
        public string? Hora { get; set; }
        [MaxLength(50)]
        public string? Data { get; set; }
        public string? Observacoes { get; set; }
        public int? IdTipoTratamento { get; set; }
    }
}
