using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LoanApp.Models;
using LoanApp.dbContext;

namespace LoanApp.Controllers
{
    public class loansController : Controller
    {
        private readonly LoanAppDbContext _context;

        public loansController(LoanAppDbContext context)
        {
            _context = context;
        }

        // GET: loans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Loans.ToListAsync());
        }

        // GET: loans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loans = await _context.Loans
                .FirstOrDefaultAsync(m => m.loanId == id);
            if (loans == null)
            {
                return NotFound();
            }

            return View(loans);
        }

        // GET: loans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: loans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("loanId,loanType,interestRate")] loans loans)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loans);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loans);
        }

        // GET: loans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loans = await _context.Loans.FindAsync(id);
            if (loans == null)
            {
                return NotFound();
            }
            return View(loans);
        }

        // POST: loans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("loanId,loanType,interestRate")] loans loans)
        {
            if (id != loans.loanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loans);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!loansExists(loans.loanId))
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
            return View(loans);
        }

        // GET: loans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loans = await _context.Loans
                .FirstOrDefaultAsync(m => m.loanId == id);
            if (loans == null)
            {
                return NotFound();
            }

            return View(loans);
        }

        // POST: loans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loans = await _context.Loans.FindAsync(id);
            _context.Loans.Remove(loans);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool loansExists(int id)
        {
            return _context.Loans.Any(e => e.loanId == id);
        }
    }
}
