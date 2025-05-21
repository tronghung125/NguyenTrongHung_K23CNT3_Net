using Microsoft.AspNetCore.Mvc;
using nthLesson4.Models;

namespace Lesson04.Controllers
{
    public class NthBookController : Controller
    {
        private List<NthBook> nthBooks = new List<NthBook>
        {
            new NthBook
            {
                NthId = "B01",
                NthTitle = "C# Programming for Beginners",
                NthDecription = "A complete guide to learning C# from scratch.",
                NthImage = "/Images/book1.jpg",
                NthPrice = 29.99f,
                NthPage = 350
            },
            new NthBook
            {
                NthId = "B02",
                NthTitle = "Mastering ASP.NET Core",
                NthDecription = "Advanced topics and real-world ASP.NET Core projects.",
                NthImage = "/Images/book2.jpg",
                NthPrice = 39.99f,
                NthPage = 480
            },
            new NthBook
            {
                NthId = "B03",
                NthTitle = "JavaScript: The Good Parts",
                NthDecription = "Essential JavaScript features every developer should know.",
                NthImage = "/Images/book3.jpg",
                NthPrice = 24.99f,
                NthPage = 210
            },
            new NthBook
            {
                NthId = "B04",
                NthTitle = "Python Crash Course",
                NthDecription = "A hands-on, project-based introduction to Python.",
                NthImage = "/Images/book4.jpg",
                NthPrice = 34.50f,
                NthPage = 400
            },
            new NthBook
            {
                NthId = "B05",
                NthTitle = "Clean Code",
                NthDecription = "A Handbook of Agile Software Craftsmanship.",
                NthImage = "/Images/book5.jpg",
                NthPrice = 44.95f,
                NthPage = 450
            }
        };

        // GET: /NthBook/Index
        public IActionResult NthIndex()
        {
            //Đưa dữ liệu lên view
            return View(nthBooks);
        }
        [HttpGet]
        public IActionResult NthCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult NthCreateSubmit(NthBook book)
        {
            nthBooks.Add(book);
            return RedirectToAction("NthIndex");
        }

        [HttpGet]
        public IActionResult NthEdit(string id)
        {
            var book = nthBooks.FirstOrDefault(b => b.NthId == id);
            if (book == null) return NotFound();
            return View(book);
        }

        [HttpPost]
        public IActionResult NthEditSubmit(NthBook updatedBook)
        {
            var book = nthBooks.FirstOrDefault(b => b.NthId == updatedBook.NthId);
            if (book == null) return NotFound();

            book.NthTitle = updatedBook.NthTitle;
            book.NthDecription = updatedBook.NthDecription;
            book.NthImage = updatedBook.NthImage;
            book.NthPrice = updatedBook.NthPrice;
            book.NthPage = updatedBook.NthPage;

            return RedirectToAction("NthIndex");
        }
        [HttpGet]
        public IActionResult NthDelete(string id)
        {
            var book = nthBooks.FirstOrDefault(b => b.NthId == id);
            if (book == null) return NotFound();
            return View(book);
        }
        [HttpPost]
        public IActionResult NthDeleteSubmit(string id)
        {
            var book = nthBooks.FirstOrDefault(b => b.NthId == id);
            if (book != null)
            {
                nthBooks.Remove(book);
            }
            return RedirectToAction("NthIndex");
        }
    }
}
