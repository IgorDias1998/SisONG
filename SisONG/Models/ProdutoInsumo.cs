using System.ComponentModel.DataAnnotations;

namespace SisONG.Models
{
    public class ProdutoInsumo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        public int QuantidadeDisponivel { get; set; }

        [Required]
        [StringLength(20)]
        public string UnidadeMedida { get; set; } // Ex: Kg, Litros, Unidades

        [StringLength(50)]
        public string Categoria { get; set; } // Ex: Higiene, Alimentos, Limpeza

        // Histórico de uso relacionado (opcional para visualização detalhada)
        public ICollection<HistoricoUso> HistoricoDeUso { get; set; } = new List<HistoricoUso>();
    }
}
