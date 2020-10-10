using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalWorkOrders.Models;

namespace RentalWorkOrders.Controllers
{
    public class ResidentsController : Controller
    {
        private readonly RentalWorkOrdersDbContext _context;

        public ResidentsController(RentalWorkOrdersDbContext context)
        {
            _context = context;
        }

        // GET: Residents
        public async Task<IActionResult> Index()
        {
            return View(await _context.Residents.ToListAsync());
        }

        // GET: Residents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var residents = await _context.Residents
                .FirstOrDefaultAsync(m => m.ResidentId == id);
            if (residents == null)
            {
                return NotFound();
            }

            return View(residents);
        }

        // GET: Residents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Residents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResidentId,FirstName,LastName,Address,UnitNumber,City,State,Zip,Phone,Email,DateCreated")] Residents residents)
        {
            if (ModelState.IsValid)
            {
                _context.Add(residents);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(residents);
        }

        // GET: Residents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var residents = await _context.Residents.FindAsync(id);
            if (residents == null)
            {
                return NotFound();
            }
            return View(residents);
        }

        // POST: Residents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResidentId,FirstName,LastName,Address,UnitNumber,City,State,Zip,Phone,Email,DateCreated")] Residents residents)
        {
            if (id != residents.ResidentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(residents);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResidentsExists(residents.ResidentId))
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
            return View(residents);
        }

        // GET: Residents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var residents = await _context.Residents
                .FirstOrDefaultAsync(m => m.ResidentId == id);
            if (residents == null)
            {
                return NotFound();
            }

            return View(residents);
        }

        // POST: Residents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var residents = await _context.Residents.FindAsync(id);
            _context.Residents.Remove(residents);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResidentsExists(int id)
        {
            return _context.Residents.Any(e => e.ResidentId == id);
        }
    }
}
