using System.ComponentModel.DataAnnotations;

namespace TermasApp.Data
{
    public class Equipamento
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(150)]
        public string? NomeInterno { get; set; }
        [MaxLength(150)]
        public string? Marca { get; set; }
        [MaxLength(150)]
        public string? Modelo { get; set; }
        [MaxLength(150)]
        public string? NSerie { get; set; }
        public string? Descricao { get; set; }
        [MaxLength(50)]
        public string? DataFabrico { get; set; }
        public bool Jan { get; set; }
        public bool Fev { get; set; }
        public bool Mar { get; set; }
        public bool Abr { get; set; }
        public bool Mai { get; set; }
        public bool Jun { get; set; }
        public bool Jul { get; set; }
        public bool Ago { get; set; }
        public bool Set { get; set; }
        public bool Out { get; set; }
        public bool Nov { get; set; }
        public bool Dez { get; set; }
    }
}
