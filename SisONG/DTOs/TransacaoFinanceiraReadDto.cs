namespace SisONG.DTOs
{
    public class TransacaoFinanceiraReadDto
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public string MetodoPagamento { get; set; }
    }
}
