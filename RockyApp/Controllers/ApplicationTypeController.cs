using Microsoft.AspNetCore.Mvc;
using RockyApp.Data;
using RockyApp.Models;
using System.Collections.Generic;

namespace RockyApp.Controllers
{
    public class ApplicationTypeController : Controller
    {
        // create a constructor
        private readonly ApplicationDbContext _db;

        public ApplicationTypeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<ApplicationType> objList = _db.ApplicationType; // doing it like this will retrieve all of the categories from the database and store in objlist
            return View(objList);

        }

        //GET CREATE
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ApplicationType obj)
        {
            _db.ApplicationType.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET - EDIT
        public IActionResult Edit(int? id)
        {
            // retrieve the category from the database
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.ApplicationType.Find(id);
            if (obj == null)
            {
                return NotFound();

            }

            return View(obj);
        }

        // POST - EDIT
        [HttpPost]  // this needs to be added
        [ValidateAntiForgeryToken]  //  validates token is still valid and hasn't been tampered
        public IActionResult Edit(ApplicationType obj)
        {
            if (ModelState.IsValid)
            {
                _db.ApplicationType.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        // GET - DELETE
        public IActionResult Delete(int? id)
        {
            // retrieve the category from the database
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.ApplicationType.Find(id);
            if (obj == null)
            {
                return NotFound();

            }

            return View(obj);
        }

        // POST - DELETE
        [HttpPost]  // this needs to be added
        [ValidateAntiForgeryToken]  //  validates token is still valid and hasn't been tampered
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.ApplicationType.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.ApplicationType.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
