namespace SisONG.DTOs
{
    public class DoacaoCreateDto
    {
        public int DoadorId { get; set; }
        public string Tipo { get; set; }
        public decimal? Valor { get; set; }
        public string? Item { get; set; }
        public int? Quantidade { get; set; }
        public DateTime? Data { get; set; }
    }
}
