using System.ComponentModel.DataAnnotations;

namespace TermasApp.Data
{
    public class TipoConsulta
    {
        [Key]
        public int Id { get; set; }
        public float? Preco { get; set; }
        [MaxLength(150)]
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        [MaxLength(50)]
        public string? Duracao { get; set; }
        [MaxLength(150)]
        public string? ImagemPublicitaria { get; set; }
    }
}
