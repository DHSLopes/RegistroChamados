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
    public class ColaboradorController : Controller
    {
        private readonly AppDbContext _context;

        public ColaboradorController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Colaborador
        public async Task<IActionResult> Index()
        {
            return View(await _context.Colaborador.ToListAsync());
        }

        // GET: Colaborador/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboradorModel = await _context.Colaborador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colaboradorModel == null)
            {
                return NotFound();
            }

            return View(colaboradorModel);
        }

        // GET: Colaborador/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Colaborador/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Status,SetorId")] ColaboradorModel colaboradorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colaboradorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(colaboradorModel);
        }

        // GET: Colaborador/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboradorModel = await _context.Colaborador.FindAsync(id);
            if (colaboradorModel == null)
            {
                return NotFound();
            }
            return View(colaboradorModel);
        }

        // POST: Colaborador/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Status,SetorId")] ColaboradorModel colaboradorModel)
        {
            if (id != colaboradorModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colaboradorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColaboradorModelExists(colaboradorModel.Id))
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
            return View(colaboradorModel);
        }

        // GET: Colaborador/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colaboradorModel = await _context.Colaborador
                .FirstOrDefaultAsync(m => m.Id == id);
            if (colaboradorModel == null)
            {
                return NotFound();
            }
            else
            {
                _context.Colaborador.Remove(colaboradorModel);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // POST: Colaborador/Delete/5

        private bool ColaboradorModelExists(int id)
        {
            return _context.Colaborador.Any(e => e.Id == id);
        }
    }
}
