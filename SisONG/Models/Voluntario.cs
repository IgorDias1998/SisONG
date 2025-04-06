namespace SisONG.Models
{
    public class Voluntario : Usuario
    {
        public string Habilidades { get; set; }

        public string Disponibilidade { get; set; }

        public ICollection<Evento> HistoricoParticipacao { get; set; }
    }
}
