using System.ComponentModel.DataAnnotations;

namespace SisONG.DTOs
{
    public class PontoColetaCreateDto
    {
        [Required]
        [StringLength(100)]
        public string NomeLocal { get; set; }

        [Required]
        [StringLength(200)]
        public string Endereco { get; set; }

    }
}
