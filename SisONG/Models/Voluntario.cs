namespace SisONG.Models
{
    public class Voluntario : Usuario
    {
        public string Habilidades { get; set; }

        public string Disponibilidade { get; set; }

        //public ICollection<EventoParticipacao> HistoricoParticipacao { get; set; }
    }
}
