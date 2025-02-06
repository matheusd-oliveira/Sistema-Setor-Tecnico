using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaSetorTecnico.Data;
using SistemaSetorTecnico.Models;
using System.Buffers;
using System.Globalization;

namespace SistemaSetorTecnico.Controllers
{
    // Criar tela visual para solicitar o relatório por mês e por ano.
    // Criar relatório de mês e anual.


    [Authorize]
    public class RelatoriosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RelatoriosController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
             return View();
        }

        [HttpGet]
        public async Task<IActionResult> GerarRelatorio(int ano, int? mes)
        {
            var query = _context.Recoletas.Where(r => r.DataRecoleta.Year == ano);

            if (mes.HasValue)
                query = _context.Recoletas.Where(r => r.DataRecoleta.Month == mes.Value);

            var dadosRelatorios = query.ToList();

            return View("RelatorioView" ,dadosRelatorios);
        }
    }
}
