using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SisONG.Models
{
    public class Notificacao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public Usuario UsuarioDestinatario { get; set; }

        [Required]
        [StringLength(50)]
        public string Tipo { get; set; } // Lembrete de Evento, Confirmação de Doação, Alerta de Insumo

        [Required]
        [StringLength(250)]
        public string Mensagem { get; set; }

        [Required]
        public DateTime DataEnvio { get; set; } = DateTime.Now;
    }
}
