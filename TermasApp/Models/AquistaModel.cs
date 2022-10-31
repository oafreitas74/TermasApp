using System.ComponentModel.DataAnnotations;

namespace TermasApp.Models
{
    public class AquistaModel
    {
        [Key]
        public int Id { get; set; }
        public long? NIF { get; set; }
        public long? NSSocial { get; set; }
        public long? Telefone { get; set; }
        [MaxLength(150)]
        public string? Nome { get; set; }
        [MaxLength(50)]
        public string? CC { get; set; }
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [MaxLength(150)]
        public string? Rua { get; set; }
        [MaxLength(50)]
        public string? CPostal { get; set; }
        [MaxLength(50)]
        public string? Concelho { get; set; }
        [MaxLength(50)]
        public string? Localidade { get; set; }
        [MaxLength(50)]
        public string? Pais { get; set; }
        [MaxLength(50)]
        public string? Nacionalidade { get; set; }
        [MaxLength(50)]
        [DataType(DataType.Date)]
        public string? DataNascimento { get; set; }
        [MaxLength(50)]
        public string? SeguroSaude { get; set; }
        [MaxLength(150)]
        public string? FotoSrc { get; set; }
        public IFormFile? Foto { get; set; }
        [MaxLength(50)]
        public string? Genero { get; set; }
        public bool? Pass { get; set; }
    }
}
