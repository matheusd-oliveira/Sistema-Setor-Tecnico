using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaSetorTecnico.Models
{
    public class Motivo
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public Motivo(string nome)
        {
            Nome = nome.ToUpper();
        }

        
        public ICollection<Recoleta> Recoleta { get; set; }
    }
}
