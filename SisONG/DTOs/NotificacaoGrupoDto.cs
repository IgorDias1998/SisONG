namespace SisONG.DTOs
{
    public class NotificacaoGrupoDto
    {
        public string PerfilDestino { get; set; } // Ex: "Voluntario", "Doador"
        public string Tipo { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataEnvio { get; set; } = DateTime.Now;
    }
}
