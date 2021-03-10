using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SecondPostgreSqlTable.Data;
using SecondPostgreSqlTable.Models;

namespace SecondPostgreSqlTable.Controllers
{
    public class CarsModelsController : Controller
    {
        private readonly CarsAppContext _context;

        public CarsModelsController(CarsAppContext context)
        {
            _context = context;
        }

        // GET: CarsModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarsModel.ToListAsync());
        }

        // GET: CarsModels/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carsModel = await _context.CarsModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carsModel == null)
            {
                return NotFound();
            }

            return View(carsModel);
        }

        // GET: CarsModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CarsModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tm,V,VN,Cf,VT,Img,FImg")] CarsModel carsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(carsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(carsModel);
        }

        // GET: CarsModels/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carsModel = await _context.CarsModel.FindAsync(id);
            if (carsModel == null)
            {
                return NotFound();
            }
            return View(carsModel);
        }

        // POST: CarsModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,Tm,V,VN,Cf,VT,Img,FImg")] CarsModel carsModel)
        {
            if (id != carsModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(carsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarsModelExists(carsModel.Id))
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
            return View(carsModel);
        }

        // GET: CarsModels/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carsModel = await _context.CarsModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (carsModel == null)
            {
                return NotFound();
            }

            return View(carsModel);
        }

        // POST: CarsModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var carsModel = await _context.CarsModel.FindAsync(id);
            _context.CarsModel.Remove(carsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarsModelExists(long id)
        {
            return _context.CarsModel.Any(e => e.Id == id);
        }
    }
}
