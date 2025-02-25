using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaSetorTecnico.Data;
using SistemaSetorTecnico.DTOs;
using SistemaSetorTecnico.Models;

namespace SistemaSetorTecnico.Controllers
{
    [Authorize]
    public class RecoletasController : Controller
    {

        private readonly IWebHostEnvironment _webHostEnv;
        private readonly ApplicationDbContext _context;

        public RecoletasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Recoletas
        public async Task<IActionResult> Index(string searchBy, string searchValue)
        {
            // Pegando a data atual
            var dataAtual = DateTime.Now;

            // Recupera todas as recoletas do sistema
            var recoletas = _context.Recoletas.AsQueryable();

            // Recupera todas as recoletas por mês vigente
            if (string.IsNullOrEmpty(searchValue))
            {
                recoletas = _context.Recoletas.
                Where(r => r.DataRecoleta.Month == dataAtual.Month && r.DataRecoleta.Year == dataAtual.Year);
            }

            // Filtro pelo nome do técnico
            // Se o usuário selecionou "Técnico Responsável"
            if (searchBy == "Tecnico" && !string.IsNullOrEmpty(searchValue))
            {
                recoletas = recoletas.Where(r => r.TecnicoResponsavel.Contains(searchValue));
            }
            // Se o usuário selecionou "Data"
            if (searchBy == "Data" && !string.IsNullOrEmpty(searchValue))
            {
                // Tentar interpretar o searchValue como mês/ano (formato esperado: MM/YYYY)
                if (DateTime.TryParseExact(searchValue, "MM/yyyy", null, System.Globalization.DateTimeStyles.None, out var selectedDate))
                {
                    recoletas = recoletas.Where(r => r.DataRecoleta.Month == selectedDate.Month && r.DataRecoleta.Year == selectedDate.Year);
                }
                else
                {
                    // Opcional: Adicionar lógica para tratar valores inválidos
                    ModelState.AddModelError("", "O formato da data deve ser MM/YYYY.");
                }
 
            }
            // Retorna os dados para a View
            return View(recoletas.ToList());
        }

        // GET: Recoletas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recoleta = await _context.Recoletas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recoleta == null)
            {
                return NotFound();
            }

            return View(recoleta);
        }

        // GET: Recoletas/Create
        public async Task<IActionResult> Create()
        {
            // Busca os Status no banco de dados
            var statusList = await _context.Status.ToListAsync();

            // Envia a lista de Status para a View usando ViewData
            ViewData["StatusList"] = new SelectList(statusList, "Id", "Nome");

            return View();
        }

        // POST: Recoletas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Empresa,TecnicoResponsavel,DataRecoleta,LocalRecoleta,Serie,NumeroOS,NomePaciente,Exame,MotivoRecoleta,LaboratorioApoio,BioquimicoResponsavel,DataContato,StatusId,ColetaConcluida")] RecoletaDTO recoletaDto)
        {
            var recoleta = new Recoleta
            {
                Id = recoletaDto.Id,
                Empresa = recoletaDto.Empresa,
                TecnicoResponsavel = recoletaDto.TecnicoResponsavel,
                DataRecoleta = recoletaDto.DataRecoleta,
                LocalRecoleta = recoletaDto.LocalRecoleta,
                Serie = recoletaDto.Serie,
                NumeroOS = recoletaDto.NumeroOS,
                NomePaciente = recoletaDto.NomePaciente,
                Exame = recoletaDto.Exame,
                MotivoRecoleta = recoletaDto.MotivoRecoleta,
                LaboratorioApoio = recoletaDto.LaboratorioApoio,
                BioquimicoResponsavel = recoletaDto.BioquimicoResponsavel,
                DataContato = recoletaDto.DataContato,
                StatusId = recoletaDto.StatusId,
                ColetaConcluida = recoletaDto.ColetaConcluida
            };

            if (ModelState.IsValid)
            {
                _context.Add(recoleta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["StatusList"] = new SelectList(await _context.Status.ToListAsync(), "Id", "Nome");

            return View(recoleta);
        }

        // GET: Recoletas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recoleta = await _context.Recoletas.FindAsync(id);
            if (recoleta == null)
            {
                return NotFound();
            }
            return View(recoleta);
        }

        // POST: Recoletas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Empresa,TecnicoResponsavel,DataRecoleta,LocalRecoleta,Serie,NumeroOS,NomePaciente,Exame,MotivoRecoleta,LaboratorioApoio,BioquimicoResponsavel,DataContato,ColetaConcluida")] Recoleta recoleta)
        {
            if (id != recoleta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recoleta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecoletaExists(recoleta.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return View(recoleta);
        }

        // GET: Recoletas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recoleta = await _context.Recoletas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (recoleta == null)
            {
                return NotFound();
            }

            return View(recoleta);
        }

        // POST: Recoletas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recoleta = await _context.Recoletas.FindAsync(id);
            if (recoleta != null)
            {
                _context.Recoletas.Remove(recoleta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecoletaExists(int id)
        {
            return _context.Recoletas.Any(e => e.Id == id);
        }
    }
}
