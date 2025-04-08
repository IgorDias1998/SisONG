namespace SisONG.DTOs
{
    public class UsuarioCreateDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public string Tipo { get; set; } // "Administrador", "Voluntario", "Doador"
    }
}
