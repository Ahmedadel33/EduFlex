using Microsoft.AspNetCore.Mvc;
using EduFlex.Data;
using EduFlex.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace EduFlex.Controllers
{
    [Authorize(Roles =SD.Role_Admin)]
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TeacherController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Teacher
        public IActionResult Index()
        {
            var teachers = _context.Teachers.ToList();
            return View(teachers);
        }

        // GET: Teacher/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Teacher/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Teacher/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var teacher = _context.Teachers.Find(id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Teacher/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Teacher teacher)
        {
            _context.Update(teacher);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Teacher/Delete/5
        public IActionResult Delete(int? id)
        {
            var teacher = _context.Teachers.Find(id);
            if (teacher == null)
            {
                return NotFound();
            }

            return View(teacher);
        }

        // POST: Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var teacher = _context.Teachers.Find(id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
