
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryMS.Models;
using LibraryMS.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

public class BookCopiesController : Controller
{
    private readonly LibraryContext _context;

    public BookCopiesController(LibraryContext context)
    {
        _context = context;
    }

    // GET: BOOKCOPYS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.BookCopies.ToListAsync());
    }

    // GET: BOOKCOPYS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var bookcopy = await _context.BookCopies
            .FirstOrDefaultAsync(m => m.CopyID == id);
        if (bookcopy == null)
        {
            return NotFound();
        }

        return View(bookcopy);
    }

    // GET: BOOKCOPYS/Create

    public IActionResult Create()
    {
        ViewBag.Books = new SelectList(
            _context.Books,
            "BookID",
            "Title"
            );
    return View();
    }

// POST: BOOKCOPYS/Create
// To protect from overposting attacks, enable the specific properties you want to bind to.
// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("CopyID,BookID,Barcode,Status")] BookCopy bookcopy)
    {
        if (ModelState.IsValid)
        {
            _context.Add(bookcopy);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        if (!await _context.Books.AnyAsync(b => b.BookID == bookcopy.BookID))
        {
            ModelState.AddModelError("BookID", "Selected book does not exist.");
        }
        ViewBag.Books = new SelectList(
        _context.Books,
        "BookID",
        "Title",
        bookcopy.BookID
        );
        return View(bookcopy);
    }

// GET: BOOKCOPYS/Edit/5
public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var bookcopy = await _context.BookCopies.FindAsync(id);
        if (bookcopy == null)
        {
            return NotFound();
        }
        return View(bookcopy);
    }

    // POST: BOOKCOPYS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("CopyID,BookID,Barcode,Status")] BookCopy bookcopy)
    {
        if (id != bookcopy.CopyID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(bookcopy);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookCopyExists(bookcopy.CopyID))
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
        return View(bookcopy);
    }

    // GET: BOOKCOPYS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var bookcopy = await _context.BookCopies
            .FirstOrDefaultAsync(m => m.CopyID == id);
        if (bookcopy == null)
        {
            return NotFound();
        }

        return View(bookcopy);
    }

    // POST: BOOKCOPYS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var bookcopy = await _context.BookCopies.FindAsync(id);
        if (bookcopy != null)
        {
            _context.BookCopies.Remove(bookcopy);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool BookCopyExists(int? id)
    {
        return _context.BookCopies.Any(e => e.CopyID == id);
    }
}
