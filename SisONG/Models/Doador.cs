using System.ComponentModel.DataAnnotations;

namespace SisONG.Models
{
    public class Doador : Usuario
    {
        [Required]
        public string TipoDoador { get; set; } // "Pessoa Física" ou "Pessoa Jurídica"

        [Required]
        public string Documento { get; set; } // CPF ou CNPJ

        public bool DoacaoAnonima { get; set; }

        //public ICollection<Doacao> HistoricoDoacoes { get; set; }
    }
}
