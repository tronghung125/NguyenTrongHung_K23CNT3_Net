using Microsoft.AspNetCore.Mvc;
using nthLesson6.Models;

namespace nthLesson6.Controllers
{
    public class NthEmployeeController : Controller
    {
        private static List<NthEmployee> nthEmployeeList = new List<NthEmployee>
        {
            new NthEmployee { NthId = "1", NthName = "Nguyễn Trọng Hưng", NthBirthDay = new DateTime(2005, 1, 2), NthEmail = "tronghung122005gmail.com", NthPhone = "0329930596", NthSalary = 10000000, NthStatus = true },
            new NthEmployee { NthId = "2", NthName = "Trần Thị B", NthBirthDay = new DateTime(1992, 2, 2), NthEmail = "b@example.com", NthPhone = "0922222222", NthSalary = 12000000, NthStatus = false },
            new NthEmployee { NthId = "3", NthName = "Lê Văn C", NthBirthDay = new DateTime(1988, 3, 3), NthEmail = "c@example.com", NthPhone = "0933333333", NthSalary = 9000000, NthStatus = true },
            new NthEmployee { NthId = "4", NthName = "Phạm Thị D", NthBirthDay = new DateTime(1995, 4, 4), NthEmail = "d@example.com", NthPhone = "0944444444", NthSalary = 11000000, NthStatus = true },
            new NthEmployee { NthId = "5", NthName = "Hoàng Văn E", NthBirthDay = new DateTime(1993, 5, 5), NthEmail = "e@example.com", NthPhone = "0955555555", NthSalary = 9500000, NthStatus = false },
        };

        public IActionResult NthIndex()
        {
            return View(nthEmployeeList);
        }

        [HttpGet]
        public IActionResult NthCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NthCreateSubmit(NthEmployee nthNewEmployee)
        {
            if (ModelState.IsValid)
            {
                nthEmployeeList.Add(nthNewEmployee);
                return RedirectToAction("NthIndex");
            }
            return View(nthNewEmployee);
        }

        [HttpGet]
        public IActionResult NthEdit(string nthId)
        {
            var nthEmp = nthEmployeeList.FirstOrDefault(e => e.NthId == nthId);
            if (nthEmp == null) return NotFound();
            return View(nthEmp);
        }

        [HttpPost]
        public IActionResult NthEditSubmit(NthEmployee nthUpdatedEmployee)
        {
            var nthEmp = nthEmployeeList.FirstOrDefault(e => e.NthId == nthUpdatedEmployee.NthId);
            if (nthEmp == null) return NotFound();

            nthEmp.NthName = nthUpdatedEmployee.NthName;
            nthEmp.NthBirthDay = nthUpdatedEmployee.NthBirthDay;
            nthEmp.NthEmail = nthUpdatedEmployee.NthEmail;
            nthEmp.NthPhone = nthUpdatedEmployee.NthPhone;
            nthEmp.NthSalary = nthUpdatedEmployee.NthSalary;
            nthEmp.NthStatus = nthUpdatedEmployee.NthStatus;

            return RedirectToAction("NthIndex");
        }

        [HttpGet]
        public IActionResult NthDelete(string nthId)
        {
            var nthEmp = nthEmployeeList.FirstOrDefault(e => e.NthId == nthId);
            if (nthEmp == null) return NotFound();
            return View(nthEmp);
        }

        [HttpPost]
        public IActionResult NthDeleteConfirm(string nthId)
        {
            var nthEmp = nthEmployeeList.FirstOrDefault(e => e.NthId == nthId);
            if (nthEmp != null)
            {
                nthEmployeeList.Remove(nthEmp);
            }
            return RedirectToAction("NthIndex");
        }
    }
}
