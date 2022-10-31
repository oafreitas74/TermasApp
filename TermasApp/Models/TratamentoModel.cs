using System.ComponentModel.DataAnnotations;
using TermasApp.Data;

namespace TermasApp.Models
{
    public class TratamentoModel
    {
        [Key]
        public int Id { get; set; }
        public int? IdAquista { get; set; }
        public int? IdPrescricao { get; set; }
        public int? IdTerapeuta { get; set; }
        public int? IdTriagem { get; set; }
        [MaxLength(50)]
        [DataType(DataType.Time)]
        public string? Hora { get; set; }
        [MaxLength(50)]
        [DataType(DataType.Date)]
        public string? Data { get; set; }
        public string? Observacoes { get; set; }
        public int? IdTipoTratamento { get; set; }
    }
}
