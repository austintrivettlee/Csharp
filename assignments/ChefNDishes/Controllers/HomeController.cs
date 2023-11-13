using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefNDishes.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ChefNDishes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private MyContext _context;

    public HomeController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }
    [HttpGet("")]
    public IActionResult Index()
    {
        var AllChefs = _context.Chefs.Include(c => c.AllDishes).ToList();
        return View("Index", AllChefs);
    }
    
    }
