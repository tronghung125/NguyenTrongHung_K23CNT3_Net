using Microsoft.AspNetCore.Mvc;
using nthLesson6.Models;
using System.Diagnostics;

namespace nthLesson6.Controllers
{
    public class NthHomeController : Controller
    {
        private readonly ILogger<NthHomeController> _logger;

        public NthHomeController(ILogger<NthHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult NthIndex()
        {
            return View();
        }

        public IActionResult NthAbout()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
