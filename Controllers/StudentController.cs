using Microsoft.AspNetCore.Mvc;
using EduFlex.Data;
using EduFlex.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace EduFlex.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Student
        public IActionResult Index()
        {
            List<Student> students = _context.Students.ToList();
            return View(students);
        }

        // GET: Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
           
                _context.Students.Add(student);
                _context.SaveChanges(); // Save changes to the database
                return RedirectToAction("Index"); // Redirect to the Index action
            
            
        }

        // GET: Student/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Student? student = _context.Students.Find(id);
            

            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            
                _context.Update(student);
                _context.SaveChanges(); // Save changes to the database
                return RedirectToAction(nameof(Index));
            
            
        }

        // GET: Student/Delete/5
        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges(); // Save changes to the database
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
