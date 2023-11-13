using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WeddingPlanner.Models;
using Microsoft.AspNetCore.Mvc.Filters;

public class UserController : Controller
{
    private readonly ILogger<UserController> _logger;
    private MyContext _context;

    public UserController(ILogger<UserController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpPost("User/CreateUser")]
    public IActionResult Register(User newUser)
    {
        if (ModelState.IsValid)
        {
            PasswordHasher<User> Hasher = new PasswordHasher<User>();      
            newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
            _context.Add(newUser);
            _context.SaveChanges();
            HttpContext.Session.SetInt32("UserId", newUser.UserId);
            return RedirectToAction("Weddings", "Wedding");
        }
        else
        {
            return View("/Views/Home/Index.cshtml", newUser);
        }
    }
    
    [HttpPost("/User/Login")]
    public IActionResult Login(LoginUser userSubmission)
    {
        if (ModelState.IsValid)
        {
            User? userInDb = _context.Users.FirstOrDefault(u => u.Email == userSubmission.LoginEmail);
            if (userInDb == null)
            {
                ModelState.AddModelError("Email", "Invalid Email/Password");
                return View("/Views/Home/Index.cshtml", userSubmission);
            }
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            var result = hasher.VerifyHashedPassword(userSubmission, userInDb.Password, userSubmission.LoginPassword);
            if (result == 0)
            {
                ModelState.AddModelError("Email", "Invalid Email/Password");
                return View("/Views/Home/Index.cshtml", userSubmission);
            }
            HttpContext.Session.SetInt32("UserId", userInDb.UserId);
            return RedirectToAction("Weddings", "Wedding");
        }
        else
        {
            return View("/Views/Home/Index.cshtml", userSubmission);
        }
    }

    [HttpGet("Logout")]
    public IActionResult Logout()
    {   
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
    
    
}
