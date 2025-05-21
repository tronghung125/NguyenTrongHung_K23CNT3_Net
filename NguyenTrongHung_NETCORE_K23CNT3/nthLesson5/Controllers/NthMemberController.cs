using Microsoft.AspNetCore.Mvc;
using nthLesson5.Models.DataModels;

namespace nthLesson5.Controllers
{
    public class NthMemberController : Controller
    {
        // Danh sách thành viên mẫu
        private static List<NthMember> nthMemberList = new List<NthMember>
        {
            new NthMember
            {
                NthMemberID = Guid.NewGuid().ToString(),
                NthUsername = "001",
                NthFullname = "Nguyen Trong Hung",
                NthPassword = "122005",
                NthEmail = "tronghung122005@gmail.com"
            },
            new NthMember
            {
                NthMemberID = Guid.NewGuid().ToString(),
                NthUsername = "002",
                NthFullname = "Tran Thi B",
                NthPassword = "pass02",
                NthEmail = "user02@example.com"
            },
            new NthMember
            {
                NthMemberID = Guid.NewGuid().ToString(),
                NthUsername = "003",
                NthFullname = "Le Van C",
                NthPassword = "pass03",
                NthEmail = "user03@example.com"
            },
            new NthMember
            {
                NthMemberID = Guid.NewGuid().ToString(),
                NthUsername = "004",
                NthFullname = "Pham Thi D",
                NthPassword = "pass04",
                NthEmail = "user04@example.com"
            },
            new NthMember
            {
                NthMemberID = Guid.NewGuid().ToString(),
                NthUsername = "005",
                NthFullname = "Hoang Van E",
                NthPassword = "pass05",
                NthEmail = "user05@example.com"
            }
        };

        // Trang hiển thị danh sách thành viên
        public IActionResult NthIndex()
        {
            return View(nthMemberList); // truyền danh sách sang View
        }
    }
}
