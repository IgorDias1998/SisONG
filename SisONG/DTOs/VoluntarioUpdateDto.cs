using System.ComponentModel.DataAnnotations;

namespace SisONG.DTOs
{
    public class VoluntarioUpdateDto
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Telefone { get; set; }

        [Required]
        public string Habilidades { get; set; }

        [Required]
        public string Disponibilidade { get; set; }

        public string HistoricoParticipacao { get; set; }
    }
}
