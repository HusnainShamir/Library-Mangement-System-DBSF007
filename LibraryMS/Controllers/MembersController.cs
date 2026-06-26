
using LibraryMS.Data;
using LibraryMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class MembersController : Controller
{
    private readonly LibraryContext _context;

    public MembersController(LibraryContext context)
    {
        _context = context;
    }

    // GET: MEMBERS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.Members.ToListAsync());
    }

    // GET: MEMBERS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var member = await _context.Members
            .FirstOrDefaultAsync(m => m.MemberID == id);
        if (member == null)
        {
            return NotFound();
        }

        return View(member);
    }

    // GET: MEMBERS/Create
    public IActionResult Create()
    {

        return View();
    }

    // POST: MEMBERS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("MemberID,UserID,FullName,Phone,Address,RegistrationDate,User")] Member member)
    {
        if (ModelState.IsValid)
        {
            _context.Add(member);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(member);
    }

    // GET: MEMBERS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var member = await _context.Members.FindAsync(id);
        if (member == null)
        {
            return NotFound();
        }
        return View(member);
    }

    // POST: MEMBERS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("MemberID,UserID,FullName,Phone,Address,RegistrationDate,User")] Member member)
    {
        if (id != member.MemberID)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(member);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberExists(member.MemberID))
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
        return View(member);
    }

    // GET: MEMBERS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var member = await _context.Members
            .FirstOrDefaultAsync(m => m.MemberID == id);
        if (member == null)
        {
            return NotFound();
        }

        return View(member);
    }

    // POST: MEMBERS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var member = await _context.Members.FindAsync(id);
        if (member != null)
        {
            _context.Members.Remove(member);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool MemberExists(int? id)
    {
        return _context.Members.Any(e => e.MemberID == id);
    }
}
