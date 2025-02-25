namespace SistemaSetorTecnico.Models
{
    public class Status
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public Status(string nome) 
        {
            Nome = nome.ToUpper();
        } 

        // propriedade de navegação para chegar na classe de Recoletas
        public ICollection<Recoleta> Recoleta { get; set; }
    }
}