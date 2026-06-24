using Microsoft.AspNetCore.Mvc;
using LibraryMS.Data;

namespace LibraryMS.Controllers;

public class HomeController : Controller
{
    private readonly LibraryContext _context;

    public HomeController(LibraryContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        ViewBag.TotalBooks = _context.Books.Count();
        ViewBag.TotalAuthors = _context.Authors.Count();
        ViewBag.TotalCategories = _context.Categories.Count();
        ViewBag.TotalPublishers = _context.Publisher.Count();
        ViewBag.TotalUsers = _context.Users.Count();
        ViewBag.TotalMembers = _context.Members.Count();

        return View();
    }
}