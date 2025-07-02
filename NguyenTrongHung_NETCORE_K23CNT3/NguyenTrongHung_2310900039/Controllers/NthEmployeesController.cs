// Controller: NthEmployeesController.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NguyenTrongHung_2310900039.Models;

namespace NguyenTrongHung_2310900039.Controllers
{
    public class NthEmployeesController : Controller
    {
        private readonly NguyenTrongHung2310900039Context _context;

        public NthEmployeesController(NguyenTrongHung2310900039Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> NthIndex()
        {
            return View(await _context.NthEmployees.ToListAsync());
        }

        public async Task<IActionResult> NthDetails(int? NthId)
        {
            if (NthId == null) return NotFound();
            var emp = await _context.NthEmployees.FirstOrDefaultAsync(m => m.NthEmpId == NthId);
            return emp == null ? NotFound() : View(emp);
        }

        public IActionResult NthCreate() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NthCreate(NthEmployee emp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NthIndex));
            }
            return View(emp);
        }

        public async Task<IActionResult> NthEdit(int? NthId)
        {
            if (NthId == null) return NotFound();
            var emp = await _context.NthEmployees.FindAsync(NthId);
            return emp == null ? NotFound() : View(emp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NthEdit(int NthId, NthEmployee emp)
        {
            if (NthId != emp.NthEmpId) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.NthEmployees.Any(e => e.NthEmpId == emp.NthEmpId))
                        return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(NthIndex));
            }
            return View(emp);
        }

        public async Task<IActionResult> NthDelete(int? NthId)
        {
            if (NthId == null) return NotFound();
            var emp = await _context.NthEmployees.FirstOrDefaultAsync(m => m.NthEmpId == NthId);
            return emp == null ? NotFound() : View(emp);
        }

        [HttpPost, ActionName("NthDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NthDeleteConfirmed(int NthId)
        {
            var emp = await _context.NthEmployees.FindAsync(NthId);
            if (emp != null)
            {
                _context.NthEmployees.Remove(emp);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(NthIndex));
        }
    }
}