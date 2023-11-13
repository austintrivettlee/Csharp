using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PnC.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PnC.Controllers;

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
        var AllProducts = _context.Products.ToList();
        return View("Index", AllProducts);
    }
    
    }
