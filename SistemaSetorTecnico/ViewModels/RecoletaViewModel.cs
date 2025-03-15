namespace SistemaSetorTecnico.ViewModels
{
    // Criação de uma ViewModel para mostrar na tela somente os itens essenciais.
    public class RecoletaViewModel
    {
        public string Empresa { get; set; }
        public string TecnicoResponsavel { get; set; }
        public DateTime DataRecoleta { get; set; }
        public string LocaisNome { get; set; } 
        public string Serie { get; set; }
        public string NumeroOS { get; set; }
        public string NomePaciente { get; set; }
        public string Exame { get; set; }
        public string MotivoNome { get; set; }
        public string LaboratorioApoio { get; set; }
        public string? BioquimicoResponsavel { get; set; }
        public DateTime? DataContato { get; set; }
        public string StatusNome { get; set; }
        public bool ColetaConcluida { get; set; }

    }
}
