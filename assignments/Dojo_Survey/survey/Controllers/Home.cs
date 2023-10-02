using SurveyApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace SurveyApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Submit(FormModel model)
        {
            if (ModelState.IsValid)
            {
                return View("Result", model);
            }
            return View("Index");
        }
    }
}