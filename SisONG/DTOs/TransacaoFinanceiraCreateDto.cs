namespace SisONG.DTOs
{
    public class TransacaoFinanceiraCreateDto
    {
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public string Origem { get; set; } // Ex: Doação, Patrocínio, Outro
        public string Destino { get; set; } // Ex: Despesa, Reserva, Outro
        public string MetodoPagamento { get; set; } // Ex: Pix, Cartão, Transferência
    }
}
