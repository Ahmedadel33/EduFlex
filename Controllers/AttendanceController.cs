using Microsoft.AspNetCore.Mvc;
using EduFlex.Data;
using EduFlex.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EduFlex.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AttendanceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Attendance
        public IActionResult Index()
        {
            List<Attendance>attendanceRecords = _context.Attendances
                .Include(a => a.Student)
                .Include(a => a.Course)
                .ToList();
            return View(attendanceRecords);
        }

        // GET: Attendance/Create
        public IActionResult Create()
        {
            ViewBag.Students = _context.Students.ToList();
            ViewBag.Courses = _context.Courses.ToList();
            return View();
        }

        // POST: Attendance/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Attendance attendance)
        {
            
                _context.Attendances.Add(attendance);
                _context.SaveChanges();
            
            ViewBag.Students = _context.Students.ToList();
            ViewBag.Courses = _context.Courses.ToList();
            return RedirectToAction("Index");
        }

        // GET: Attendance/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Attendance? attendance = _context.Attendances
                .Include(a => a.Student)
                .Include(a => a.Course)
                .FirstOrDefault(a => a.Id == id);
            if (attendance == null)
            {
                return NotFound();
            }

            ViewBag.Students = _context.Students.ToList();
            ViewBag.Courses = _context.Courses.ToList();
            return View(attendance);
        }

        // POST: Attendance/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Attendance attendance)
        {
            
                _context.Update(attendance);
                _context.SaveChanges();
            
            ViewBag.Students = _context.Students.ToList();
            ViewBag.Courses = _context.Courses.ToList();
            return RedirectToAction(nameof(Index));
        }

        // GET: Attendance/Delete/5
        public IActionResult Delete(int? id)
        {
            var attendance = _context.Attendances
                .Include(a => a.Student)
                .Include(a => a.Course)
                .FirstOrDefault(a => a.Id == id);
            if (attendance == null)
            {
                return NotFound();
            }

            return View(attendance);
        }


        // POST: Attendance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var attendance = _context.Attendances.Find(id);
            if (attendance != null)
            {
                _context.Attendances.Remove(attendance);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
