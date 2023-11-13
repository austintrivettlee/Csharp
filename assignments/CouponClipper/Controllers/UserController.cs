using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CouponClipper.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Linq;


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
            return RedirectToAction("Home", "Coupon");
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
            return RedirectToAction("Home", "Coupon");
        }
        else
        {
            return View("/Views/Home/Index.cshtml", userSubmission);
        }
    }

    [HttpGet("/User/Account")]
    public IActionResult Account()
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        User user = _context.Users.Include(u => u.CouponsCreated).FirstOrDefault(u => u.UserId == userId.Value);

        int couponsUsedCount = _context.Utilized.Where(u => u.UserId == userId).Select(u => u.CouponId).Count();
        int myUsedCoupons = _context.Coupons.Where(c => c.UserId == userId.Value)
        .Join(_context.Utilized,coupon => coupon.CouponId,utilize => utilize.CouponId,(coupon, utilize) => utilize).Select(u => u.CouponId).Count();

        MyViewModel ViewModel = new()
        {
            User = user,
            CouponsUsedCount = couponsUsedCount,
            MyUsedCoupons = myUsedCoupons
        };

        return View("Account", ViewModel);
    }
    [HttpGet("Logout")]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Home");
    }
}
