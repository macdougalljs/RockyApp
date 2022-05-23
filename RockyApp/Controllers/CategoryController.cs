using Microsoft.AspNetCore.Mvc;
using RockyApp.Data;
using RockyApp.Models;
using System.Collections.Generic;

namespace RockyApp.Controllers
{
    public class CategoryController : Controller
    {

        // the addDbContext was already added in Startup.Cs, so we create a Constructor

        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)  // this generates an INSTANCE of the DbContext from the DI
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objList = _db.Category; // doing it like this will retrieve all of the categories from the database and store in objlist
            return View(objList);
        }


        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST - CREATE
        [HttpPost]  // this needs to be added
        [ValidateAntiForgeryToken]  //  validates token is still valid and hasn't been tampered
        public IActionResult Create(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obj);
        }

        // GET - EDIT
        public IActionResult Edit(int? id)
        {
            // retrieve the category from the database
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();

            }

            return View(obj);
        }

        // POST - EDIT
        [HttpPost]  // this needs to be added
        [ValidateAntiForgeryToken]  //  validates token is still valid and hasn't been tampered
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Category.Update(obj);
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

            var obj = _db.Category.Find(id);
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
            var obj = _db.Category.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Category.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");


           
        }


    }
}
