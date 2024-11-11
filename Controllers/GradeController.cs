using Microsoft.AspNetCore.Mvc;
using EduFlex.Data;
using EduFlex.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EduFlex.Controllers
{
    public class GradeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GradeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Grade
        public IActionResult Index()
        {

            List<Grade> grades = _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Course)
                .ToList();
            return View(grades);
        }

        // GET: Grade/Create
        public IActionResult Create()
        {
            ViewBag.Students = _context.Students.ToList();
            ViewBag.Courses = _context.Courses.ToList();
            return View();
        }

        // POST: Grade/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Grade grade)
        {
            
                _context.Grades.Add(grade);
                _context.SaveChanges();
            
            ViewBag.Students = _context.Students.ToList();
            ViewBag.Courses = _context.Courses.ToList();
            return RedirectToAction("Index");
        }

        // GET: Grade/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Grade? grade = _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Course)
                .FirstOrDefault(g => g.Id == id);

            if (grade == null)
            {
                return NotFound();
            }

            ViewBag.Students = _context.Students.ToList();
            ViewBag.Courses = _context.Courses.ToList();
            return View(grade);
        }

        // POST: Grade/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Grade grade)
        {
           
                _context.Update(grade);
                _context.SaveChanges();
            

            ViewBag.Students = _context.Students.ToList();
            ViewBag.Courses = _context.Courses.ToList();
            return RedirectToAction(nameof(Index));
        }


        // GET: Grade/Delete/5
        public IActionResult Delete(int? id)
        {
            var grade = _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Course)
                .FirstOrDefault(g => g.Id == id);
            if (grade == null)
            {
                return NotFound();
            }

            return View(grade);
        }

        // POST: Grade/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var grade = _context.Grades.Find(id);
            if (grade != null)
            {
                _context.Grades.Remove(grade);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
