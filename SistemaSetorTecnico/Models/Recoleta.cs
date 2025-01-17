using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SistemaSetorTecnico.Models
{
    public class Recoleta
    {
        public int Id { get; set; }
        public string Empresa { get; set; }

        [DisplayName("Técnico Reponsável")]
        public string TecnicoResponsavel { get; set; }

        [DisplayName("Data da Recoleta")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataRecoleta { get; set; }

        [DisplayName("Local da Recoleta")]
        public string LocalRecoleta { get; set; }

        [DisplayName("Série")]
        public string Serie { get; set; }

        [DisplayName("Número da OS")]
        public string NumeroOS { get; set; }

        [DisplayName("Nome do Paciente")]
        public string NomePaciente { get; set; }

        public string Exame { get; set; }

        [DisplayName("Motivo da Recoleta")]
        public string MotivoRecoleta { get; set; }

        [DisplayName("Laboratorio de Apoio")]
        public string LaboratorioApoio { get; set; }

        [DisplayName("Bioquimico Responsável")]
        public string BioquimicoResponsavel { get; set; } // Apenas para Administradores

        [DisplayName("Data do Contato")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DataContato { get; set; } // Apenas para Administradores

        [DisplayName("Coleta Concluida")]
        public bool ColetaConcluida { get; set; }
    }

}
