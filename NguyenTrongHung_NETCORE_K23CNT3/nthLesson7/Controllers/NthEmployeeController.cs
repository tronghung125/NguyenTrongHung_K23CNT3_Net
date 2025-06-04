using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nthLesson7.Models;

namespace nthLesson7.Controllers
{
    public class NthEmployeeController : Controller
    {
        //Mock data:
        private static List<NthEmployee> nthEmployeeList = new List<NthEmployee>
        {
            new NthEmployee
            {
                NthId = 2130900039,
                NthName = "Nguyễn Trọng Hưng",
                NthBirthDay = new DateTime(2005, 1, 2),
                NthEmail = "tronghung122005@gmail.com",
                NthPhone = "0329930596",
                NthSalary = 10000000,
                NthStatus = true
            },
            new NthEmployee
            {
                NthId = 2,
                NthName = "Trần Thị B",
                NthBirthDay = new DateTime(1992, 2, 15),
                NthEmail = "b@example.com",
                NthPhone = "0922222222",
                NthSalary = 12000000,
                NthStatus = false
            },
            new NthEmployee
            {
                NthId = 3,
                NthName = "Lê Văn C",
                NthBirthDay = new DateTime(1988, 3, 20),
                NthEmail = "c@example.com",
                NthPhone = "0933333333",
                NthSalary = 9000000,
                NthStatus = true
            },
            new NthEmployee
            {
                NthId = 4,
                NthName = "Phạm Thị D",
                NthBirthDay = new DateTime(1995, 4, 10),
                NthEmail = "d@example.com",
                NthPhone = "0944444444",
                NthSalary = 11000000,
                NthStatus = true
            },
            new NthEmployee
            {
                NthId = 5,
                NthName = "Hoàng Văn E",
                NthBirthDay = new DateTime(1993, 5, 5),
                NthEmail = "e@example.com",
                NthPhone = "0955555555",
                NthSalary = 9500000,
                NthStatus = false
            }        
        };

        // GET: NthEmployeeController
        public ActionResult NthIndex()
        {
            return View(nthEmployeeList);
        }

        // GET: NthEmployeeController/NthDetails/5
        public ActionResult NthDetails(int id)
        {
            var nthEmployee = nthEmployeeList.FirstOrDefault(x => x.NthId == id);
            return View(nthEmployee);
        }

        // GET: NthEmployeeController/NthCreate
        public ActionResult NthCreate()
        {
            var nthEmployee = new NthEmployee();
            return View(nthEmployee);
        }

        // POST: NthEmployeeController/NthCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NthCreate(NthEmployee nthModel)
        {
            try
            {
                //thêm nv vào list
                nthModel.NthId = nthEmployeeList.Max(x => x.NthId) + 1;
                nthEmployeeList.Add(nthModel);
                return RedirectToAction(nameof(NthIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: NthEmployeeController/NthEdit/5
        public ActionResult NthEdit(int id)
        {
            var nthEmployee = nthEmployeeList.FirstOrDefault(x => x.NthId == id);
            return View(nthEmployee);
        }

        // POST: NthEmployeeController/NthEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NthEdit(int id, NthEmployee nthModel)
        {
            try
            {
                for (int i = 0; i < nthEmployeeList.Count(); i++)
                {
                    if (nthEmployeeList[i].NthId == id)
                    {
                        nthEmployeeList[i] = nthModel;
                        break;
                    }
                }
                return RedirectToAction(nameof(NthIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: NthEmployeeController/NthDelete/5
        public ActionResult NthDelete(int id)
        {
            var nthEmployee = nthEmployeeList.FirstOrDefault(x => x.NthId == id);
            if (nthEmployee == null)
            {
                return NotFound();
            }
            return View(nthEmployee);
        }

        // POST: NthEmployeeController/NthDelete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NthDelete(int id, NthEmployee nthModel)
        {
            try
            {
                var nthEmployee = nthEmployeeList.FirstOrDefault(x => x.NthId == id);
                if (nthEmployee != null)
                {
                    nthEmployeeList.Remove(nthEmployee);
                }
                return RedirectToAction(nameof(NthIndex));
            }
            catch
            {
                return View();
            }
        }
    }
}
