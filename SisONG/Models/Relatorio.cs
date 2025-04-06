using System.ComponentModel.DataAnnotations;

namespace SisONG.Models
{
    public class Relatorio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Tipo { get; set; } // Financeiro, Voluntariado, Eventos

        [Required]
        public DateTime DataGeracao { get; set; } = DateTime.Now;

        [Required]
        public string Conteudo { get; set; }
    }
}
