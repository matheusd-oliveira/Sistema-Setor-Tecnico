using System.ComponentModel.DataAnnotations.Schema;

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

        
        public ICollection<Recoleta> Recoleta { get; set; }
    }
}
