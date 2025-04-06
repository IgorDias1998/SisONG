namespace SisONG.Models
{
    public class EventoVoluntario
    {
        //Classe intermediária para salvar o relacionamento de voluntários e eventos
        public int EventoId { get; set; }
        public Evento Evento { get; set; }

        public int VoluntarioId { get; set; }
        public Voluntario Voluntario { get; set; }
    }
}
