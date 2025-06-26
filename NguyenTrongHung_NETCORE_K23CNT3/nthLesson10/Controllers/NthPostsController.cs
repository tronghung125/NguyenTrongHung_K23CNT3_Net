using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nthLesson10.Models;

namespace nthLesson10.Controllers
{
    public class NthPostsController : Controller
    {
        private readonly NthK23cnt3Lesson10dbContext _context;

        public NthPostsController(NthK23cnt3Lesson10dbContext context)
        {
            _context = context;
        }

        // GET: NthPosts
        public async Task<IActionResult> NthIndex()
        {
            return View(await _context.NthPosts.ToListAsync());
        }

        // GET: NthPosts/NthDetails/5
        public async Task<IActionResult> NthDetails(int? nthId)
        {
            if (nthId == null)
                return BadRequest(); // Hoặc return NotFound();

            var nthPost = await _context.NthPosts
                .FirstOrDefaultAsync(m => m.NthId == nthId);

            if (nthPost == null)
                return NotFound();

            return View(nthPost);
        }

        // GET: NthPosts/NthCreate
        public IActionResult NthCreate()
        {
            return View();
        }

        // POST: NthPosts/NthCreate
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NthCreate([Bind("NthId,NthTitle,NthImage,NthContent,NthStatus")] NthPost nthPost, IFormFile NthImage)
        {
            if (NthImage == null || NthImage.Length == 0)
            {
                ModelState.AddModelError("NthImage", "Vui lòng chọn ảnh đại diện.");
                return View(nthPost);
            }

            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileNameWithoutExtension(NthImage.FileName);
                var extension = Path.GetExtension(NthImage.FileName);
                var newFileName = $"{fileName}_{DateTime.Now:yyyyMMddHHmmss}{extension}";
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", newFileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await NthImage.CopyToAsync(stream);
                }

                nthPost.NthImage = "images/" + newFileName;
                nthPost.NthStatus = nthPost.NthStatus ?? false;

                _context.Add(nthPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(NthIndex));
            }

            return View(nthPost);
        }

        // GET: NthPosts/NthEdit/5
        public async Task<IActionResult> NthEdit(int? nthId)
        {
            if (nthId == null)
                return NotFound();

            var nthPost = await _context.NthPosts.FindAsync(nthId);
            if (nthPost == null)
                return NotFound();

            return View(nthPost);
        }

        // POST: NthPosts/NthEdit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NthEdit(int nthId, [Bind("NthId,NthTitle,NthImage,NthContent,NthStatus")] NthPost nthPost, IFormFile NthImage)
        {
            if (nthId != nthPost.NthId)
                return NotFound();

            if (ModelState.IsValid)
            {
                if (NthImage != null && NthImage.Length > 0)
                {
                    var oldPost = await _context.NthPosts.AsNoTracking().FirstOrDefaultAsync(p => p.NthId == nthId);
                    if (!string.IsNullOrEmpty(oldPost?.NthImage))
                    {
                        var oldImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", oldPost.NthImage);
                        if (System.IO.File.Exists(oldImagePath))
                            System.IO.File.Delete(oldImagePath);
                    }

                    var fileName = Path.GetFileNameWithoutExtension(NthImage.FileName);
                    var extension = Path.GetExtension(NthImage.FileName);
                    var newFileName = $"{fileName}_{DateTime.Now:yyyyMMddHHmmss}{extension}";
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", newFileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await NthImage.CopyToAsync(stream);
                    }

                    nthPost.NthImage = "images/" + newFileName;
                }

                try
                {
                    _context.Update(nthPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NthPostExists(nthPost.NthId))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(NthIndex));
            }

            return View(nthPost);
        }

        // GET: NthPosts/NthDelete/5
        public async Task<IActionResult> NthDelete(int? nthId)
        {
            if (nthId == null)
                return NotFound();

            var nthPost = await _context.NthPosts.FirstOrDefaultAsync(m => m.NthId == nthId);
            if (nthPost == null)
                return NotFound();

            return View(nthPost);
        }

        // POST: NthPosts/NthDelete/5
        [HttpPost, ActionName("NthDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int nthId)
        {
            var nthPost = await _context.NthPosts.FindAsync(nthId);
            if (nthPost != null)
            {
                if (!string.IsNullOrEmpty(nthPost.NthImage))
                {
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", nthPost.NthImage);
                    if (System.IO.File.Exists(imagePath))
                        System.IO.File.Delete(imagePath);
                }

                _context.NthPosts.Remove(nthPost);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(NthIndex));
        }

        private bool NthPostExists(int id)
        {
            return _context.NthPosts.Any(e => e.NthId == id);
        }
    }
}
