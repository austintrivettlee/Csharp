using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefNDishes.Models;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Linq;
using Microsoft.EntityFrameworkCore;


public class DishController : Controller
{
    private readonly ILogger<DishController> _logger;
    private MyContext _context;

    public DishController(ILogger<DishController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("/dish/new")]
    public IActionResult DishNew()
    {
        ViewBag.AllChefs = _context.Chefs.ToList();
        return View("New");
    }

    [HttpPost("/dish/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if (ModelState.IsValid)
        {
            _context.Add(newDish);
            _context.SaveChanges();
            return RedirectToAction("View");
        }
        else
        {
            return View("New", newDish);
        }
    }

    [HttpGet("/Dish/View/")]
    public IActionResult DishView(int id)
    {
        List<Dish> AllDishes = _context.Dishes.Include(c => c.Creator).ToList();
        return View("View", AllDishes);
    }

    [HttpGet("/dish/edit/{id}")]
    public IActionResult DishEdit(int id)
    {
        var dish = _context.Dishes.FirstOrDefault(d => d.DishId == id);
        if (dish == null)
        {
            return RedirectToAction("Index", "Home");
        }
        return View("Edit", dish);
    }

    [HttpPost("/dish/update/{id}")]
    public IActionResult DishUpdate(Dish CurrentDish, int id)
    {
        Dish? OldDish = _context.Dishes.FirstOrDefault(d => d.DishId == id);
        if (OldDish == null)
        {
            return RedirectToAction("Index", "Home");
        }

        OldDish.Name = CurrentDish.Name;
        OldDish.ChefId = CurrentDish.ChefId;
        OldDish.Tastiness = CurrentDish.Tastiness;
        OldDish.Calories = CurrentDish.Calories;
        OldDish.Description = CurrentDish.Description;
        _context.SaveChanges();

        return RedirectToAction("Index", "Home");
    }

    [HttpPost("/dish/delete/{id}")]
    public IActionResult DishDelete(int id)
    {
        Dish? OldDish = _context.Dishes.FirstOrDefault(d => d.DishId == id);
        if (OldDish == null)
        {
            return RedirectToAction("Index", "Home");
        }

        _context.Dishes.Remove(OldDish);
        _context.SaveChanges();

        return RedirectToAction("Index", "Home");
    }
}