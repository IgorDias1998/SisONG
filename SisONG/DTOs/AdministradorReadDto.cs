namespace SisONG.DTOs
{
    public class AdministradorReadDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Cargo { get; set; }
        public string Tipo { get; set; } = "Administrador";
    }
}
