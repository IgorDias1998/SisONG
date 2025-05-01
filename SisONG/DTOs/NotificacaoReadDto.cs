namespace SisONG.DTOs
{
    public class NotificacaoReadDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Tipo { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataEnvio { get; set; }
    }
}
