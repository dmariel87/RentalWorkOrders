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
    public class WorkOrdersController : Controller
    {
        private readonly RentalWorkOrdersDbContext _context;

        public WorkOrdersController(RentalWorkOrdersDbContext context)
        {
            _context = context;
        }

        // GET: WorkOrders
        public async Task<IActionResult> Index()
        {
            var rentalWorkOrdersDbContext = _context.WorkOrders.Include(w => w.Employee).Include(w => w.Resident).Include(w => w.Status);
            return View(await rentalWorkOrdersDbContext.ToListAsync());
        }

        // GET: WorkOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrders = await _context.WorkOrders
                .Include(w => w.Employee)
                .Include(w => w.Resident)
                .Include(w => w.Status)
                .FirstOrDefaultAsync(m => m.WorkOrderId == id);
            if (workOrders == null)
            {
                return NotFound();
            }

            return View(workOrders);
        }

        // GET: WorkOrders/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email");
            ViewData["ResidentId"] = new SelectList(_context.Residents, "ResidentId", "Address");
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Title");
            return View();
        }

        // POST: WorkOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkOrderId,Description,ResidentId,StatusId,EmployeeId,Notes,DateCompleted,DateUpdated,DateCreated")] WorkOrders workOrders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workOrders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email", workOrders.EmployeeId);
            ViewData["ResidentId"] = new SelectList(_context.Residents, "ResidentId", "Address", workOrders.ResidentId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Title", workOrders.StatusId);
            return View(workOrders);
        }

        // GET: WorkOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrders = await _context.WorkOrders.FindAsync(id);
            if (workOrders == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email", workOrders.EmployeeId);
            ViewData["ResidentId"] = new SelectList(_context.Residents, "ResidentId", "Address", workOrders.ResidentId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Title", workOrders.StatusId);
            return View(workOrders);
        }

        // POST: WorkOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkOrderId,Description,ResidentId,StatusId,EmployeeId,Notes,DateCompleted,DateUpdated,DateCreated")] WorkOrders workOrders)
        {
            if (id != workOrders.WorkOrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workOrders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkOrdersExists(workOrders.WorkOrderId))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "Email", workOrders.EmployeeId);
            ViewData["ResidentId"] = new SelectList(_context.Residents, "ResidentId", "Address", workOrders.ResidentId);
            ViewData["StatusId"] = new SelectList(_context.Statuses, "StatusId", "Title", workOrders.StatusId);
            return View(workOrders);
        }

        // GET: WorkOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workOrders = await _context.WorkOrders
                .Include(w => w.Employee)
                .Include(w => w.Resident)
                .Include(w => w.Status)
                .FirstOrDefaultAsync(m => m.WorkOrderId == id);
            if (workOrders == null)
            {
                return NotFound();
            }

            return View(workOrders);
        }

        // POST: WorkOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workOrders = await _context.WorkOrders.FindAsync(id);
            _context.WorkOrders.Remove(workOrders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkOrdersExists(int id)
        {
            return _context.WorkOrders.Any(e => e.WorkOrderId == id);
        }
    }
}
