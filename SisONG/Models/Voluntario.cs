namespace SisONG.Models
{
    public class Voluntario : Usuario
    {
        public string Habilidades { get; set; }

        public string Disponibilidade { get; set; }

        public string HistoricoParticipacao { get; set; }

        public ICollection<EventoVoluntario> EventoVoluntarios { get; set; }
    }
}
