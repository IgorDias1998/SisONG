using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SisONG.Models
{
    public class HistoricoUso
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProdutoInsumoId { get; set; }

        [ForeignKey("ProdutoInsumoId")]
        public ProdutoInsumo? ProdutoInsumo { get; set; }

        [Required]
        public int QuantidadeUtilizada { get; set; }

        [Required]
        public DateTime DataUso { get; set; } = DateTime.Now;

        [StringLength(250)]
        public string Observacao { get; set; }
    }
}
