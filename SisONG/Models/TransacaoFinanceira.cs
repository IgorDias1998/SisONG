using System.ComponentModel.DataAnnotations;

namespace SisONG.Models
{
    public class TransacaoFinanceira
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Range(0.01, double.MaxValue)]
        public decimal Valor { get; set; }

        [Required]
        public DateTime Data { get; set; } = DateTime.Now;

        [Required]
        [StringLength(50)]
        public string Origem { get; set; } // Doação, Patrocínio, Outro

        [Required]
        [StringLength(50)]
        public string Destino { get; set; } // Despesa, Reserva, Outro

        [Required]
        [StringLength(30)]
        public string MetodoPagamento { get; set; } // Pix, Cartão, Transferência
    }
}
