using System.ComponentModel.DataAnnotations;

namespace TermasApp.Data
{
    public class PedidosReparacao
    {
        [Key]
        public int Id { get; set; }
        public int? IdTecnico { get; set; }
        public int? IdEquipamento { get; set; }
        [MaxLength(50)]
        public string? DataPedido { get; set; }
        [MaxLength(150)]
        public string? Avaria { get; set; }
        public string? Observacoes { get; set; }
        public float? Valor { get; set; }
        public bool? Preventiva { get; set; }
        [MaxLength(50)]
        public string? DataConclusao { get; set; }
        [MaxLength(50)]
        public string? Estado { get; set; }
    }
}
