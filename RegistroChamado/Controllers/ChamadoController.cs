using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RegistroChamado.Models;

namespace RegistroChamado.Controllers
{
    public class ChamadoController : Controller
    {
        private readonly AppDbContext _context;

        public ChamadoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Chamado
        public async Task<IActionResult> Index()
        {
            return View(await _context.Chamado.ToListAsync());
        }

        // GET: Chamado/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chamadoModel = await _context.Chamado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chamadoModel == null)
            {
                return NotFound();
            }

            return View(chamadoModel);
        }
        private List<SelectListItem> GetSetor()
        {
            var lstSetores = new List<SelectListItem>();
            List<SetorModel> Setor = _context.Setor.ToList();
            lstSetores = Setor.Select(se => new SelectListItem()
            {
                Value = se.Id.ToString(),
                Text = se.Descricao.ToString()
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----- SELECIONE UM SETOR -----"
            };
            lstSetores.Insert(0, defItem);
            return lstSetores;
        }

        private List<SelectListItem> GetColaborador(int IdSetor = 1)
        {
            List<SelectListItem> lstColaborador = _context.Colaborador
                .Where(c => c.SetorId == IdSetor)
                .OrderBy(n => n.Nome)
                .Select(n =>
                new SelectListItem
                {
                    Value = n.Id.ToString(),
                    Text = n.Nome
                }).ToList();
            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----- SELECIONE UM COLABORADOR -----"
            };
            lstColaborador.Insert(0, defItem);
            return lstColaborador;
        }


        // GET: Chamado/Create
        public IActionResult Create()
        {
            ViewBag.SetorId = GetSetor();
            ViewBag.ColaboradorId = GetColaborador();
            return View();
        }
        [HttpGet]
        public JsonResult GetColaboradorPorSetor(int SetorId)
        {
            List<SelectListItem> colaboradores = GetColaborador(SetorId);
            return Json(colaboradores);
        }

        // POST: Chamado/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataHora,IdSetor,IdColaborador,Titulo,Descricao,Prioridade,Status")] ChamadoModel chamadoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chamadoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chamadoModel);
        }

        // GET: Chamado/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chamadoModel = await _context.Chamado.FindAsync(id);
            if (chamadoModel == null)
            {
                return NotFound();
            }
            return View(chamadoModel);
        }

        // POST: Chamado/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DataHora,IdSetor,IdColaborador,Titulo,Descricao,Prioridade,Status")] ChamadoModel chamadoModel)
        {
            if (id != chamadoModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chamadoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChamadoModelExists(chamadoModel.Id))
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
            return View(chamadoModel);
        }

        // GET: Chamado/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chamadoModel = await _context.Chamado
                .FirstOrDefaultAsync(m => m.Id == id);
            if (chamadoModel == null)
            {
                return NotFound();
            }

            return View(chamadoModel);
        }

        // POST: Chamado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chamadoModel = await _context.Chamado.FindAsync(id);
            if (chamadoModel != null)
            {
                _context.Chamado.Remove(chamadoModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChamadoModelExists(int id)
        {
            return _context.Chamado.Any(e => e.Id == id);
        }
    }
}
