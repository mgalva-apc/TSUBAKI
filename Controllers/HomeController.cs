using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TSUBAKI.Models;
using TSUBAKI.Security;
using System.Security.Claims;

namespace TSUBAKI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult AboutUs()
    {
        return View();
    }

    public IActionResult SignUp()
    {
        return View();
    }

    public ActionResult Login()
    {
        return View();
    }

    [AuthorizeRoles("Staff", "Client")]
    public IActionResult Booking()
    {
        return View();
    }

    [AuthorizeRoles("Staff", "Client")]
    public IActionResult ViewAppoint()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
