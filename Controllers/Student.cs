using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Swaran.Models;
using SwaranSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SwaranSoft.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentDbContext _context;

        public StudentController()
        {
            _context = new StudentDbContext();
        }
        // GET: Student
        public ActionResult Create()
        {
            ViewBag.StateList = new SelectList(_context.States.ToList(), "Name", "Name");
            return View();
        }


        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StateList = new SelectList(_context.States.ToList(), "Name", "Name");
            return View(student);
        }



        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }

            ViewBag.StateList = new SelectList(_context.States.ToList(), "Name", "Name");
            return View(student);
        }

        private ActionResult HttpNotFound()
        {
            throw new NotImplementedException();
        }


        // POST: Student/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(student).State = EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StateList = new SelectList(_context.States.ToList(), "Name", "Name");
            return View(student);
        }

        // GET: Student
        public ActionResult Index()
        {
            var students = _context.Students.ToList();
            return View(students);
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }



        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);
            _context.Students.Remove(student);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}