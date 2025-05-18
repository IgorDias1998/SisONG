namespace SisONG.DTOs
{
        public class UsuarioCompletoReadDto
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Telefone { get; set; }
            public string Tipo { get; set; }
            public DateTime DataCadastro { get; set; }

            // Campos Voluntario
            public string? Habilidades { get; set; }
            public string? Disponibilidade { get; set; }
            public string? HistoricoParticipacao { get; set; }

            // Campos Doador
            public string? Cpf { get; set; }
            public string? Endereco { get; set; }

            // Campos Administrador
            public string? Cargo { get; set; }
        }
}
