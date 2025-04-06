using System.ComponentModel.DataAnnotations;

namespace SisONG.Models
{
    public abstract class Usuario
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string SenhaHash { get; set; }

        [Phone]
        public string Telefone { get; set; }

        [Required]
        public string Tipo { get; set; }

        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
