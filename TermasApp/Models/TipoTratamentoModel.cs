using System.ComponentModel.DataAnnotations;

namespace TermasApp.Models
{
    public class TipoTratamentoModel
    {
        [Key]
        public int Id { get; set; }
        public float? Preco { get; set; }
        [MaxLength(150)]
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        [MaxLength(50)]
        [DataType(DataType.Time)]
        public string? Duracao { get; set; }
        [MaxLength(150)]
        public string? ImagemPublicitaria { get; set; }
        public IFormFile? Imagem { get; set; }
    }
}
