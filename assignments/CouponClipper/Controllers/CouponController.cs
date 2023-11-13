using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using CouponClipper.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Linq;

[SessionCheck]
public class CouponController : Controller
{
    private readonly ILogger<CouponController> _logger;
    private MyContext _context;

    public CouponController(ILogger<CouponController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }


    [HttpGet("Coupon/Home")]
    public IActionResult HomeCoupon()
    {
        List<Coupon> AllCoupons = _context.Coupons.Include(c => c.Creator).Include(c => c.Users).ThenInclude(u => u.User).ToList();
        return View("Home", AllCoupons);
    }

    [HttpGet("Coupon/New")]
    public IActionResult NewCoupon()
    {
        return View("New");
    }
    [HttpPost("Coupon/Create")]
    public IActionResult CreateCoupon(Coupon newCoupon)
    {
        if (ModelState.IsValid)
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            newCoupon.UserId = userId ?? 0;
            _context.Add(newCoupon);
            _context.SaveChanges();
            return RedirectToAction("Home");
        }
        else
        {
            return View("New", newCoupon);
        }
    }
    [HttpPost("/coupon/usecoupon/{id}")]
    public IActionResult AddUse(int id)
    {
        int? userId = HttpContext.Session.GetInt32("UserId");
        Utilize newUtilized = new Utilize
        {
            CouponId = id,
            UserId = userId.Value
        };
        _context.Utilized.Add(newUtilized);
        _context.SaveChanges();

        return RedirectToAction("Home");

    }

    public class SessionCheckAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int? userId = context.HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                context.Result = new RedirectToActionResult("Index", "Home", null);
            }
        }
    }

}