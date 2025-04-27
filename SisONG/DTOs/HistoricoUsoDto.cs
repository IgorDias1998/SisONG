namespace SisONG.DTOs
{
    public class HistoricoUsoDto
    {
        public int Id { get; set; }
        public int ProdutoInsumoId { get; set; }
        public int QuantidadeUtilizada { get; set; }
        public DateTime DataUso { get; set; }
        public string Observacao { get; set; }
    }
}
