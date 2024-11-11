using Microsoft.AspNetCore.Mvc;
using EduFlex.Data;
using EduFlex.Models;
using System.Linq;

namespace EduFlex.Controllers
{
    public class ParentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Parent
        public IActionResult Index()
        {

            List<Parent> parents = _context.Parents.ToList();
            return View(parents);
        }

        // GET: Parent/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parent/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Parent parent)
        {
            
                _context.Parents.Add(parent);
                _context.SaveChanges();
                return RedirectToAction("Index");
            
        }

        // GET: Parent/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var parent = _context.Parents.Find(id);
            if (parent == null)
            {
                return NotFound();
            }

            return View(parent);
        }

        // POST: Parent/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Parent parent)
        {
            
                _context.Update(parent);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            
        }

        // GET: Parent/Delete/5
        public IActionResult Delete(int? id)
        {
            var parent = _context.Parents.Find(id);
            if (parent == null)
            {
                return NotFound();
            }

            return View(parent);
        }

        // POST: Parent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var parent = _context.Parents.Find(id);
            if (parent != null)
            {
                _context.Parents.Remove(parent);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
