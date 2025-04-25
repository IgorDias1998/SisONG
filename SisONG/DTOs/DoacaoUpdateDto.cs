namespace SisONG.DTOs
{
    public class DoacaoUpdateDto
    {
        public string Tipo { get; set; }
        public decimal? Valor { get; set; }
        public string Item { get; set; }
        public int? Quantidade { get; set; }
        public DateTime? Data { get; set; }
    }
}
