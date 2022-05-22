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
    }
}
