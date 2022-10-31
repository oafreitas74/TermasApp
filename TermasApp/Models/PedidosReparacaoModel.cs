using System.ComponentModel.DataAnnotations;

namespace TermasApp.Models
{
    public class PedidosReparacaoModel
    {
        [Key]
        public int Id { get; set; }
        public int? IdTecnico { get; set; }
        public int? IdEquipamento { get; set; }
        [MaxLength(50)]
        [DataType(DataType.DateTime)]
        public string? DataPedido { get; set; }
        [MaxLength(150)]
        public string? Avaria { get; set; }
        public string? Observacoes { get; set; }
        public float? Valor { get; set; }
        public bool? Preventiva { get; set; }
        [MaxLength(50)]
        [DataType(DataType.DateTime)]
        public string? DataConclusao { get; set; }
        [MaxLength(50)]
        public string? Estado { get; set; }
    }
}
