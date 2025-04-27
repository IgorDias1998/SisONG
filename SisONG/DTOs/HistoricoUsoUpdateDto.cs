using System.ComponentModel.DataAnnotations;

namespace SisONG.DTOs
{
    public class HistoricoUsoUpdateDto
    {
        public int? ProdutoInsumoId { get; set; }
        public int? QuantidadeUtilizada { get; set; }
        public DateTime? DataUso { get; set; }

        [StringLength(250)]
        public string Observacao { get; set; }
    }
}
