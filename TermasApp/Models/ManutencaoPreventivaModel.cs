using System.ComponentModel.DataAnnotations;

namespace TermasApp.Models
{
    public class ManutencaoPreventivaModel
    {
        [Key]
        public int Id { get; set; }
        public int? IdFuncionario { get; set; }
        public int? IdEquipamento { get; set; }
        [MaxLength(50)]
        [DataType(DataType.DateTime)]
        public string? Data { get; set; }
        public string? Observacoes { get; set; }
    }
}
