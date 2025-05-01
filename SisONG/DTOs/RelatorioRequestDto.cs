using System.ComponentModel.DataAnnotations;

namespace SisONG.DTOs
{
    public class RelatorioRequestDto
    {
        public string Tipo { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}
