using System.ComponentModel.DataAnnotations;

namespace SisONG.DTOs
{
    public class NotificacaoUpdateDto
    {
        [Required]
        public string Tipo { get; set; }

        [Required]
        [StringLength(250)]
        public string Mensagem { get; set; }

        [Required]
        public DateTime DataEnvio { get; set; }
    }
}
