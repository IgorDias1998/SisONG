using System.ComponentModel.DataAnnotations;

namespace SisONG.Models
{
    public class PontoColeta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string NomeLocal { get; set; }

        [Required]
        [StringLength(200)]
        public string Endereco { get; set; }
    }
}
