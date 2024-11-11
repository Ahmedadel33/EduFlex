using Microsoft.AspNetCore.Mvc;
using EduFlex.Data;
using EduFlex.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EduFlex.Controllers
{
    public class CourseController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CourseController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Course
        public IActionResult Index()
        {

            List<Course> courses = _context.Courses.Include(c => c.Teacher).ToList();
            return View(courses);
        }

        // GET: Course/Create
        public IActionResult Create()
        {
            ViewBag.Teachers = _context.Teachers.ToList();
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            
             _context.Courses.Add(course);
             _context.SaveChanges(); 
            ViewBag.Teachers = _context.Teachers.ToList();
            return RedirectToAction("Index");
        }

        // GET: Course/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var course = _context.Courses.Include(c => c.Teacher).FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            ViewBag.Teachers = _context.Teachers.ToList();
            return View(course);
        }

        // POST: Course/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Course course)
        {
           
             _context.Update(course);
             _context.SaveChanges();
       
            ViewBag.Teachers = _context.Teachers.ToList();
            return RedirectToAction(nameof(Index));

        }

        // GET: Course/Delete/5
        public IActionResult Delete(int? id)
        {
            var course = _context.Courses.Include(c => c.Teacher).FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var course = _context.Courses.Find(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
