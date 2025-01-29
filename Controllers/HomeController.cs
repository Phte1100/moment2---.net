using Microsoft.AspNetCore.Mvc;

namespace Moment2Mvc.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet("/planering")]
    public IActionResult planing()
    {
        return View();
    }
    [HttpGet("/omsidan")]
    public IActionResult About()
    {
        return View();
    }
}