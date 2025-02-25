namespace SistemaSetorTecnico.Models
{
    public class Localidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Localidade(string nome)
        {
            Nome = nome.ToUpper();
        }
    }
}
