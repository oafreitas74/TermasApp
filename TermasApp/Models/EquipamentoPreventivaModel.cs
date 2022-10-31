using System.ComponentModel.DataAnnotations;

namespace TermasApp.Models
{
    public class EquipamentoPreventivaModel
    {
        [Key]
        public int Id { get; set; }
        public string? NomeInterno { get; set; }
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
