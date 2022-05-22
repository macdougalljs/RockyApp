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
    }
}
