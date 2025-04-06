namespace SisONG.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Evento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Titulo { get; set; }

        [StringLength(500)]
        public string Descricao { get; set; }

        [Required]
        public DateTime DataHora { get; set; }

        [Required]
        [StringLength(200)]
        public string Local { get; set; }

        [Required]
        public string Status { get; set; }

        // Relação muitos-para-muitos com Voluntário
        public ICollection<Voluntario> VoluntariosInscritos { get; set; } = new List<Voluntario>();
    }

}
