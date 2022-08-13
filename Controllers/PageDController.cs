using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PageNavigationAnalyzer.Models;

namespace PageNavigationAnalyzer.Controllers;

public class PageDController : Controller
{
    private readonly ILogger<PageDController
> _logger;

    public PageDController
(ILogger<PageDController
> logger)
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

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
