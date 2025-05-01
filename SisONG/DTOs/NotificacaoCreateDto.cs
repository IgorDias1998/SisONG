using System.ComponentModel.DataAnnotations;

namespace SisONG.DTOs
{
    public class NotificacaoCreateDto
    {
        [Required]
        public int UsuarioId { get; set; }

        [Required]
        [StringLength(50)]
        public string Tipo { get; set; }

        [Required]
        [StringLength(250)]
        public string Mensagem { get; set; }

        public DateTime DataEnvio { get; set; } = DateTime.Now;
    }
}
