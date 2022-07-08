using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using UI.Home.Models;

namespace UI.Home;

public class HomeController : Controller
{
    public IActionResult Index() => View();
    public IActionResult Customers() => RedirectToAction("Index", "Customers");
    public IActionResult Products() => RedirectToAction("Index", "Products");
    public IActionResult Employees() => RedirectToAction("Index", "Employees");
    public IActionResult Sales() => RedirectToAction("Index", "Sales");

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}