using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefNDishes.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;


public class ChefController : Controller
{
    private readonly ILogger<ChefController> _logger;
    private MyContext _context;

    public ChefController(ILogger<ChefController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("/chef/new")]
    public ViewResult ChefNew() => View("New");


    [HttpPost("/chef/create")]
    public IActionResult CreateChef(Chef newChef)
    {
        if (DateTime.Now.AddYears(-18) < newChef.DOB)
        {
            ModelState.AddModelError("DOB", "You must be at least 18 years old.");
        }
        if (ModelState.IsValid)
        {
            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        else
        {
            return View("New", newChef);
        }
    }
}

