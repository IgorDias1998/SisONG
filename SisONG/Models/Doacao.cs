using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SisONG.Models
{
    public class Doacao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DoadorId { get; set; }

        [ForeignKey("DoadorId")]
        public Doador Doador { get; set; }

        [Required]
        public string Tipo { get; set; } // "Financeira" ou "Insumo"

        [Column(TypeName = "decimal(10,2)")]
        public decimal? Valor { get; set; }

        public string Item { get; set; }

        public int? Quantidade { get; set; }

        [Required]
        public DateTime Data { get; set; } = DateTime.Now;
    }
}
