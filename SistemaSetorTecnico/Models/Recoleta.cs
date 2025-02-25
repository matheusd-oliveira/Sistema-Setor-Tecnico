using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaSetorTecnico.Models
{
    public class Recoleta
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do técnico é necessário.")]
        public string Empresa { get; set; }

        [DisplayName("Técnico Reponsável")]
        [Required(ErrorMessage = "O nome do técnico é obrigatório.")]
        public string TecnicoResponsavel { get; set; }

        [DisplayName("Data da Recoleta")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Preencha a data que foi realizada a recoleta.")]
        public DateTime DataRecoleta { get; set; }

        [DisplayName("Local da Recoleta")]
        [Required(ErrorMessage = "Qual o local da recoleta?")]
        public string LocalRecoleta { get; set; }

        [DisplayName("Série")]
        [Required(ErrorMessage = "Preencha o número de série")]
        public string Serie { get; set; }

        [DisplayName("Número da OS")]
        [Required(ErrorMessage = "O número da OS é obrigatório.")]
        public string NumeroOS { get; set; }

        [DisplayName("Nome do Paciente")]
        [Required(ErrorMessage = "O nome do paciente é necessário.")]
        public string NomePaciente { get; set; }

        public string Exame { get; set; }

        [DisplayName("Motivo da Recoleta")]
        [Required(ErrorMessage = "Qual o motivo da recoleta?")]
        public string MotivoRecoleta { get; set; }

        [DisplayName("Laboratorio de Apoio")]
        [Required(ErrorMessage = "Insira o laboratório de apoio.")]
        public string LaboratorioApoio { get; set; }

        [DisplayName("Bioquimico Responsável")]
        public string? BioquimicoResponsavel { get; set; } // Apenas para Administradores

        [DisplayName("Data do Contato")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DataContato { get; set; } // Apenas para Administradores


        // Chave estrangeira
        //[ForeignKey("StatusId")]
        public int StatusId { get; set; }

        [DisplayName("Coleta Concluida")]
        public bool ColetaConcluida { get; set; }

        //// Propriedade de navegação.
        [NotMapped]
        public Status Status { get; set; }
        
        

    }

}
