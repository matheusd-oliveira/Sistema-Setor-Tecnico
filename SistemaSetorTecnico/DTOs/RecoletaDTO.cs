using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SistemaSetorTecnico.DTOs
{
    public class RecoletaDTO
    {
        public int Id { get; set; }
        public string Empresa { get; set; }
        public string TecnicoResponsavel { get; set; }
        public DateTime DataRecoleta { get; set; }
        public string LocalRecoleta { get; set; }
        public string Serie { get; set; }
        public string NumeroOS { get; set; }
        public string NomePaciente { get; set; }
        public string Exame { get; set; }
        public string MotivoRecoleta { get; set; }
        public string LaboratorioApoio { get; set; }
        public string? BioquimicoResponsavel { get; set; }
        public DateTime? DataContato { get; set; } 
        public int StatusId { get; set; }
        public bool ColetaConcluida { get; set; }
    }
}
