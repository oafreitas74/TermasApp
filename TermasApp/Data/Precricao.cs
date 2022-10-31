using System.ComponentModel.DataAnnotations;

namespace TermasApp.Data
{
    public class Precricao
    {
        [Key]
        public int Id { get; set; }
        public int? IdAquista { get; set; }
        public int? IdTipoTratamento { get; set; }
        public int? NTratamentos { get; set; }
        [MaxLength(50)]
        public string? Data { get; set; }
        public int? IdConsulta { get; set; }
    }
}
