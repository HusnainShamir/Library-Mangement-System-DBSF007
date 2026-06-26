
using LibraryMS.Data;
using LibraryMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class IssuesController : Controller
{
    private readonly LibraryContext _context;

    public IssuesController(LibraryContext context)
    {
        _context = context;
    }

    // GET: ISSUES
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Issues.ToListAsync());
    }

    // GET: ISSUES/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var issue = await _context.Issues
            .FirstOrDefaultAsync(m => m.IssueID == id);
        if (issue == null)
        {
            return NotFound();
        }

        return View(issue);
    }

    // GET: ISSUES/Create
    public IActionResult Create()
    {
        ViewBag.BookCopies = new SelectList(
            _context.BookCopies,
            "CopyID",
            "Barcode"
        );
        ViewBag.Members = new SelectList(
            _context.Members,
            "MemberID",
            "FullName"
        );
        return View();
    }

    // POST: ISSUES/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("IssueID,MemberID,CopyID,IssueDate,DueDate,ReturnDate,Member,BookCopy")] Issue issue)
    {
        if (ModelState.IsValid)
        {
            _context.Add(issue);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(issue);
    }

    // GET: ISSUES/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var issue = await _context.Issues.FindAsync(id);
        if (issue == null)
        {
            return NotFound();
        }
        return View(issue);
    }

    // POST: ISSUES/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("IssueID,MemberID,CopyID,IssueDate,DueDate,ReturnDate,Member,BookCopy")] Issue issue)
    {
        if (id != issue.IssueID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(issue);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IssueExists(issue.IssueID))
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
        return View(issue);
    }

    // GET: ISSUES/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var issue = await _context.Issues
            .FirstOrDefaultAsync(m => m.IssueID == id);
        if (issue == null)
        {
            return NotFound();
        }

        return View(issue);
    }

    // POST: ISSUES/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var issue = await _context.Issues.FindAsync(id);
        if (issue != null)
        {
            _context.Issues.Remove(issue);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool IssueExists(int? id)
    {
        return _context.Issues.Any(e => e.IssueID == id);
    }
}
