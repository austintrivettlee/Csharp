using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MathApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string username)
        {
            HttpContext.Session.SetString("Username", username);
            HttpContext.Session.SetInt32("Value", 22);
            return RedirectToAction("Dashboard");
        }

        public IActionResult Dashboard()
        {
            var username = HttpContext.Session.GetString("Username");
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("Index");
            }
            var value = HttpContext.Session.GetInt32("Value") ?? 0;
            ViewBag.Value = value;
            return View();
        }

        [HttpPost]
        public IActionResult Operate(string operation)
        {
            var value = HttpContext.Session.GetInt32("Value") ?? 0;
            switch (operation)
            {
                case "increment":
                    value += 1;
                    break;
                case "decrement":
                    value -= 1;
                    break;
                case "double":
                    value *= 2;
                    break;
                case "random":
                    var random = new Random();
                    value += random.Next(1, 11);
                    break;
                default:
                    break;
            }
            HttpContext.Session.SetInt32("Value", value);
            return RedirectToAction("Dashboard");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}