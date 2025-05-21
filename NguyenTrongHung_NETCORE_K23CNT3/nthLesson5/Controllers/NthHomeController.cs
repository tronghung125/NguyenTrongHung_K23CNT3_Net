using Microsoft.AspNetCore.Mvc;
using nthLesson5.Models;
using nthLesson5.Models.DataModels;
using System.Diagnostics;
using nthLesson5.Models.DataModels;


namespace nthLesson5.Controllers
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
            NthMember NthMember = new NthMember();

            NthMember.NthMemberID = Guid.NewGuid().ToString();
            NthMember.NthUsername = "tronghung122005";
            NthMember.NthFullname = "Nguyen Trong Hung";
            NthMember.NthPassword = "122005";
            NthMember.NthEmail = "tronghung122005@gmail.com";

            ViewBag.member = NthMember;
            return View(NthMember);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
