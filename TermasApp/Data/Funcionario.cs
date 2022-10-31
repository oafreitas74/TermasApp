using System.ComponentModel.DataAnnotations;

namespace TermasApp.Data
{
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }
        public int? Classificacao { get; set; }
        public long? Telefone { get; set; }
        public long? NIF { get; set; }
        public long? NSSocial { get; set; }
        [MaxLength(150)]
        public string? Nome { get; set; }
        [MaxLength(50)]
        public string? TipoFuncionario { get; set; }
        [MaxLength(50)]
        public string? CC { get; set; }
        [MaxLength(150)]
        public string? IBAN { get; set; }
        [MaxLength(50)]
        public string? SeguroTrabalho { get; set; }
        [MaxLength(100)]
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
        public string? DataNascimento { get; set; }
        [MaxLength(50)]
        public string? DataEntrada { get; set; }
        [MaxLength(50)]
        public string? DataSaida { get; set; }
        [MaxLength(150)]
        public string? Posto { get; set; }
        [MaxLength(150)]
        public string? Hablitacoes { get; set; }
        [MaxLength(150)]
        public string? Especialidade { get; set; }
        [MaxLength(150)]
        public string? FotoSrc { get; set; }
        [MaxLength(50)]
        public string? Genero { get; set; }
        public bool? Ativo { get; set; }
        public bool? Pass { get; set; }
    }
}
