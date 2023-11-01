using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Pets.Models;

namespace Pets.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [HttpGet("/")]
    public IActionResult Index()
    {
        return View("Index");
    }
    [HttpGet("/privacy")]
    public IActionResult Privacy()
    {
        return View("Privacy");
    }

    [HttpGet("pet/new")]
    public IActionResult PetNew()
    {
        return View("New");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
