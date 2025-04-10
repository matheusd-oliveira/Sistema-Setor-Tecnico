using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace SistemaSetorTecnico.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataCadastro { get; set; }
        public bool IsBioquimico { get; set; }
        public bool IsAdmin { get; set; }


    }
}
