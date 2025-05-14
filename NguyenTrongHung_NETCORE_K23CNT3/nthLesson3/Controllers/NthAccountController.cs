using Microsoft.AspNetCore.Mvc;
using nthLesson3.Models;
using System.Security.Principal;

namespace nthLesson3.Controllers
{
    public class NthAccountController : Controller
    {
        public IActionResult NthIndex()
        {
            List<NthAccount> accounts = new List<NthAccount>
            {
                new NthAccount()
                {
                    NthId = 1,
                    NthName = "Nguyen Trong Hung",
                    NthEmail = "tronghung122005@gmail.com",
                    NthPhone = "0329930596",
                    NthAddress = "Ha Noi",
                    NthAvatar = Url.Content("~/Avatar/avt1.jpg"),
                    NthGender = 1,
                    NthBio = "idk",
                    NthBirthday = new DateTime(2005, 2, 1)
                },
                new NthAccount()
                {
                    NthId = 2,
                    NthName = "Nguyen Van A",
                    NthEmail = "vana@example.com",
                    NthPhone = "0984915173",
                    NthAddress = "Ha Noi",
                    NthAvatar = Url.Content("~/Avatar/avt2.jpg"),
                    NthGender = 1,
                    NthBio = "Student",
                    NthBirthday = new DateTime(2005, 5, 29)
                },
                new NthAccount()
                {
                    NthId = 3,
                    NthName = "Tran Thi B",
                    NthEmail = "thib@example.com",
                    NthPhone = "0912345678",
                    NthAddress = "Hai Phong",
                    NthAvatar = Url.Content("~/Avatar/avt3.jpg"),
                    NthGender = 0,
                    NthBio = "Designer",
                    NthBirthday = new DateTime(2004, 12, 15)
                },
            };
            ViewBag.Accounts = accounts;
            return View();
        }

        public IActionResult NthProfile()
        {
            NthAccount account = new NthAccount()
            {
                NthId = 1,
                NthName = "Nguyen Trong Hung",
                NthEmail = "tronghung122005@gmail.com",
                NthPhone = "0329930596",
                NthAddress = "Ha Noi",
                NthAvatar = Url.Content("~/Avatar/avt1.jpg"),
                NthGender = 1,
                NthBio = "idk",
                NthBirthday = new DateTime(2005, 5, 29)
            };
            ViewBag.Account = account;
            return View();
        }
    }
}
