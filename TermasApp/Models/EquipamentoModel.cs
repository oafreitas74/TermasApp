using System.ComponentModel.DataAnnotations;

namespace TermasApp.Models
{
    public class EquipamentoModel
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
        [DataType(DataType.Date)]
        public string? DataFabrico { get; set; }
    }
}
