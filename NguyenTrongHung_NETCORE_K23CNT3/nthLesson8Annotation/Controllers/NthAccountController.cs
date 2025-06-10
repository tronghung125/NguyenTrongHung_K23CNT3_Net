using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nthLesson8Annotation.Models;

namespace nthLesson8Annotation.Controllers
{
    public class NthAccountController : Controller
    {
        private static List<NthAccount> nthListAccount = new List<NthAccount>()
        {
            new NthAccount
            {
                NthId = 231090039,// V 230900039 
                NthFullName = "Nguyễn Trọng Hưng",
                NthEmail = "tronghung122005@gmail.com",
                NthPhone = "0329930596",
                NthAddress = "Hà Nội",
                NthAvatar = "avatar1.jpg",
                NthBirthday = new DateTime(2000, 1, 2),
                NthGender = "Nam",
                NthPassword = "matkhau1",
                NthFacebook = "https://facebook.com/dkjfh"
            },
            new NthAccount
            {
                NthId = 2,
                NthFullName = "Trần Thị B",
                NthEmail = "tranthib@example.com",
                NthPhone = "0987654321",
                NthAddress = "456 Đường B, Quận 2",
                NthAvatar = "avatar2.jpg",
                NthBirthday = new DateTime(1999, 5, 10),
                NthGender = "Nữ",
                NthPassword = "matkhau2",
                NthFacebook = "https://facebook.com/tranthib"
            },
            new NthAccount
            {
                NthId = 3,
                NthFullName = "Lê Văn C",
                NthEmail = "levanc@example.com",
                NthPhone = "0901234567",
                NthAddress = "789 Đường C, Quận 3",
                NthAvatar = "avatar3.jpg",
                NthBirthday = new DateTime(2001, 3, 20),
                NthGender = "Nam",
                NthPassword = "matkhau3",
                NthFacebook = "https://facebook.com/levanc"
            },
            new NthAccount
            {
                NthId = 4,
                NthFullName = "Phạm Thị D",
                NthEmail = "phamthid@example.com",
                NthPhone = "0932123456",
                NthAddress = "321 Đường D, Quận 4",
                NthAvatar = "avatar4.jpg",
                NthBirthday = new DateTime(1998, 12, 15),
                NthGender = "Nữ",
                NthPassword = "matkhau4",
                NthFacebook = "https://facebook.com/phamthid"
            },
            new NthAccount
            {
                NthId = 5,
                NthFullName = "Hoàng Văn E",
                NthEmail = "hoangvane@example.com",
                NthPhone = "0945678910",
                NthAddress = "654 Đường E, Quận 5",
                NthAvatar = "avatar5.jpg",
                NthBirthday = new DateTime(2002, 7, 25),
                NthGender = "Nam",
                NthPassword = "matkhau5",
                NthFacebook = "https://facebook.com/hoangvane"
            }
        };
        // GET: NthAccountController
        public ActionResult NthIndex()
        {
            return View(nthListAccount);
        }

        // GET: NthAccountController/Details/5
        public ActionResult NthDetails(int id)
        {
            return View();
        }

        // GET: NthAccountController/Create
        public ActionResult NthCreate()
        {
            var nthModel = new NthAccount();
            return View();
        }

        // POST: NthAccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NthCreate(NthAccount nthModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    nthListAccount.Add(nthModel);
                    return RedirectToAction(nameof(NthIndex)); // Quay về danh sách
                }
                return View(nthModel); // Nếu không hợp lệ, quay lại form và giữ dữ liệu nhập
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Đã xảy ra lỗi: " + ex.Message);
                return View(nthModel);
            }
        }

        // GET: NthAccountController/Edit/5
        public ActionResult NthEdit(int id)
        {
            return View();
        }

        // POST: NthAccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NthEdit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NthAccountController/Delete/5
        public ActionResult NthDelete(int id)
        {
            return View();
        }

        // POST: NthAccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NthDelete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
