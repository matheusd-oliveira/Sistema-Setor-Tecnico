using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaSetorTecnico.DTOs
{

    public class RecoletaDTO
    {
        public int Id { get; set; }
        public string Empresa { get; set; }
        public string TecnicoResponsavel { get; set; }

        [DisplayName("Data da Recoleta")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataRecoleta { get; set; }
        public int LocalidadesId { get; set; }
        public string Serie { get; set; }
        public string NumeroOS { get; set; }
        public string NomePaciente { get; set; }
        public string Exame { get; set; }
        public int MotivosId { get; set; }
        public string LaboratorioApoio { get; set; }
        public string? BioquimicoResponsavel { get; set; }

        [DisplayName("Data do Contato")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataContato { get; set; }
        public int StatusId { get; set; }
        public bool ColetaConcluida { get; set; }
    }
}
