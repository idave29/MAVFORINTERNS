using MAV.Web.Data;
using MAV.Web.Data.Entities;
using MAV.Web.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MAV.Web.Controllers
{
    public class LoanDetailsController : Controller
    {
        private readonly DataContext _context;

        private readonly ILoanDetailRepository loanDetailRepository;

        public LoanDetailsController(ILoanDetailRepository loanDetailRepository)
        {
            this.loanDetailRepository = loanDetailRepository;
        }

        // GET: LoanDetails
        public IActionResult Index()
        {
            return View(this.loanDetailRepository.GetLoanDetailsWithMaterialAndLoan());
        }

        // GET: LoanDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanDetail = await _context.LoanDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loanDetail == null)
            {
                return NotFound();
            }

            return View(loanDetail);
        }

        // GET: LoanDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoanDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Observations,DateTimeOut,DateTimeIn")] LoanDetail loanDetail)
        {
            if (ModelState.IsValid)
            {
                await this.loanDetailRepository.CreateAsync(loanDetail);
                return RedirectToAction(nameof(Index));
            }
            return View(loanDetail);
        }

        // GET: LoanDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanDetail = await _context.LoanDetails.FindAsync(id);
            if (loanDetail == null)
            {
                return NotFound();
            }
            return View(loanDetail);
        }

        // POST: LoanDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Observations,DateTimeOut,DateTimeIn")] LoanDetail loanDetail)
        {
            if (id != loanDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loanDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoanDetailExists(loanDetail.Id))
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
            return View(loanDetail);
        }

        // GET: LoanDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loanDetail = await _context.LoanDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loanDetail == null)
            {
                return NotFound();
            }

            return View(loanDetail);
        }

        // POST: LoanDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var loanDetail = await _context.LoanDetails.FindAsync(id);
            _context.LoanDetails.Remove(loanDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoanDetailExists(int id)
        {
            return _context.LoanDetails.Any(e => e.Id == id);
        }
    }
}
