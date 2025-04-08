namespace SisONG.DTOs
{
    public class UsuarioReadDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Tipo { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
