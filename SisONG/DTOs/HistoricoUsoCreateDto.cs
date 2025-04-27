using System.ComponentModel.DataAnnotations;

namespace SisONG.DTOs
{
    public class HistoricoUsoCreateDto
    {
        [Required]
        public int ProdutoInsumoId { get; set; }

        [Required]
        public int QuantidadeUtilizada { get; set; }

        [Required]
        public DateTime DataUso { get; set; }

        [StringLength(250)]
        public string Observacao { get; set; }
    }
}
