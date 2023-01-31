using BikeVale.Data;
using BikeVale.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bike.Controllers
{
    public class BicicletasController : Controller
    {
        private readonly Contexto _context;

        public BicicletasController(Contexto context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // GET: Bicicletas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bicicletas.ToListAsync());
        }

        // GET: Bicicletas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicicleta = await _context.Bicicletas
                .FirstOrDefaultAsync(m => m.IdBicicleta == id);
            if (bicicleta == null)
            {
                return NotFound();
            }

            return View(bicicleta);
        }

        // GET: Bicicletas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bicicletas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBicicleta,Modelo,Modalidade,QtdMarchas,StatusEmprestimo")] Bicicleta bicicleta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bicicleta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bicicleta);
        }

        // GET: Bicicletas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicicleta = await _context.Bicicletas.FindAsync(id);
            if (bicicleta == null)
            {
                return NotFound();
            }
            return View(bicicleta);
        }

        // POST: Bicicletas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBicicleta,Modelo,Modalidade,QtdMarchas,StatusEmprestimo")] Bicicleta bicicleta)
        {
            if (id != bicicleta.IdBicicleta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bicicleta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BicicletaExists(bicicleta.IdBicicleta))
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
            return View(bicicleta);
        }
        // GET: Bicicletas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bicicleta = await _context.Bicicletas
                .FirstOrDefaultAsync(m => m.IdBicicleta == id);
            if (bicicleta == null)
            {
                return NotFound();
            }

            return View(bicicleta);
        }

        // POST: Bicicletas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bicicleta = await _context.Bicicletas.FindAsync(id);
            _context.Bicicletas.Remove(bicicleta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool BicicletaExists(int id)
        {
            return _context.Bicicletas.Any(e => e.IdBicicleta == id);
        }
    }
}
