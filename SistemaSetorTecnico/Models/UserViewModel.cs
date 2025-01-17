namespace SistemaSetorTecnico.Models
{
    public class UserViewModel
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Senha => "*********";
        public string Role { get; set; }
    }
}
