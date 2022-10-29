using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LoanApp.Models;
using LoanApp.dbContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using LoanApp.Areas.Identity.Pages.Account;





namespace LoanApp.Controllers
{
    public class userProfilesController : Controller
    {
        private readonly LoanAppDbContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        public userProfilesController(LoanAppDbContext context, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [Authorize(Roles = Utility.WC.AdminRole)]
        // GET: userProfiles
        public async Task<IActionResult> Index()
        {
            var loanAppDbContext = _context.userProfiles.Include(u => u.Loans).Include(u => u.Status).Include(u => u.Tenure);
            return View(await loanAppDbContext.ToListAsync());
        }
        
        // GET: userProfiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }
           
                var userProfile = await _context.userProfiles
                    .Include(u => u.Loans)
                    .Include(u => u.Status)
                    .Include(u => u.Tenure)
                    .FirstOrDefaultAsync(m => m.profileId == id);
            
            if (userProfile == null)
                {
                    return NotFound();
                }
          
                return View(userProfile);

        }


        //GET Info for User
        public async Task<IActionResult> Info( string loginId)
        {

          
            if (loginId == null)
            {
                return NotFound();
            }
            
            var userProfile = await _context.userProfiles
             .Include(u => u.Loans)
             .Include(u => u.Status)
             .Include(u => u.Tenure)
             .FirstOrDefaultAsync(m => m.loginId == loginId);


            if (userProfile == null)
            {
                return NotFound();
            }

            return View(userProfile);

        }

        // GET: userProfiles/Create
        public IActionResult Create()
        {
           //error solve
            string userId = _userManager.GetUserId(User);
            userProfile userProfile = new userProfile();
           
            if (_context.userProfiles.Any(a => a.loginId == userId))
            {

                return RedirectToAction("Info", new { loginId=userId});
            }
            //if (_context.userProfiles.Any(a => a.idProof == userProfile.idProof))
            //{
            //     return RedirectToAction("Info", new { idProof = userProfile.idProof });
            //}
            ViewData["loanId"] = new SelectList(_context.Loans, "loanId", "loanType");
            ViewData["statusId"] = new SelectList(_context.Statuses, "statusId", "loanStatus");
            ViewData["tenureId"] = new SelectList(_context.Tenures, "tenureId", "months");
            return View();
        }

        // POST: userProfiles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("profileId,firstName,lastName,dateOfBirth,occupation,income,idProof,loanAmount,loanId,tenureId,PhoneNumber,statusId,loginId")] userProfile userProfile)
        {
            userProfile.firstName = _userManager.GetUserName(User);
            
                userProfile.loginId = _userManager.GetUserId(User);
            TempData["login"] = userProfile.loginId;
            userProfile.statusId = 1;
           
            if (ModelState.IsValid)
            {


                if (_context.userProfiles.Any(a => a.idProof == userProfile.idProof))
                {
                    return RedirectToAction("Create");
                }
                _context.Add(userProfile);
                await _context.SaveChangesAsync();
                return RedirectToAction("Info", new { loginId = _userManager.GetUserId(User) });
            }
            ViewData["loanId"] = new SelectList(_context.Loans, "loanId", "loanType", userProfile.loanId);
            ViewData["statusId"] = new SelectList(_context.Statuses, "statusId", "loanStatus", userProfile.statusId);
            ViewData["tenureId"] = new SelectList(_context.Tenures, "tenureId", "months", userProfile.tenureId);
            return View(userProfile);
        }
        [Authorize(Roles = Utility.WC.AdminRole)]
        // GET: userProfiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProfile = await _context.userProfiles.FindAsync(id);
            if (userProfile == null)
            {
                return NotFound();
            }
            ViewData["loanId"] = new SelectList(_context.Loans, "loanId", "loanType", userProfile.loanId);
            ViewData["statusId"] = new SelectList(_context.Statuses, "statusId", "loanStatus", userProfile.statusId);
            ViewData["tenureId"] = new SelectList(_context.Tenures, "tenureId", "months", userProfile.tenureId);
            return View(userProfile);
        }
        [Authorize(Roles = Utility.WC.AdminRole)]
        // POST: userProfiles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind(include:"profileId,firstName,lastName,dateOfBirth,occupation,income,idProof,loanAmount,loanId,tenureId,PhoneNumber,statusId,loginId")] userProfile userProfile)
        {
           
            if (id != userProfile.profileId)
            {
                return NotFound();
            }
           


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userProfile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!userProfileExists(userProfile.profileId))
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
            ViewData["loanId"] = new SelectList(_context.Loans, "loanId", "loanType", userProfile.loanId);
            ViewData["statusId"] = new SelectList(_context.Statuses, "statusId", "loanStatus", userProfile.statusId);
            ViewData["tenureId"] = new SelectList(_context.Tenures, "tenureId", "months", userProfile.tenureId);
            return View(userProfile);
        }
        [Authorize(Roles = Utility.WC.AdminRole)]
        // GET: userProfiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userProfile = await _context.userProfiles
                .Include(u => u.Loans)
                .Include(u => u.Status)
                .Include(u => u.Tenure)
                .FirstOrDefaultAsync(m => m.profileId == id);
            if (userProfile == null)
            {
                return NotFound();
            }

            return View(userProfile);
        }
        [Authorize(Roles = Utility.WC.AdminRole)]
        // POST: userProfiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userProfile = await _context.userProfiles.FindAsync(id);
            _context.userProfiles.Remove(userProfile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool userProfileExists(int id)
        {
            return _context.userProfiles.Any(e => e.profileId == id);
        }


        public IActionResult applied()
        {

            return View();
        }
    }
}
