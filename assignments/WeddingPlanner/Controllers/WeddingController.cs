using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Controllers;

[SessionCheck]
public class WeddingController : Controller
{
    private readonly ILogger<WeddingController> _logger;
    private MyContext _context;

    public WeddingController(ILogger<WeddingController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("/weddings")]
    public IActionResult Weddings()
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        List<Wedding> AllWeddings = _context.Weddings.Include(w => w.Attendees).ToList();
        ViewBag.UserId = userId;
        return View("Weddings", AllWeddings);
    }


    [HttpGet("/wedding/new")]
    public IActionResult NewWeddings()
    {
        return View("New");
    }


    [HttpPost("/wedding/create")]
    public IActionResult CreateWedding(Wedding newWedding)
    {
        if (DateTime.Today > newWedding.Date)
        {
            ModelState.AddModelError("Date", "Wedding must be planned in the future.");
        }
        if (ModelState.IsValid)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("NewWeddings", newWedding);
            }
            newWedding.UserId = userId.Value;
            _context.Add(newWedding);
            _context.SaveChanges();
            return RedirectToAction("Weddings");
        }
        else
        {
            return View("New", newWedding);
        }
    }

    [HttpGet("/wedding/view/{id}")]
    public IActionResult WeddingView(int id)
    {
        Wedding? wedding = _context.Weddings.Where(w => w.WeddingId == id).Include(w => w.Attendees).ThenInclude(a => a.User).FirstOrDefault();
        return View("View", wedding);
    }

    [HttpPost("/wedding/RSVP/{id}")]
    public IActionResult AddRSVP(int id)
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        Association newAssociation = new Association
        {
            WeddingId = id,
            UserId = userId.Value
        };
        _context.Associations.Add(newAssociation);
        _context.SaveChanges();

        return RedirectToAction("Weddings");
    }
    [HttpPost("/wedding/UNRSVP/{id}")]
    public IActionResult RemoveRSVP(int id)
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        Association oldAssociation = _context.Associations.FirstOrDefault(a => a.WeddingId == id && a.UserId == userId.Value);
            _context.Associations.Remove(oldAssociation!);
            _context.SaveChanges();
        return RedirectToAction("Weddings");
    }


    [HttpPost("/Wedding/delete/{id}")]
    public IActionResult WeddingDelete(int id)
    {
        Wedding? OldWedding = _context.Weddings.FirstOrDefault(d => d.WeddingId == id);
        if (OldWedding == null)
        {
            return RedirectToAction("Index", "Home");
        }

        _context.Weddings.Remove(OldWedding);
        _context.SaveChanges();

        return RedirectToAction("Index", "Home");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

