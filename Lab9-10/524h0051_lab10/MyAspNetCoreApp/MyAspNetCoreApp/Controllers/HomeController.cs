using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        // MachineName = container ID when running in Docker, so the screenshot proves it
        ViewBag.Host = Environment.MachineName;
        ViewBag.Os = System.Runtime.InteropServices.RuntimeInformation.OSDescription;
        ViewBag.Time = DateTime.UtcNow.ToString("u");
        return View();
    }
}
