using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaSetorTecnico.Data;
using SistemaSetorTecnico.DTOs;
using SistemaSetorTecnico.Models;
using X.PagedList.Extensions;

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
        public async Task<IActionResult> Index(string searchBy, string searchValue, int page = 1)
        {
            // Pegando a data atual
            var dataAtual = DateTime.Now;

            //// Recupera todas as recoletas do sistema
            var recoletas = _context.Recoletas.Include(r => r.Motivos).Include(s => s.Status).Include(l => l.Localidades).AsQueryable();

            var selectedDate = new DateTime();

            // Recupera todas as recoletas por mês vigente
            if (string.IsNullOrEmpty(searchValue))
            {
                recoletas = recoletas.
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
                if (DateTime.TryParseExact(searchValue, "MM/yyyy", null, System.Globalization.DateTimeStyles.None, out selectedDate))
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

            // Busca os motivos no banco de dados
            var motivosList = await _context.Motivos.ToListAsync();

            // Busca as localidades no banco de dados
            var locaisList = await _context.Localidades.ToListAsync();

            // Envia a lista de Status,Motivos e Localidades para a View usando ViewData
            ViewData["StatusList"] = new SelectList(statusList, "Id", "Nome");
            ViewData["MotivosList"] = new SelectList(motivosList, "Id", "Nome");
            ViewData["LocaisList"] = new SelectList(locaisList, "Id", "Nome");


            return View();
        }

        // POST: Recoletas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Empresa,TecnicoResponsavel,DataRecoleta,LocalidadesId,Serie,NumeroOS,NomePaciente,Exame,MotivosId,LaboratorioApoio,BioquimicoResponsavel,DataContato,StatusId,ColetaConcluida")] RecoletaDTO recoletaDto)
        {
            //if (recoletaDto.BioquimicoResponsavel == null || recoletaDto.DataContato == null)
            //{
            //    recoletaDto.BioquimicoResponsavel = "ALTERE O NOME";
            //    recoletaDto.DataContato = DateTime.Now;
            //}

            if (recoletaDto.BioquimicoResponsavel == null && recoletaDto.DataContato == null)
            {
                recoletaDto.BioquimicoResponsavel = "";
                recoletaDto.DataContato = new DateTime();

            }

            var recoleta = new Recoleta
            {
                Id = recoletaDto.Id,
                Empresa = recoletaDto.Empresa.ToUpper(),
                TecnicoResponsavel = recoletaDto.TecnicoResponsavel.ToUpper(),
                DataRecoleta = recoletaDto.DataRecoleta,
                LocalidadesId = recoletaDto.LocalidadesId,
                Serie = recoletaDto.Serie,
                NumeroOS = recoletaDto.NumeroOS,
                NomePaciente = recoletaDto.NomePaciente.ToUpper(),
                Exame = recoletaDto.Exame.ToUpper(),
                MotivosId = recoletaDto.MotivosId,
                LaboratorioApoio = recoletaDto.LaboratorioApoio.ToUpper(),
                BioquimicoResponsavel = recoletaDto?.BioquimicoResponsavel.ToUpper(),
                DataContato = recoletaDto?.DataContato,
                StatusId = recoletaDto.StatusId,
                ColetaConcluida = recoletaDto.ColetaConcluida
            };



            if (ModelState.IsValid)
            {
                _context.Recoletas.Add(recoleta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["StatusList"] = new SelectList(await _context.Status.ToListAsync(), "Id", "Nome");
            ViewData["MotivosList"] = new SelectList(await _context.Motivos.ToListAsync(), "Id", "Nome");
            ViewData["LocaisList"] = new SelectList(await _context.Localidades.ToListAsync(), "Id", "Nome");

            return View(recoleta);
        }

        // GET: Recoletas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            // Busca os Status no banco de dados
            var statusList = await _context.Status.ToListAsync();

            // Busca os motivos no banco de dados
            var motivosList = await _context.Motivos.ToListAsync();

            // Busca as localidades no banco de dados
            var locaisList = await _context.Localidades.ToListAsync();

            // Envia a lista de Status,Motivos e Localidades para a View usando ViewData
            ViewData["StatusList"] = new SelectList(statusList, "Id", "Nome");
            ViewData["MotivosList"] = new SelectList(motivosList, "Id", "Nome");
            ViewData["LocaisList"] = new SelectList(locaisList, "Id", "Nome");

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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Empresa,TecnicoResponsavel,DataRecoleta,LocalidadesId,Serie,NumeroOS,NomePaciente,Exame,MotivosId,LaboratorioApoio,BioquimicoResponsavel,DataContato,StatusId,ColetaConcluida")] RecoletaDTO recoletaDto)
        {

            if (recoletaDto.BioquimicoResponsavel == null && recoletaDto.DataContato == null)
            {
                recoletaDto.BioquimicoResponsavel = "";
                recoletaDto.DataContato = new DateTime();

            }

            var recoleta = new Recoleta
            {
                Id = recoletaDto.Id,
                Empresa = recoletaDto.Empresa.ToUpper(),
                TecnicoResponsavel = recoletaDto.TecnicoResponsavel.ToUpper(),
                DataRecoleta = recoletaDto.DataRecoleta,
                LocalidadesId = recoletaDto.LocalidadesId,
                Serie = recoletaDto.Serie,
                NumeroOS = recoletaDto.NumeroOS,
                NomePaciente = recoletaDto.NomePaciente.ToUpper(),
                Exame = recoletaDto.Exame.ToUpper(),
                MotivosId = recoletaDto.MotivosId,
                LaboratorioApoio = recoletaDto.LaboratorioApoio.ToUpper(),
                BioquimicoResponsavel = recoletaDto?.BioquimicoResponsavel.ToUpper(),
                DataContato = recoletaDto?.DataContato,
                StatusId = recoletaDto.StatusId,
                ColetaConcluida = recoletaDto.ColetaConcluida
            };

            ViewData["StatusList"] = new SelectList(await _context.Status.ToListAsync(), "Id", "Nome");
            ViewData["MotivosList"] = new SelectList(await _context.Motivos.ToListAsync(), "Id", "Nome");
            ViewData["LocaisList"] = new SelectList(await _context.Localidades.ToListAsync(), "Id", "Nome");

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
